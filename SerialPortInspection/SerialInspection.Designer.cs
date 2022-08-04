namespace SerialPortInspection {
	partial class SerialInspection {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialInspection));
            this.cmbAvailablePorts = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnOpenPortConnection = new System.Windows.Forms.Button();
            this.btnClosePortConnection = new System.Windows.Forms.Button();
            this.lsbResults = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gpbSerial = new System.Windows.Forms.GroupBox();
            this.gpbScanMode = new System.Windows.Forms.GroupBox();
            this.rbtByte = new System.Windows.Forms.RadioButton();
            this.rbtString = new System.Windows.Forms.RadioButton();
            this.gpbReadMode = new System.Windows.Forms.GroupBox();
            this.rbtReadExisting = new System.Windows.Forms.RadioButton();
            this.rbtReadLine = new System.Windows.Forms.RadioButton();
            this.rbtRead = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlNewLine = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.gpbSerial.SuspendLayout();
            this.gpbScanMode.SuspendLayout();
            this.gpbReadMode.SuspendLayout();
            this.pnlNewLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbAvailablePorts
            // 
            this.cmbAvailablePorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAvailablePorts.FormattingEnabled = true;
            this.cmbAvailablePorts.Location = new System.Drawing.Point(55, 27);
            this.cmbAvailablePorts.Name = "cmbAvailablePorts";
            this.cmbAvailablePorts.Size = new System.Drawing.Size(121, 21);
            this.cmbAvailablePorts.TabIndex = 0;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(22, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port";
            // 
            // btnOpenPortConnection
            // 
            this.btnOpenPortConnection.Location = new System.Drawing.Point(11, 65);
            this.btnOpenPortConnection.Name = "btnOpenPortConnection";
            this.btnOpenPortConnection.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPortConnection.TabIndex = 2;
            this.btnOpenPortConnection.Text = "Open";
            this.btnOpenPortConnection.UseVisualStyleBackColor = true;
            this.btnOpenPortConnection.Click += new System.EventHandler(this.btnOpenPortConnection_Click);
            // 
            // btnClosePortConnection
            // 
            this.btnClosePortConnection.Enabled = false;
            this.btnClosePortConnection.Location = new System.Drawing.Point(101, 65);
            this.btnClosePortConnection.Name = "btnClosePortConnection";
            this.btnClosePortConnection.Size = new System.Drawing.Size(75, 23);
            this.btnClosePortConnection.TabIndex = 3;
            this.btnClosePortConnection.Text = "Close";
            this.btnClosePortConnection.UseVisualStyleBackColor = true;
            this.btnClosePortConnection.Click += new System.EventHandler(this.btnClosePortConnection_Click);
            // 
            // lsbResults
            // 
            this.lsbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbResults.FormattingEnabled = true;
            this.lsbResults.Location = new System.Drawing.Point(12, 129);
            this.lsbResults.Name = "lsbResults";
            this.lsbResults.Size = new System.Drawing.Size(466, 147);
            this.lsbResults.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 299);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Waiting...";
            // 
            // gpbSerial
            // 
            this.gpbSerial.Controls.Add(this.lblPort);
            this.gpbSerial.Controls.Add(this.cmbAvailablePorts);
            this.gpbSerial.Controls.Add(this.btnOpenPortConnection);
            this.gpbSerial.Controls.Add(this.btnClosePortConnection);
            this.gpbSerial.Location = new System.Drawing.Point(12, 12);
            this.gpbSerial.Name = "gpbSerial";
            this.gpbSerial.Size = new System.Drawing.Size(192, 107);
            this.gpbSerial.TabIndex = 6;
            this.gpbSerial.TabStop = false;
            this.gpbSerial.Text = "Serial Port";
            // 
            // gpbScanMode
            // 
            this.gpbScanMode.Controls.Add(this.rbtByte);
            this.gpbScanMode.Controls.Add(this.rbtString);
            this.gpbScanMode.Location = new System.Drawing.Point(219, 12);
            this.gpbScanMode.Name = "gpbScanMode";
            this.gpbScanMode.Size = new System.Drawing.Size(100, 107);
            this.gpbScanMode.TabIndex = 7;
            this.gpbScanMode.TabStop = false;
            this.gpbScanMode.Text = "Scan Mode";
            // 
            // rbtByte
            // 
            this.rbtByte.AutoSize = true;
            this.rbtByte.Location = new System.Drawing.Point(18, 59);
            this.rbtByte.Name = "rbtByte";
            this.rbtByte.Size = new System.Drawing.Size(46, 17);
            this.rbtByte.TabIndex = 1;
            this.rbtByte.Text = "Byte";
            this.rbtByte.UseVisualStyleBackColor = true;
            // 
            // rbtString
            // 
            this.rbtString.AutoSize = true;
            this.rbtString.Checked = true;
            this.rbtString.Location = new System.Drawing.Point(18, 32);
            this.rbtString.Name = "rbtString";
            this.rbtString.Size = new System.Drawing.Size(52, 17);
            this.rbtString.TabIndex = 0;
            this.rbtString.TabStop = true;
            this.rbtString.Text = "String";
            this.rbtString.UseVisualStyleBackColor = true;
            // 
            // gpbReadMode
            // 
            this.gpbReadMode.Controls.Add(this.rbtReadExisting);
            this.gpbReadMode.Controls.Add(this.rbtReadLine);
            this.gpbReadMode.Controls.Add(this.rbtRead);
            this.gpbReadMode.Location = new System.Drawing.Point(335, 12);
            this.gpbReadMode.Name = "gpbReadMode";
            this.gpbReadMode.Size = new System.Drawing.Size(143, 107);
            this.gpbReadMode.TabIndex = 8;
            this.gpbReadMode.TabStop = false;
            this.gpbReadMode.Text = "Read Mode";
            // 
            // rbtReadExisting
            // 
            this.rbtReadExisting.AutoSize = true;
            this.rbtReadExisting.Checked = true;
            this.rbtReadExisting.Location = new System.Drawing.Point(21, 68);
            this.rbtReadExisting.Name = "rbtReadExisting";
            this.rbtReadExisting.Size = new System.Drawing.Size(93, 17);
            this.rbtReadExisting.TabIndex = 2;
            this.rbtReadExisting.TabStop = true;
            this.rbtReadExisting.Text = "ReadExisting()";
            this.rbtReadExisting.UseVisualStyleBackColor = true;
            // 
            // rbtReadLine
            // 
            this.rbtReadLine.AutoSize = true;
            this.rbtReadLine.Location = new System.Drawing.Point(21, 45);
            this.rbtReadLine.Name = "rbtReadLine";
            this.rbtReadLine.Size = new System.Drawing.Size(77, 17);
            this.rbtReadLine.TabIndex = 1;
            this.rbtReadLine.Text = "ReadLine()";
            this.rbtReadLine.UseVisualStyleBackColor = true;
            this.rbtReadLine.CheckedChanged += new System.EventHandler(this.rbtReadLine_CheckedChanged);
            // 
            // rbtRead
            // 
            this.rbtRead.AutoSize = true;
            this.rbtRead.Location = new System.Drawing.Point(21, 23);
            this.rbtRead.Name = "rbtRead";
            this.rbtRead.Size = new System.Drawing.Size(57, 17);
            this.rbtRead.TabIndex = 0;
            this.rbtRead.Text = "Read()";
            this.rbtRead.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(403, 285);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlNewLine
            // 
            this.pnlNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNewLine.Controls.Add(this.pnlStatus);
            this.pnlNewLine.Controls.Add(this.btnHelp);
            this.pnlNewLine.Controls.Add(this.txtInput);
            this.pnlNewLine.Controls.Add(this.lblLine);
            this.pnlNewLine.Location = new System.Drawing.Point(199, 282);
            this.pnlNewLine.Name = "pnlNewLine";
            this.pnlNewLine.Size = new System.Drawing.Size(198, 30);
            this.pnlNewLine.TabIndex = 10;
            this.pnlNewLine.Visible = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(184)))), ((int)(((byte)(72)))));
            this.pnlStatus.Location = new System.Drawing.Point(146, 7);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(15, 15);
            this.pnlStatus.TabIndex = 8;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(167, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 23);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(58, 5);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(83, 20);
            this.txtInput.TabIndex = 1;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(3, 8);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(49, 13);
            this.lblLine.TabIndex = 0;
            this.lblLine.Text = "Line End";
            // 
            // SerialInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 321);
            this.Controls.Add(this.pnlNewLine);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gpbReadMode);
            this.Controls.Add(this.gpbScanMode);
            this.Controls.Add(this.gpbSerial);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lsbResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SerialInspection";
            this.Text = "Serial Port Inspection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSerialInspection_FormClosing);
            this.Shown += new System.EventHandler(this.SerialInspection_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerialInspection_KeyDown);
            this.gpbSerial.ResumeLayout(false);
            this.gpbSerial.PerformLayout();
            this.gpbScanMode.ResumeLayout(false);
            this.gpbScanMode.PerformLayout();
            this.gpbReadMode.ResumeLayout(false);
            this.gpbReadMode.PerformLayout();
            this.pnlNewLine.ResumeLayout(false);
            this.pnlNewLine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.Button btnOpenPortConnection;
		private System.Windows.Forms.Button btnClosePortConnection;
		private System.Windows.Forms.ListBox lsbResults;
		public System.Windows.Forms.ComboBox cmbAvailablePorts;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.GroupBox gpbSerial;
		private System.Windows.Forms.GroupBox gpbScanMode;
		private System.Windows.Forms.RadioButton rbtByte;
		private System.Windows.Forms.RadioButton rbtString;
		private System.Windows.Forms.GroupBox gpbReadMode;
		private System.Windows.Forms.RadioButton rbtReadExisting;
		private System.Windows.Forms.RadioButton rbtReadLine;
		private System.Windows.Forms.RadioButton rbtRead;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Panel pnlNewLine;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Label lblLine;
		private System.Windows.Forms.Panel pnlStatus;
	}
}

