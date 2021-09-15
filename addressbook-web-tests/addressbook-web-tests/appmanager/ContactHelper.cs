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

        public ContactHelper Creation()
        {
            manager.Navigator.GoToHomePage();
            InitCreateContact();
            FillContactForm(new Contact("F", "L"));
            SubmitContactCreation();
            manager.Navigator.GoToContactHomePage();
            return this;
        }
        public ContactHelper Modify(int index)
        {
            manager.Navigator.GoToHomePage();
            ContactSlection(index);
            Edit(index);
            FillContactForm(new Contact("FF", "LL"));
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            manager.Navigator.GoToContactHomePage();
            return this;
        }

        public ContactHelper Removal(int index)
        {
            manager.Navigator.GoToHomePage();
            ContactSlection(index);
            Edit(index);
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper ContactSlection(int index)
        {
            driver.FindElement(By.Id("" + index + "")).Click();
            return this;
        }
        public ContactHelper Edit(int index)
        {
             driver.FindElement(By.XPath("//a[@href='edit.php?id=" + index + "']")).Click();
            return this;
        }
    }
}
