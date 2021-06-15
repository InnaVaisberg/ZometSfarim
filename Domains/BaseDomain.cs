using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZometSfarim.Domains
{
	public abstract class BaseDomain
	{
		protected readonly Application Application;
        protected BaseDomain(Application application)
        {
            Application = application;
            
        }

    }
}
