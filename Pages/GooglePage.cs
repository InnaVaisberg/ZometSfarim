using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Browsers;

namespace ZometSfarim.Pages
{
	public class GooglePage : PageBase
	{
		new Browser Browser { get; set; }
		public GooglePage(Browser browser) : base(browser)
		{
			Browser = browser;
		}

		public void Search(string keyword)
		{
			var input = Browser.WaitForElement(By.CssSelector(".gLFyf.gsfi"), "Search field");
			input.Text = keyword;
			((IWebElement)input).SendKeys(Keys.Enter);
			var modaot = Browser.FindElements(By.CssSelector(".uEierd"), "uEierd");
			modaot.First().WaitForElement(By.CssSelector(".d5oMvf"), "d5oMvf").WaitForElement(By.TagName("a"),"a hyper link").Click();
		}
		public void OpenGoogle()
		{
			Browser.NavigateToUrl("https://www.google.com");
		}
			
	}
}
