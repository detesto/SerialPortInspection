namespace SerialPortInspection {
	partial class SuffixHelpForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuffixHelpForm));
			this.lblText = new System.Windows.Forms.Label();
			this.lsbExamples = new System.Windows.Forms.ListBox();
			this.txtChar = new System.Windows.Forms.TextBox();
			this.txtString = new System.Windows.Forms.TextBox();
			this.gpbSelectedIndex = new System.Windows.Forms.GroupBox();
			this.lblChar = new System.Windows.Forms.Label();
			this.lblString = new System.Windows.Forms.Label();
			this.gpbBuild = new System.Windows.Forms.GroupBox();
			this.pnlStatus = new System.Windows.Forms.Panel();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.lblOutput = new System.Windows.Forms.Label();
			this.lblInput = new System.Windows.Forms.Label();
			this.gpbSelectedIndex.SuspendLayout();
			this.gpbBuild.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblText
			// 
			this.lblText.AutoSize = true;
			this.lblText.Location = new System.Drawing.Point(12, 19);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(352, 52);
			this.lblText.TabIndex = 0;
			this.lblText.Text = "This will be the characters used to limit a new line. Most scanners send a \r\nsuff" +
    "ix after each read.\r\n\r\nAll characters must be in the &&#XX; ASCII format.";
			// 
			// lsbExamples
			// 
			this.lsbExamples.FormattingEnabled = true;
			this.lsbExamples.Items.AddRange(new object[] {
            "Null",
            "Start of Heading (SOH)",
            "Start of Text (STX)",
            "End of Text (ETX)",
            "End of Tansmission (EOT)",
            "Enquiry (ENQ)",
            "Acknowledge (ACK)",
            "Bell (BEL)",
            "Backspace (BS)",
            "Horizontal Tab (TAB)",
            "Line Feed / New Line (LF/NL)",
            "Vertical Tab (VT)",
            "Form Feed / New Page (FF/NP)",
            "Carriage Return (CR)"});
			this.lsbExamples.Location = new System.Drawing.Point(15, 88);
			this.lsbExamples.Name = "lsbExamples";
			this.lsbExamples.Size = new System.Drawing.Size(169, 199);
			this.lsbExamples.TabIndex = 1;
			this.lsbExamples.SelectedIndexChanged += new System.EventHandler(this.lsbExamples_SelectedIndexChanged);
			this.lsbExamples.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbExamples_MouseDoubleClick);
			// 
			// txtChar
			// 
			this.txtChar.Location = new System.Drawing.Point(50, 60);
			this.txtChar.Name = "txtChar";
			this.txtChar.ReadOnly = true;
			this.txtChar.Size = new System.Drawing.Size(74, 20);
			this.txtChar.TabIndex = 2;
			// 
			// txtString
			// 
			this.txtString.Location = new System.Drawing.Point(50, 22);
			this.txtString.Name = "txtString";
			this.txtString.ReadOnly = true;
			this.txtString.Size = new System.Drawing.Size(74, 20);
			this.txtString.TabIndex = 3;
			// 
			// gpbSelectedIndex
			// 
			this.gpbSelectedIndex.Controls.Add(this.lblChar);
			this.gpbSelectedIndex.Controls.Add(this.lblString);
			this.gpbSelectedIndex.Controls.Add(this.txtString);
			this.gpbSelectedIndex.Controls.Add(this.txtChar);
			this.gpbSelectedIndex.Location = new System.Drawing.Point(205, 88);
			this.gpbSelectedIndex.Name = "gpbSelectedIndex";
			this.gpbSelectedIndex.Size = new System.Drawing.Size(149, 98);
			this.gpbSelectedIndex.TabIndex = 4;
			this.gpbSelectedIndex.TabStop = false;
			this.gpbSelectedIndex.Text = "Selected Value";
			// 
			// lblChar
			// 
			this.lblChar.AutoSize = true;
			this.lblChar.Location = new System.Drawing.Point(13, 60);
			this.lblChar.Name = "lblChar";
			this.lblChar.Size = new System.Drawing.Size(29, 13);
			this.lblChar.TabIndex = 5;
			this.lblChar.Text = "Char";
			// 
			// lblString
			// 
			this.lblString.AutoSize = true;
			this.lblString.Location = new System.Drawing.Point(8, 22);
			this.lblString.Name = "lblString";
			this.lblString.Size = new System.Drawing.Size(34, 13);
			this.lblString.TabIndex = 4;
			this.lblString.Text = "String";
			// 
			// gpbBuild
			// 
			this.gpbBuild.Controls.Add(this.pnlStatus);
			this.gpbBuild.Controls.Add(this.txtOutput);
			this.gpbBuild.Controls.Add(this.txtInput);
			this.gpbBuild.Controls.Add(this.lblOutput);
			this.gpbBuild.Controls.Add(this.lblInput);
			this.gpbBuild.Location = new System.Drawing.Point(205, 198);
			this.gpbBuild.Name = "gpbBuild";
			this.gpbBuild.Size = new System.Drawing.Size(149, 89);
			this.gpbBuild.TabIndex = 5;
			this.gpbBuild.TabStop = false;
			this.gpbBuild.Text = "Build Suffix";
			// 
			// pnlStatus
			// 
			this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(184)))), ((int)(((byte)(72)))));
			this.pnlStatus.Location = new System.Drawing.Point(127, 25);
			this.pnlStatus.Name = "pnlStatus";
			this.pnlStatus.Size = new System.Drawing.Size(15, 15);
			this.pnlStatus.TabIndex = 7;
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(48, 51);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Size = new System.Drawing.Size(74, 20);
			this.txtOutput.TabIndex = 3;
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(48, 22);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(74, 20);
			this.txtInput.TabIndex = 2;
			this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
			// 
			// lblOutput
			// 
			this.lblOutput.AutoSize = true;
			this.lblOutput.Location = new System.Drawing.Point(3, 54);
			this.lblOutput.Name = "lblOutput";
			this.lblOutput.Size = new System.Drawing.Size(39, 13);
			this.lblOutput.TabIndex = 1;
			this.lblOutput.Text = "Output";
			// 
			// lblInput
			// 
			this.lblInput.AutoSize = true;
			this.lblInput.Location = new System.Drawing.Point(11, 25);
			this.lblInput.Name = "lblInput";
			this.lblInput.Size = new System.Drawing.Size(31, 13);
			this.lblInput.TabIndex = 0;
			this.lblInput.Text = "Input";
			// 
			// frmHelp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 310);
			this.Controls.Add(this.gpbBuild);
			this.Controls.Add(this.gpbSelectedIndex);
			this.Controls.Add(this.lsbExamples);
			this.Controls.Add(this.lblText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmHelp";
			this.Text = "Help";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHelp_FormClosing);
			this.Shown += new System.EventHandler(this.frmHelp_Shown);
			this.gpbSelectedIndex.ResumeLayout(false);
			this.gpbSelectedIndex.PerformLayout();
			this.gpbBuild.ResumeLayout(false);
			this.gpbBuild.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblText;
		private System.Windows.Forms.ListBox lsbExamples;
		private System.Windows.Forms.TextBox txtChar;
		private System.Windows.Forms.TextBox txtString;
		private System.Windows.Forms.GroupBox gpbSelectedIndex;
		private System.Windows.Forms.Label lblChar;
		private System.Windows.Forms.Label lblString;
		private System.Windows.Forms.GroupBox gpbBuild;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Label lblOutput;
		private System.Windows.Forms.Label lblInput;
		private System.Windows.Forms.Panel pnlStatus;

	}
}