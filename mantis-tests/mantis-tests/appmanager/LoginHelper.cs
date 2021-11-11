using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper:HelperBase
    {
        public LoginHelper(ApplicationManager manager):base(manager)
        {
        }
        public void Login(AccountData acccount)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(acccount))
                {
                    return;
                }
                LogOut();
            }
            Type(By.Name("username"), acccount.Name);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click(); //administrator root
            Type(By.Name("password"), acccount.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click(); //administrator root
        }
        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user"));
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && GetLggetUserName() == account.Name;
        }

        private string GetLggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            //== string.Format("({0})", account.Username);
            return text.Substring(1, text.Length - 2);
        }
    }
}
