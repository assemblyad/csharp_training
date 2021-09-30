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

        public List<ContactData> GetContactList()
        {
            
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach(IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text.Split(' ')[1],
                                             element.Text.Split(' ')[0]));
            }
            return contacts;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
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
            Edit();
            FillContactForm(new ContactData("FD", "LD"));
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
        public ContactHelper Edit()
        {
             driver.FindElement(By.XPath("//tbody/tr[2]/td[8]/a[1]/img[1]")).Click();
            return this;
        }
        public ContactHelper DeteteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public bool IsContactTableEmpty()
        {
            manager.Navigator.GoToHomePage();
            return (driver.FindElements(By.XPath("//table[@id='maintable']//tr")).Count <= 1);
        }
    }
}
