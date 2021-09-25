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
        public ContactHelper Modify()
        {
            manager.Navigator.GoToHomePage();
            if (IsContactTableEmpty())
            {
                Creation();
            }
            ContactSlection();
            Edit();
            FillContactForm(new Contact("FF", "LL"));
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            manager.Navigator.GoToContactHomePage();
            return this;
        }

        public ContactHelper Removal()
        {
            manager.Navigator.GoToHomePage();

            if (IsContactTableEmpty()) 
            { 
                Creation(); 
            }
            
            ContactSlection();
            DeteteButton();
            closePopUpwindow();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper ContactSlection()
        {
            driver.FindElement(By.XPath("//tbody/tr[2]/td[1]")).Click();
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
            return (driver.FindElements(By.XPath("//table[@id='maintable']//tr")).Count <= 1);
        }
    }
}
