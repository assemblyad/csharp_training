using OpenQA.Selenium;

namespace WebAdressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager  manager) 
        {
            this.manager = manager;
            this.driver = manager.Driver;

        }

    }
}