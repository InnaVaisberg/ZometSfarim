using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Browsers;

namespace ZometSfarim.Pages
{
	public class BooknetProductsCart : PageBase
	{
		Browser Browser;
		public BooknetProductsCart(Browser browser) : base(browser) { Browser = browser; }

		public void GoToPay()
		{
			Browser.WaitForElement(By.CssSelector(".categoryitems"), "categoryitems").WaitForElement(By.TagName("div"), "div").Click();
		}
	}
}
