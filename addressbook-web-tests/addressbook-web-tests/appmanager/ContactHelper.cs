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

        private List<ContactData> contactCache = null; 

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElements(By.TagName("td"))[2].Text,
                                                 element.FindElements(By.TagName("td"))[1].Text)
                    {ID= element.FindElement(By.XPath("//tr[@name='entry']//input")).GetAttribute("value")});
                }

            }
            return new List<ContactData>(contactCache);
        }

        internal int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;

        }

        public ContactHelper FillContactForm(ContactData contact)
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
            FillContactForm(new ContactData("FM", "LM"));
            SubmitContactCreation();
            manager.Navigator.GoToContactHomePage();
            return this;
        }
        public ContactHelper Modify(int index)
        {
            manager.Navigator.GoToHomePage();
            ContactSlection(index);
            Modify();
            FillContactForm(new ContactData("FO", "LO"));
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            manager.Navigator.GoToContactHomePage();
            return this;
        }

        public ContactHelper Removal(int index)
        {
            manager.Navigator.GoToHomePage();
            ContactSlection(index);
            DeteteButton();
            closePopUpwindow();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper ContactSlection(int index)
        {
            //driver.FindElement(By.XPath("//tbody/tr[2]/td[1]")).Click();
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper Modify()
        {
            driver.FindElement(By.XPath("//tbody/tr[2]/td[8]/a[1]/img[1]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper DeteteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public bool IsContactTableEmpty()
        {
            manager.Navigator.GoToHomePage();
            return (driver.FindElements(By.XPath("//table[@id='maintable']//tr")).Count <= 1);
        }
    }
}
