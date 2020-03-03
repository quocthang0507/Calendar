using System;
using CalendarLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarLib.Tests
{
	[TestClass()]
	public class UnitTest1
	{
		Calendar calendar = new Calendar(3, 3, 2020);

		[TestMethod()]
		public void Test01()
		{
			Assert.AreEqual("Tuesday", calendar.DaysOfWeek2);
		}

		[TestMethod()]
		public void Test02()
		{
			Assert.AreEqual("03/03/2020", calendar.FormatDate("dd/MM/yyyy"));
		}
	}
}
