namespace PreallignerLogger
{
    using System.IO.Ports;
    using System.Text.Encodings;

    public enum eLogLevel
    {
        information,
        warning,
        error,
        success
    }
    public partial class Form1 : Form
    {
        private SerialPort _serial;
        private bool _testRunning = false;
        private CancellationTokenSource cts;
        private CancellationToken ct;
        private string _logPath = $"Logs\\log_{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")}.log";

        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            cbPort.DataSource = SerialPort.GetPortNames();

            if (File.Exists("defaults.txt"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader("defaults.txt"))
                    {
                        cbPort.Text = sr.ReadLine();
                        numInterval.Value = Convert.ToInt32(sr.ReadLine());
                        tbCommand.Text = sr.ReadLine();
                    }
                }
                //Something is wrong with the file. Just ignore.
                catch { }
            }
        }

        private async void btnStartStop_Click(object sender, EventArgs e)
        {
            //Toggle UI controls
            btnStartStop.Text = _testRunning ? "Start" : "Stop";
            cbPort.Enabled = !cbPort.Enabled;
            tbCommand.Enabled = !tbCommand.Enabled;
            numInterval.Enabled = !numInterval.Enabled;
            tbLog.Enabled = !tbLog.Enabled;
            _testRunning = !_testRunning;

            Task serialTask = Task.CompletedTask;

            if (_testRunning)
            {
                //Write defaults file
                using (StreamWriter sw = new StreamWriter("defaults.txt"))
                {
                    sw.WriteLine(cbPort.Text);
                    sw.WriteLine(numInterval.Value);
                    sw.Write(tbCommand.Text);
                }

                cts = new CancellationTokenSource();
                ct = cts.Token;
                //Create and open serial port
                try
                {
                    _serial = new SerialPort(cbPort.Text, 115200, Parity.None, 8, StopBits.One);
                    if (!_serial.IsOpen)
                        _serial.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening serial port: {ex.Message}");
                    Environment.Exit(1);
                }

                //Flush stream of any garbage data
                _serial.BaseStream.Flush();

                //run serial thread
                serialTask = Task.Run(() => RunSerialThread(), ct);
            }
            else
            {
                cts.Cancel();
                while (!serialTask.IsCompleted)
                {
                    Thread.Sleep(1000);
                }
                _serial.Close();
            }
        }

        private async Task RunSerialThread()
        {
            var reset = new AutoResetEvent(false);
            Log(eLogLevel.success, "Start");
            while (_testRunning && !ct.IsCancellationRequested)
            {
                reset.WaitOne((int)numInterval.Value);
                try
                {
                    WriteSerial(tbCommand.Text);
                    var buffer = new byte[4];
                    var res = await ReadSerialAsync(_serial, buffer, 0, buffer.Length);
                    Log(eLogLevel.success, res);
                }
                catch (Exception ex)
                {
                    Log(eLogLevel.error, $"Error reading/writing to serial port. {ex.Message}");
                }
                reset.Reset();
            }
        }

        private void WriteSerial(string text)
        {
            if (_serial.IsOpen)
                _serial.Write($"{text}\r");
            Log(eLogLevel.information, $">>{text}");
        }

        private async Task<string> ReadSerialAsync(SerialPort serial, byte[] buffer, int offset, int count)
        {
            if (_serial.IsOpen)
            {
                serial.Read(buffer, offset, count);
                return System.Text.Encoding.Default.GetString(buffer);
            }
            return String.Empty;
        }

        private void Log(eLogLevel level, string text)
        {
            tbLog.Invoke(() => tbLog.AppendText(text + Environment.NewLine));
            using (StreamWriter sw = new StreamWriter(_logPath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss")} | {text}");
            }
        }
    }
}