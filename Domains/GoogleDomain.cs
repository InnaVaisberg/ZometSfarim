using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Pages;

namespace ZometSfarim.Domains
{
	public class GoogleDomain : BaseDomain
	{	
		public GoogleDomain(Application application):base(application)
		{		
		}

		public void Serch(string keyword)
		{
			var page = new GooglePage(Application.Browser);
			page.Search(keyword);
		}
		public void NavigateToGoogle()
		{
			var page = new GooglePage(Application.Browser);
			page.OpenGoogle();
		}
	}
}
