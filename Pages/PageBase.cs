using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomationEssentials.Common;
using ZometSfarim.Browsers;

namespace ZometSfarim.Pages
{
    public abstract class PageBase
    {
        protected Browser Browser { get; private set; }
        protected PageBase(Browser browser)
        {
        }   
        protected void ActAndHandleStaleElementReferenceException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e) when (EcxeptionsFilter(e))
            {          
                Thread.Sleep(3000);
                action();
            }
        }

        protected T GetTypeAndHandleStaleElementReferenceException<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception e) when (EcxeptionsFilter(e))
            {
                Thread.Sleep(3000);
                return func();
            }
        }

        private static bool EcxeptionsFilter(Exception e)
        {
            return
                e is StaleElementReferenceException ||
                e is WebDriverException ||
                e is InvalidOperationException;
        }

      
    }
}
