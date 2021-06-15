using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZometSfarim.Browsers
{
	class ChromeBrowser : Browser
	{
		public ChromeBrowser()
			: base(GetDriver())
		{
		}

		public static IWebDriver GetDriver()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--no-sandbox-and-elevated");
			options.AddArguments("--start-maximized");
			options.AddArguments("--disable-infobars");
			options.AddArguments("--disable-notifications");
			options.AddArguments("--disable-gpu");
			options.AddArguments("--disable-dev-shm-usage");
			var driverService = ChromeDriverService.CreateDefaultService();
			return new ChromeDriver(driverService, options, TimeSpan.FromSeconds(180));
		}
	
	}
}
