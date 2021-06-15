using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZometSfarim.Loggers;

namespace ZometSfarim.Tests
{
	[TestClass]
	public class ZometSfarimScenarios :TestBase
	{
		[TestMethod]
		public void ZometSfarimTest()
		{
			RunScenario(() =>
			{
				LogTxt.Instance.WriteToLog("Try search 'Zomet Sfarim Google page'");
				Application.GoogleDomain.NavigateToGoogle();
				Application.GoogleDomain.Serch("tzomet sfarim");
				Assert.IsTrue(Application.Browser.GetCurrentUrl().Contains("www.booknet.co.il"));

				Application.BooknetDomain.GoToCategory(2);//Mivzaim
				Application.BooknetDomain.AddProductsToSal(2);//Two books
				Application.BooknetDomain.GoToPay();
				Application.BooknetDomain.SelectShipment();
				Application.BooknetDomain.FillClientDetails();
				Application.BooknetDomain.FillAddressDetails();
				Application.BooknetDomain.AcceptTermAndConditions();
				Application.BooknetDomain.Pay();
				Thread.Sleep(5000);
			});
		}
	}
}
