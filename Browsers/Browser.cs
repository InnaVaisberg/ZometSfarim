using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZometSfarim.Browsers
{
	public abstract class Browser : TestAutomationEssentials.Selenium.Browser
	{

		private IWebDriver _driver;

		private int _timeOut = 5;

		protected Browser(IWebDriver driver) : base("Driver", driver)
		{
			_driver = driver;
			DriverInitialization();
		}
		private void DriverInitialization()
		{
			SetImplicitTimeOut(_timeOut);
			_driver.Manage().Window.Maximize();
		}

		private void SetImplicitTimeOut(int seconds)
		{
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
		}
		public void DeleteAllCookies()
		{
			_driver.Manage().Cookies.DeleteAllCookies();
		}
		public string GetCurrentUrl()
		{
			var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
			return wait.Until(d =>
			{
				try
				{
					return _driver.Url;
				}
				catch (NoSuchWindowException)
				{
					return null;
				}
			});
		}

	}
}
