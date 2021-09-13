using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    public class LoginHelper:HelperBase
    {
        public LoginHelper(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }
        public void Login(AcccountData acccount)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(acccount.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(acccount.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

    }
}
