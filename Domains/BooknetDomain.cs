using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Pages;

namespace ZometSfarim.Domains
{
	public class BooknetDomain : BaseDomain
	{
		public BooknetDomain(Application application) : base(application) { }

		public void GoToCategory(int category)
		{
			var page = new BooknetPage(Application.Browser);
			page.GoToCategory(category);
		}
		public void AddProductsToSal(int productsCount)
		{
			var page = new BooknetProductsPage(Application.Browser);
			page.AddProductsToSal(productsCount);
		}
		public void GoToPay()
		{
			var page = new BooknetProductsCart(Application.Browser);
			page.GoToPay();
		}
		public void SelectShipment()
		{
			var page = new BooknetShoppingCartPage(Application.Browser);
			page.Shipment();
		}
		public void FillClientDetails()
		{
			var page = new BooknetShoppingCartPage(Application.Browser);
			page.FillClientDetails();
		}
		public void FillAddressDetails()
		{
			var page = new BooknetShoppingCartPage(Application.Browser);
			page.FillAddressDetails();
		}
		public void AcceptTermAndConditions()
		{
			var page = new BooknetShoppingCartPage(Application.Browser);
			page.AcceptTermAndConditins();
		}
		public void Pay()
		{
			var page = new BooknetShoppingCartPage(Application.Browser);
			page.PayButton();
		}
	}
}
