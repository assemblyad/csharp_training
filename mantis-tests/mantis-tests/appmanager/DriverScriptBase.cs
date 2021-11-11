using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class DriverScriptBase
    {
        protected IWebDriver driver;
        public DriverScriptBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
