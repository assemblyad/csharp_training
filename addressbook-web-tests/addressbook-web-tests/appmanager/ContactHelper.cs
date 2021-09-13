using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager): base(manager)
        {
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;

        }

        public ContactHelper FillContactForm(Contact contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper InitCreateContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        internal void Creation()
        {
            manager.Navigator.GoToHomePage();
            InitCreateContact();
            FillContactForm(new Contact("F", "L"));
            SubmitContactCreation();
            manager.Navigator.GoToContactHomePage();
        }
    }
}
