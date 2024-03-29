﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace SerialPortInspection
{
	public partial class SerialInspectionForm : Form
	{
		private SerialPort _serialPort;
		private string _scannerPort;

		private bool _validPrefix;

		#region Delegates
		private delegate void AddListItem(string scannerData);
		private AddListItem AddResultDelegate;    //Used to change the from's name in cross-thread

		private void AddResult(string scannerData)
		{
			if (string.IsNullOrWhiteSpace(scannerData))
			{
				return;
			}

			try
			{
				lsbScanLog.Items.Add(scannerData);
				lsbScanLog.SelectedIndex = lsbScanLog.Items.Count - 1;
				lsbScanLog.SelectedIndex = -1;
			}
			catch (Exception ex)
			{
				DisplayError(ex.Message);
			}
		}
		#endregion

		public SerialInspectionForm()
		{
			InitializeComponent();

			_serialPort = new SerialPort();
			_validPrefix = false;

			AddResultDelegate = new AddListItem(AddResult);
		}

		#region Form Methods
		private void SerialInspection_Shown(object sender, EventArgs e)
		{
			var ports = SerialPort.GetPortNames();

			if (ports.Length == 0)
			{
				MessageBox.Show("No serial ports available!");
				Environment.Exit(0);
			}

			Array.Sort(ports);

			foreach (string p in ports)
			{
				cmbAvailablePorts.Items.Add(p);
			}

			cmbAvailablePorts.SelectedIndex = 0;
			lblStatus.Text = "Serial ports listed...";
		}

		private void btnOpenPortConnection_Click(object sender, EventArgs e)
		{
			if (cmbAvailablePorts.SelectedIndex == -1)
			{
				MessageBox.Show("No valid port selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				_serialPort = new SerialPort(cmbAvailablePorts.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
				_serialPort.DataReceived += spPort_DataReceived;
				_serialPort.Open();

				lblStatus.Text = cmbAvailablePorts.SelectedItem.ToString() + " is open";

				btnOpenPortConnection.Enabled = false;
				btnClosePortConnection.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			_scannerPort = cmbAvailablePorts.SelectedItem.ToString();
		}

		private void btnClosePortConnection_Click(object sender, EventArgs e)
		{
			try
			{
				_serialPort.Close();
				_serialPort.Dispose();
				lblStatus.Text = "Port " + _scannerPort + " closed...";

				btnOpenPortConnection.Enabled = true;
				btnClosePortConnection.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtInput_TextChanged(object sender, EventArgs e)
		{
			var sPattern = @"^(\\u000[0-9a-fA-F])+$";
			Regex rExp = new Regex(sPattern);

			if (rExp.IsMatch(txtInput.Text))
			{
				pnlStatus.BackColor = Color.FromArgb(76, 184, 72);
			}
			else
			{
				pnlStatus.BackColor = Color.FromArgb(225, 44, 44);
			}
		}

		private void frmSerialInspection_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				_serialPort.Close();
				_serialPort.Dispose();
				lblStatus.Text = "Port " + _scannerPort + "closed...";
			}
			catch { }
		}

		private void btnClearScanLog_Click(object sender, EventArgs e)
		{
			lsbScanLog.Items.Clear();
		}

		private void rbtReadLine_CheckedChanged(object sender, EventArgs e)
		{
			pnlNewLine.Visible = rbtReadLine.Checked;
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			using (var fmH = new SuffixHelpForm())
			{
				fmH.ShowDialog();
				txtInput.Text = fmH.sReturnSuffix;
			}
		}

		private void SerialInspection_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				if (lsbScanLog.SelectedItems.Count > 0)
				{
					Clipboard.SetText(lsbScanLog.SelectedItem.ToString());
				}
			}
		}
		#endregion

		private void spPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			var scannerData = string.Empty;

			if (rbtReadExisting.Checked)
			{
				scannerData = ScannerReadExisting();
			}
			else if (rbtRead.Checked)
			{
				scannerData = ScannerRead();
			}
			else if (rbtReadLine.Checked)
			{
				scannerData = ScannerReadLine();
			}

			Invoke(AddResultDelegate, scannerData);
		}

		private void DisplayError(string msg)
		{
			MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		//Paeses the string in port suffix to get the equivalent chars, from unicode \u0002 to string ☻
		private string GetStringValue(string sSuffix)
		{
			int x = 0; string t = ""; string sReturn = ""; int code;
			
			foreach (char c in sSuffix)
			{
				if (x == 6)
				{
					t = t.Replace(@"\u", "");
					code = int.Parse(t, System.Globalization.NumberStyles.HexNumber);
					sReturn += char.ConvertFromUtf32(code).ToString();
					x = 0; t = c.ToString();
				}
				else
				{
					t += c;
				}
				x++;
			}
			t = t.Replace(@"\u", "");
			if (t == "")
			{
				return "";
			}
			else
			{
				code = int.Parse(t, System.Globalization.NumberStyles.HexNumber);
				sReturn += char.ConvertFromUtf32(code).ToString();
				return sReturn;
			}
		}

		#region Read methods for the serial port
		private string ScannerReadExisting()
		{
			var scannerData = _serialPort.ReadExisting();

			if (rbtByte.Checked)
			{
				var data = Encoding.ASCII.GetBytes(scannerData);
				var bytes = BitConverter.ToString(data);

				scannerData = bytes.ToString().Replace("-", " ");
			}

			return scannerData;
		}

		private string ScannerRead()
		{
			var scannerData = string.Empty;
			var data = new byte[_serialPort.BytesToRead];

			_serialPort.Read(data, 0, data.Length);

			if (rbtString.Checked)
			{
				scannerData = Encoding.UTF8.GetString(data);
			}
			else
			{
				var bytes = BitConverter.ToString(data);

				scannerData = bytes.ToString().Replace("-", " ");
			}

			return scannerData;
		}

		private string ScannerReadLine()
		{
			var scannerData = string.Empty;

			if (!_validPrefix)
			{
				DisplayError("Not a valid suffix");
			}
			else
			{
				var suff = GetStringValue(txtInput.Text);

				if (suff.Length > 0)
				{
					_serialPort.NewLine = suff;
				}
				else
				{
					DisplayError("Not a valid suffix");
					return scannerData;
				}

				if (rbtString.Checked)
				{
					scannerData = _serialPort.ReadLine();
				}
				else
				{
					var data = Encoding.ASCII.GetBytes(_serialPort.ReadLine());
					var bytes = BitConverter.ToString(data);

					scannerData = bytes.ToString().Replace("-", " ");
				}
			}

			return scannerData;
		}
		#endregion
	}
}