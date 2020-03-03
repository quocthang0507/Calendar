using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLib
{
	public class Calendar
	{
		public int Day { get; }
		public int Month { get; }
		public int Year { get; }

		#region Contructors

		public Calendar()
		{
			DateTime _date = DateTime.Now;
			Day = _date.Day;
			Month = _date.Month;
			Year = _date.Year;
		}

		public Calendar(DateTime date)
		{
			Day = date.Day;
			Month = date.Month;
			Year = date.Year;
		}

		public Calendar(int day, int month, int year)
		{
			Day = day;
			Month = month;
			Year = year;
		}

		public Calendar(string date, string format)
		{
			DateTime _date = System.DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
			Day = _date.Day;
			Month = _date.Month;
			Year = _date.Year;
		}

		#endregion

		/// <summary>
		/// Checks if the date is valid
		/// </summary>
		public bool IsValid
		{
			get
			{
				if (Year < 1 || Year > 9999)
					return false;
				if (Month < 1 || Month > 12)
					return false;
				return Day > 0 && Day <= DaysInMonth;
			}
		}

		/// <summary>
		/// Checks if the year is leap
		/// </summary>
		public bool IsLeap
		{
			get
			{
				if (Year % 4 == 0)
				{
					if (Year % 100 == 0)
					{
						if (Year % 400 == 0)
							return true;
						return false;
					}
					return true;
				}
				return false;
			}
		}

		/// <summary>
		/// Returns number of days in month
		/// </summary>
		public int DaysInMonth
		{
			get
			{
				switch (Month)
				{
					case 1:
					case 3:
					case 5:
					case 7:
					case 8:
					case 10:
					case 12:
						return 31;
					case 4:
					case 6:
					case 9:
					case 11:
						return 30;
					case 2:
						if (IsLeap)
							return 29;
						return 28;
					default:
						return 0;
				}
			}
		}

		/// <summary>
		/// Returns DateTime type of this object
		/// </summary>
		public DateTime DateTime
		{
			get
			{
				if (IsValid)
					return new DateTime(Year, Month, Day);
				return new DateTime();
			}
		}

		/// <summary>
		/// Returns days of week of current date,
		/// 0 for Sunday, 1 for Monday,...
		/// </summary>
		public int DaysOfWeek
		{
			get
			{
				int[] arr = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
				int _year = Year - ((Month < 3) ? 1 : 0);
				return (_year + _year / 4 - _year / 100 + _year / 400 + arr[Month - 1] + Day) % 7;
			}
		}

		/// <summary>
		/// Returns days of week of current date
		/// </summary>
		public string DaysOfWeek2
		{
			get
			{
				return ((DayOfWeek)DaysOfWeek).ToString();
			}
		}

		#region Methods

		/// <summary>
		/// Formats date string from format string
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public string FormatDate(string format)
		{
			try
			{
				return DateTime.ToString(format);
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// Using FormatDate method instead
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "Using FormatDate method instead";
		}

		/// <summary>
		/// Returns list of days of current date
		/// </summary>
		public List<int> GetMonthArray()
		{
			List<int> month = new List<int>();
			int daysOfWeek = DaysOfWeek;

			return month;
		}
		#endregion

	}
}
