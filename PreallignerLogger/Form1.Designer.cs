namespace PreallignerLogger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblCommand = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.cbPort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(76, 69);
            this.numInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(120, 23);
            this.numInterval.TabIndex = 2;
            this.numInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(242, 23);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(120, 69);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // tbLog
            // 
            this.tbLog.Enabled = false;
            this.tbLog.Location = new System.Drawing.Point(82, 255);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(286, 214);
            this.tbLog.TabIndex = 4;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(11, 26);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(60, 15);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "COM Port";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(2, 72);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(73, 15);
            this.lblInterval.TabIndex = 5;
            this.lblInterval.Text = "Interval (ms)";
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(10, 121);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(64, 15);
            this.lblCommand.TabIndex = 7;
            this.lblCommand.Text = "Command";
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(76, 118);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(119, 23);
            this.tbCommand.TabIndex = 6;
            this.tbCommand.Text = "MDOC";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(77, 23);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(121, 23);
            this.cbPort.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 509);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.numInterval);
            this.Name = "Form1";
            this.Text = "Prealligner Logger";
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown numInterval;
        private Button btnStartStop;
        private TextBox tbLog;
        private Label lblPort;
        private Label lblInterval;
        private Label lblCommand;
        private TextBox tbCommand;
        private ComboBox cbPort;
    }
}