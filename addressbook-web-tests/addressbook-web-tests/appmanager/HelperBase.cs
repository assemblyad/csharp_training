using OpenQA.Selenium;

namespace WebAdressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;

        public HelperBase(IWebDriver driver) 
        {
            this.driver = driver;
        }

    }
}