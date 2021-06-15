using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZometSfarim.Browsers;
using ZometSfarim.Domains;

namespace ZometSfarim
{
	public class Application
	{
		public Browser Browser { get; }
		public GoogleDomain GoogleDomain { get; }
		public BooknetDomain BooknetDomain { get; }
		public Application(Browser browser)
		{
			Browser = browser;
			GoogleDomain = new GoogleDomain(this);
			BooknetDomain = new BooknetDomain(this);
		}
	}
}
