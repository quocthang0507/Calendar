using CalendarLib;
using System;

namespace CalendarConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintYearCalendar();
			Console.ReadKey();
		}

		static void PrintMonthCalendar(int month, int year)
		{
			Calendar calendar = new Calendar(1, month, year);
			var arr = calendar.GetMonthArray();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\t" + calendar.MonthName + "\t-\t" + calendar.Year);
			Console.ForegroundColor = ConsoleColor.Red;
			for (int i = 0; i < 7; i++)
				Console.Write(((DayOfWeek)i).ToString().Substring(0, 3) + "\t");
			Console.ForegroundColor = ConsoleColor.Yellow;
			for (int i = 0; i < 6; i++)
			{
				Console.WriteLine();
				for (int j = 0; j < 7; j++)
				{
					if (arr[i, j] == 0)
						Console.Write("\t");
					else
						Console.Write(arr[i, j] + "\t");
				}
			}
			Console.WriteLine();
		}

		static void PrintYearCalendar()
		{
			for (int i = 1; i <= 12; i++)
			{
				PrintMonthCalendar(i, DateTime.Now.Year);
			}
		}

	}
}
