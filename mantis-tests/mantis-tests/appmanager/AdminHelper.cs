using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper: HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, string baseUrl): base(manager)
        {
            this.baseUrl = baseUrl;
        }
        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.XPath("//table//tbody//tr"));
            foreach(IWebElement row in rows)
            {
                IWebElement link =row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                accounts.Add(new AccountData(){
                    Name = name, Id = id
                });
            }

            return accounts;
        }
        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id="+account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();
        }

        public IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";
            driver.FindElement(By.Id("username")).SendKeys(adminLogin.Name);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click(); //administrator root
            driver.FindElement(By.Id("password")).SendKeys(adminLogin.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click(); //administrator root
            return driver;
        }
    }
}
