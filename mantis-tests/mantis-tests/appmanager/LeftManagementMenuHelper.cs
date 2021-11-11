using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LeftManagementMenuHelper : HelperBase
    {
        private readonly string baseURL;
        public ProjectManagementTabHelper prjctMngmntHlpr;

        public LeftManagementMenuHelper (ApplicationManager manager, string baseURL): base(manager)
        {
            this.baseURL = baseURL;
            prjctMngmntHlpr = new ProjectManagementTabHelper(this, baseURL);
        }
        public void ManageOverviewPage()
        {
            if (driver.Url == baseURL + "/manage_overview_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_overview_page.php");
        }
        public ProjectManagementTabHelper ProjectManagementTab
        {
            get { return prjctMngmntHlpr; }
        }

        /*
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
        */

    }
}
