using CalendarLib;
using System;
using System.Windows.Forms;

namespace CalendarForm
{
	public partial class formMonthCalendar : Form
	{
		public formMonthCalendar()
		{
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
			Calendar calendar = new Calendar(1, month, year);
			var arr = calendar.GetMonthArray();
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					Control control = tabCalendar.GetControlFromPosition(j, i + 1);
					if (arr[i, j] == 0)
						control.Text = "";
					else
						control.Text = arr[i, j].ToString();
				}
			}
		}
	}
}
