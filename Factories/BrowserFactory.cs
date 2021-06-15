using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Browsers;

namespace ZometSfarim.Factories
{
	public abstract class BrowserFactory
	{
		public static Browser CreateBrowser(bool proxy = false)
		{
			var browserName = "Chrome";		
			return GetBrowser();					
		}

		private static Browser GetBrowser()
		{
			return new ChromeBrowser();		
		}		
	}
}
