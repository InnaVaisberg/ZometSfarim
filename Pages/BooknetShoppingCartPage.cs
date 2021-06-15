using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Browsers;
using ZometSfarim.Models;


namespace ZometSfarim.Pages
{
	public class BooknetShoppingCartPage : PageBase
	{
		Browser Browser;
		public BooknetShoppingCartPage(Browser browser) : base(browser) { Browser = browser; }

		public void FillClientDetails()
		{
            ActAndHandleStaleElementReferenceException(()=>{
                Browser.WaitForElement(By.Id("email"), "email").Text = ClientDetails.Email;
                Browser.WaitForElement(By.Id("customerFirstName"), "customerFirstName").Text = ClientDetails.FirstName;
                Browser.WaitForElement(By.Id("customerLastName"), "customerLastName").Text = ClientDetails.LastName;
                Browser.WaitForElement(By.Id("phone"), "phone").Text = ClientDetails.Phone;
			});
			
		}
		public void FillAddressDetails()
        {
            ActAndHandleStaleElementReferenceException(() =>
            {
                Browser.WaitForElement(By.Id("city"), "city").Text = AddressDetails.City;
                Browser.WaitForElement(By.Id("street"), "street").Text = AddressDetails.Street;
                Browser.WaitForElement(By.Id("homenum"), "homenum").Text = AddressDetails.BuildingNumber;
			});
        }
		public void Shipment()
        {
            ActAndHandleStaleElementReferenceException(() =>
            {
                SelectElement selectShip = new SelectElement(Browser.WaitForElement(By.Id("shipment"), "shipment"));
                selectShip.SelectByValue("1");
			});
			
		}

		public void AcceptTermAndConditins()
		{ 
            var checkBoxes = Browser.FindElements(By.CssSelector(".term-cond.basket-footer-checkbox"), "term-cond basket-footer-checkbox");
			checkBoxes.ElementAt(1).WaitForElement(By.TagName("span"),"span").Click();
		}
		public void PayButton()
		{
			Browser.WaitForElement(By.Id("form-submit-button"), "form-submit-button pay button").Click();
		}
	}
}
