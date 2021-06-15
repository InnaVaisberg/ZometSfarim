using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZometSfarim.Browsers;

namespace ZometSfarim.Pages
{
	public class BooknetProductsPage : PageBase
	{
		Browser Browser;
		public BooknetProductsPage(Browser browser) : base(browser) { Browser = browser; }

		public void AddProductsToSal(int productsCount)
		{
			
			var productContainer = Browser.WaitForElement(By.CssSelector(".row.products-cubes-row-container"), "row products-cubes-row-container");
			var products = productContainer.FindElements(By.CssSelector(".products.product-cube.col-md-2"), "products product-cube col-md-2");
			for (int i = 0; i <= productsCount; i++)
			{
				products.ElementAt(i).WaitForElement(By.CssSelector(".btn.cart-btn2.blue"), "buy btn 'btn cart-btn2 blue'").Click();
                Thread.Sleep(5000);//TO DO
				var modalPopup = Browser.WaitForElement(By.ClassName("modal-body"), "modal-body");
				if ((i++) < productsCount)
					ActAndHandleStaleElementReferenceException(() =>
					{
						modalPopup.WaitForElement(By.TagName("button"), "button - continue to buy").Click();
					});

				else
					ActAndHandleStaleElementReferenceException(() => {
					modalPopup.WaitForElement(By.TagName("a"), "a hyper link - goto pay").Click();
			        });
                
			}
			
		}
	}
}
   