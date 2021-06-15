using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Browsers;

namespace ZometSfarim.Pages
{
	public class BooknetPage : PageBase
	{
		new Browser Browser { get; set; }
		public BooknetPage(Browser browser) : base(browser)
		{
			Browser = browser;
		}

		public void GoToCategory(int category)
		{
			OpenAllCategories();
			OpenCategory(category);
			OpenSubCategory(category);
		}
		private void OpenAllCategories()
		{
			var container = Browser.WaitForElement(By.Id("header-inner"), "header-inner");
			container.WaitForElement(By.ClassName("menu"), "menu humburger").Click();
		}
		private void OpenCategory(int category)
		{
			var categoriesContainer = Browser.WaitForElement(By.Id("top-categories"), "top-categories all categories");
			var categories = categoriesContainer.FindElements(By.TagName("li"), "li categries");
			categories.ElementAt(category - 1).Click();
		}
		private void OpenSubCategory(int category)
		{
			var subCategoryContainer = Browser.WaitForElement(By.Id("sub-categories-container"), "sub-categories-container");
			var subCategory = subCategoryContainer.FindElements(By.ClassName("sub-categories-inner"), "sub-categories-inner").ElementAt(category - 1).
				WaitForElement(By.ClassName("sub-cat-title"), "sub-cat-title");
			
			subCategory.WaitForElement(By.TagName("a"), "a hyper link of sub category").Click();
		}
	}
}
