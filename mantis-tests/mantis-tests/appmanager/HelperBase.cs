using OpenQA.Selenium;

namespace mantis_tests
{
    public class HelperBase: DriverScriptBase
    {
        //protected IWebDriver driver;
        protected ApplicationManager manager;
        protected LeftManagementMenuHelper LeftManagementMenuHelper;

        public HelperBase(ApplicationManager  manager): base(manager.Driver)
        {
            this.manager = manager;

        }

        public HelperBase(LeftManagementMenuHelper managementMenuHelper): base(managementMenuHelper.driver)
        {
            this.LeftManagementMenuHelper = managementMenuHelper;
            //this.driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClosePopUpwindow()
        {
            driver.SwitchTo().Alert().Accept();
        }

    }
}