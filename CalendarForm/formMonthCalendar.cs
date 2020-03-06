using CalendarLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CalendarForm
{
	public partial class formMonthCalendar : Form
	{
		private List<KeyValuePair<DateTime, string>> danhSachNgayLe = new List<KeyValuePair<DateTime, string>>();

		public formMonthCalendar()
		{
			ReadCSV();
			InitializeComponent();
			lblTen.Text = "LỊCH VẠN NIÊN " + DateTime.Now.Year;
			nudMonth.Value = DateTime.Now.Month;
			nudYear.Value = DateTime.Now.Year;
			btnView_Click(null, null);
		}

		private void btnView_Click(object sender, EventArgs e)
		{
			int month = (int)nudMonth.Value;
			int year = (int)nudYear.Value;
			PrintMonthCalendar(month, year);
		}

		private void PrintMonthCalendar(int month, int year)
		{
			CalendarLib.Calendar calendar = new CalendarLib.Calendar(1, month, year);
			var arr = calendar.GetMonthArray();
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					Control control = tabCalendar.GetControlFromPosition(j, i + 1);
					if (arr[i, j] == 0)
						control.Text = "";
					else
					{
						control.Text = arr[i, j].ToString();
						string ngayLe = GetNgayLe(arr[i, j], month);
						toolTip.SetToolTip(control, GetNgayLe(arr[i, j], month));
						if (ngayLe != "")
						{
							control.Text += "*";
						}
					}
				}
			}
		}

		private void ReadCSV()
		{
			new Thread(() =>
			{
				List<string> cacNgayLe = new List<string>(Properties.Resources.NgayLe.Split(new string[] { "\r\n" }, StringSplitOptions.None));
				foreach (var ngayLe in cacNgayLe)
				{
					string[] temp = ngayLe.Split(':');
					DateTime date = DateTime.Now;
					try
					{
						date = DateTime.ParseExact(temp[0], "d-M-yyyy", CultureInfo.InvariantCulture);
					}
					catch (Exception)
					{
						date = DateTime.ParseExact(temp[0], "d-M", CultureInfo.InvariantCulture);
					}
					danhSachNgayLe.Add(new KeyValuePair<DateTime, string>(date, temp[1]));
				}
			}).Start();
		}

		private string GetNgayLe(int day, int month)
		{
			var ketQua = danhSachNgayLe.FindAll(x => x.Key.Month == month && x.Key.Day == day);
			string dongChu = "";
			foreach (var ngayLe in ketQua)
			{
				dongChu += ngayLe.Key.ToString("d/M") + ": " + ngayLe.Value + "\r\n";
			}
			return dongChu;
		}

		private void menuOpen_Click(object sender, EventArgs e)
		{
			this.Show();
			this.Activate();
		}

		private void menuClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void formMonthCalendar_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				this.Hide();
			}
		}
	}
}
