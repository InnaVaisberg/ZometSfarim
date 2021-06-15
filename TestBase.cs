using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Browsers;
using ZometSfarim.Factories;
using ZometSfarim.Loggers;

namespace ZometSfarim
{
	public class TestBase
	{
		protected Application Application { get; set; }
		private bool IsTestRunFailed;
		protected void RunScenario(Action scenario)
		{
			Application = new Application(BrowserFactory.CreateBrowser());
			Application.Browser.DeleteAllCookies();

			try
			{
				scenario();
			}
			catch (Exception exception)
			{
				IsTestRunFailed = true;
				LogTxt.Instance.WriteToLog($"Exception: {exception.Message} Stack trace : {exception.StackTrace}");
			}
			finally
			{
				QuitBrowser(Application.Browser);

				if (IsTestRunFailed)
					Assert.Fail("Test Run Failed!");
			}
		}
		protected void QuitBrowser(Browser browser)
		{
			browser.GetWebDriver()?.Quit();
		}
	}
}
