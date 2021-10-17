using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    public class NavigationHelper: HelperBase
    {
        private readonly string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL): base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToContactHomePage()
        {
            if(driver.Url == baseURL + "/addressbook/" && IsElementPresent(By.Name("add")))
            {
                return;
            }
                driver.FindElement(By.LinkText("home page")).Click();
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL +"/addressbook/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
