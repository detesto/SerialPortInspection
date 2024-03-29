﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SerialPortInspection {
	public partial class SuffixHelpForm : Form {
		public string sReturnSuffix;
		public SuffixHelpForm() {
			InitializeComponent();
		}

		private void lsbExamples_SelectedIndexChanged(object sender, EventArgs e) {
			txtChar.Text = char.ConvertFromUtf32(lsbExamples.SelectedIndex);
			txtString.Text = @"\u000" + lsbExamples.SelectedIndex.ToString("x");
		}

		private void txtInput_TextChanged(object sender, EventArgs e) {
			string sPattern = @"^(\\u000[0-9a-fA-F])+$";
			Regex rExp = new Regex(sPattern);
			if (rExp.IsMatch(txtInput.Text)) {
				pnlStatus.BackColor = Color.FromArgb(76, 184, 72);
			} else {
				pnlStatus.BackColor = Color.FromArgb(225, 44, 44);
			}
		}

		private void displayError(string msg) {
			MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			txtString.SelectAll();
			txtString.Focus();
		}

		private void frmHelp_Shown(object sender, EventArgs e) {
			txtInput.Focus();
		}

		private void frmHelp_FormClosing(object sender, FormClosingEventArgs e) {
			if (pnlStatus.BackColor == Color.FromArgb(76, 184, 72)) {
				sReturnSuffix = txtInput.Text;
			} else {
				sReturnSuffix = "";
			}
		}

		private void lsbExamples_MouseDoubleClick(object sender, MouseEventArgs e) {
			pnlStatus.BackColor = Color.FromArgb(76, 184, 72);
			txtInput.Text = @"\u000" + lsbExamples.SelectedIndex.ToString("x");
			this.Close();
		}
	}
}
