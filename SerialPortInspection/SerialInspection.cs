using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace SerialPortInspection {
	public partial class SerialInspection : Form {
        private SerialPort _serialPort = new SerialPort();
		private string _scannerPort;
		private string _scannerData = "X";

		#region Delegates
		private delegate void AddListItem();
		private AddListItem dlgAddResult;    //Used to change the from's name

		private void AddResult()
		{
			try
			{
				lsbResults.Items.Add(_scannerData);
				lsbResults.SelectedIndex = lsbResults.Items.Count - 1;
				lsbResults.SelectedIndex = -1;
			}
			catch (Exception ex)
			{
				displayError(ex.Message);
			}
		}
		#endregion

		#region Form Methods
		public SerialInspection() {
			InitializeComponent();
			dlgAddResult = new AddListItem(AddResult);
		}

		private void frmSerialInspection_Shown(object sender, EventArgs e) {
			string[] ports = SerialPort.GetPortNames();

			if (ports.Length == 0) {
				MessageBox.Show("No serial ports available!");
				Environment.Exit(0);
			}

			Array.Sort(ports);

			foreach (string p in ports) {
				cmbAvailablePorts.Items.Add(p);
			}

			cmbAvailablePorts.SelectedIndex = 0;
			lblStatus.Text = "Serial ports listed...";
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			if (cmbAvailablePorts.SelectedIndex == -1) {
				MessageBox.Show("No valid port selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try {
				_serialPort = new SerialPort(cmbAvailablePorts.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
				_serialPort.DataReceived += spPort_DataReceived;
				_serialPort.Open();
				lblStatus.Text = cmbAvailablePorts.SelectedItem.ToString() + " is open";
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			_scannerPort = cmbAvailablePorts.SelectedItem.ToString();
		}

		private void btnClose_Click(object sender, EventArgs e) {
			try {
				_serialPort.Close();
				_serialPort.Dispose();
				lblStatus.Text = "Port " + _scannerPort + "closed...";
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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

		private void frmSerialInspection_FormClosing(object sender, FormClosingEventArgs e) {
			try {
				_serialPort.Close();
				_serialPort.Dispose();
				lblStatus.Text = "Port " + _scannerPort + "closed...";
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


		private void SerialInspection_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				if (lsbResults.SelectedItems.Count > 0)
				{
					Clipboard.SetText(lsbResults.SelectedItem.ToString());
				}
			}
		}
		#endregion

		private void spPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
			_scannerData = null;
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

		//Paeses the string in port suffixm, to get the equivalent chars, from unicode \u0002 to string ☻
		private string getStringValue(string sSuffix) {
			int x = 0; string t = ""; string sReturn = ""; int code;
			foreach (char c in sSuffix) {
				if (x == 6) {
					t = t.Replace(@"\u", "");
					code = int.Parse(t, System.Globalization.NumberStyles.HexNumber);
					sReturn += char.ConvertFromUtf32(code).ToString();
					x = 0; t = c.ToString();
				} else {
					t += c;
				}
				x++;
			}
			t = t.Replace(@"\u", "");
			if (t == "") {
				return "";
			} else {
				code = int.Parse(t, System.Globalization.NumberStyles.HexNumber);
				sReturn += char.ConvertFromUtf32(code).ToString();
				return sReturn;
			}
		}

		#region Read methods for the serial port
		private void sp_readExisting() {			
			if (rbtString.Checked) {
				_scannerData = _serialPort.ReadExisting();
			} else {
				byte[] data = Encoding.ASCII.GetBytes(_serialPort.ReadExisting());
				foreach (byte d in data) {
					_scannerData += "[" + d.ToString() + "]";
				}
			}
		}

		private void sp_read() {
			byte[] data = new byte[_serialPort.BytesToRead];
			_serialPort.Read(data, 0, data.Length);

			if (rbtString.Checked) {
				_scannerData = Encoding.UTF8.GetString(data);
			} else {
				foreach (byte d in data) {
					_scannerData += "[" + d.ToString() + "]";
				}
			}
		}

		private void sp_readLine() {
			if (pnlStatus.BackColor == Color.FromArgb(225, 44, 44)) {
				displayError("Not a valid suffix");
			} else {
				string suff = getStringValue(txtInput.Text);

				if (suff.Length > 0) {
					_serialPort.NewLine = suff;
				} else {
					displayError("Not a valid suffix");
					return;
				}

				if (rbtString.Checked) {
					_scannerData = _serialPort.ReadLine();
				} else {
					byte[] data = Encoding.ASCII.GetBytes(_serialPort.ReadLine());
					foreach (byte d in data) {
						_scannerData += "[" + d.ToString() + "]";
					}
				}
			}
		}
        #endregion

    }
}