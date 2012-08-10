using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace SerialPortInspection {
	public partial class frmSerialInspection : Form {
		public SerialPort spPort = new SerialPort();
		public string sPort;
		public string sRead = "X";

		#region Delegates
		public delegate void AddListItem();
		public AddListItem dlgAddResult;    //Usado para cambiar el nombre de la ventana

		public void addResult() {
			try {
				lsbResults.Items.Add(sRead);
				lsbResults.SelectedIndex = lsbResults.Items.Count - 1;
				lsbResults.SelectedIndex = -1;
			} catch (Exception ex) {
				displayError(ex.Message);
			}
		}
		#endregion

		#region Form Methods
		public frmSerialInspection() {
			InitializeComponent();
			dlgAddResult = new AddListItem(addResult);
		}

		private void frmSerialInspection_Shown(object sender, EventArgs e) {
			string[] ports = SerialPort.GetPortNames();

			if (ports.Length == 0) {
				MessageBox.Show("No serial ports available!");
				Environment.Exit(0);
			}

			Array.Sort(ports);

			foreach (string p in ports) {
				cmbPorts.Items.Add(p);
			}

			cmbPorts.SelectedIndex = 0;
			lblStatus.Text = "Serial ports listed...";
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			if (cmbPorts.SelectedIndex == -1) {
				MessageBox.Show("No valid port selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try {
				spPort = new SerialPort(cmbPorts.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
				spPort.DataReceived += spPort_DataReceived;
				spPort.Open();
				lblStatus.Text = cmbPorts.SelectedItem.ToString() + " is open";
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			sPort = cmbPorts.SelectedItem.ToString();
		}

		private void btnClose_Click(object sender, EventArgs e) {
			try {
				spPort.Close();
				spPort.Dispose();
				lblStatus.Text = "Port " + sPort + "closed...";
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtInput_TextChanged(object sender, EventArgs e) {
			string sPattern = @"^(&#\d{2};)+$";
			Regex rExp = new Regex(sPattern);
			if (rExp.IsMatch(txtInput.Text)) {
				pnlStatus.BackColor = Color.FromArgb(76, 184, 72);
			} else {
				pnlStatus.BackColor = Color.FromArgb(225, 44, 44);
			}
		}

		private void frmSerialInspection_FormClosing(object sender, FormClosingEventArgs e) {
			try {
				spPort.Close();
				spPort.Dispose();
				lblStatus.Text = "Port " + sPort + "closed...";
			} catch { }
		}

		private void btnClear_Click(object sender, EventArgs e) {
			lsbResults.Items.Clear();
		}

		private void rbtReadLine_CheckedChanged(object sender, EventArgs e) {
			pnlNewLine.Visible = rbtReadLine.Checked;
		}

		private void btnHelp_Click(object sender, EventArgs e) {
			using (frmHelp fmH = new frmHelp()) {
				fmH.ShowDialog();
				txtInput.Text = fmH.sReturnSuffix;
			}
		}
		#endregion

		private void spPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
			sRead = null;
			if (rbtReadExisting.Checked) {
				sp_readExisting();
			} else if (rbtRead.Checked) {
				sp_read();
			} else if (rbtReadLine.Checked) {
				sp_readLine();
			}
			Invoke(dlgAddResult);
		}

		private void displayError(string msg) {
			MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		#region Read methods for the serial port
		private void sp_readExisting() {
			if (rbtString.Checked) {
				sRead = spPort.ReadExisting();
			} else {
				byte[] data = Encoding.ASCII.GetBytes(spPort.ReadExisting());
				foreach (byte d in data) {
					sRead += "[" + d.ToString() + "]";
				}
			}
		}

		private void sp_read() {
			byte[] data = new byte[spPort.BytesToRead];
			spPort.Read(data, 0, data.Length);

			if (rbtString.Checked) {
				sRead = Encoding.UTF8.GetString(data);
			} else {
				foreach (byte d in data) {
					sRead += "[" + d.ToString() + "]";
				}
			}
		}

		private void sp_readLine() {
			if (pnlStatus.BackColor == Color.FromArgb(225, 44, 44)) {
				displayError("Not a valid suffix");
			} else {
				string[] sSplit = txtInput.Text.Split(';');
				string sSuffix = "";
				foreach (string s in sSplit) {
					string t = Regex.Replace(s, "[^0-9]*", "");
					if (t.Length == 2) {
						sSuffix += char.ConvertFromUtf32(int.Parse(t));
					}
				}

				if (sSuffix.Length > 0) {
					spPort.NewLine = sSuffix;
				}

				if (rbtString.Checked) {
					sRead = spPort.ReadLine();
				} else {
					byte[] data = Encoding.ASCII.GetBytes(spPort.ReadLine());
					foreach (byte d in data) {
						sRead += "[" + d.ToString() + "]";
					}
				}
			}
		}
		#endregion
	}
}