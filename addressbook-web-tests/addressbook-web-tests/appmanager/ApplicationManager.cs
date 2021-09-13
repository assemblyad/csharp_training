using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace WebAdressbookTests
{
    public class ApplicationManager
    {
        private LoginHelper loginHelper;
        private NavigationHelper navigator;
        private GroupHelper groupHelper;
        private ContactHelper contactHelper;
        private string baseURL = "http://localhost";
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            verificationErrors = new StringBuilder();
            //loginHelper.Login(new AcccountData("admin", "secret"));
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);

        }

        public LoginHelper Auth 
        {
            get { return loginHelper; }
        }

        public NavigationHelper Navigator
        {
            get { return navigator; }
        }
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }

        public void stop() 
        {
            LogOut();
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        private void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }


    }
}
