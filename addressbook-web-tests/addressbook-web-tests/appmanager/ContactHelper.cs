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

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }
        internal ContactData GetContactInformationFromEditForm(int index)
        {
            string bAge="";
            string aAge="";
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bDay = driver.FindElement(By.XPath("//select[@name='bday']//option[@selected='selected']"))
                .GetAttribute("value");

            string bMonth = driver.FindElement(By.XPath("//select[@name='bmonth']//option[@selected='selected']"))
                .GetAttribute("value");
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            //bYear = bYear.Length < 1 ? bYear = "" : bYear;

            if (bYear != "" && bYear.Length>1)
            {
                bAge = GetAge(DateTime.Parse(String.Format("{0}.{1}.{2}", bMonth, bDay, bYear)));
            }
            else
            {
                bDay = "";
                bYear = "";
            }

            string aDay = driver.FindElement(By.XPath("//select[@name='aday']//option[@selected='selected']"))
                .GetAttribute("value");
            string aMonth = driver.FindElement(By.XPath("//select[@name='amonth']//option[@selected='selected']"))
                .GetAttribute("value");
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            if (aYear != "" && aYear.Length>1)
            {
                aAge = GetAge(DateTime.Parse(String.Format("{0}.{1}.{2}", aMonth, aDay, aYear)));
            }
            else
            {
                aDay = "";
                aYear = "";
            }

            string secondAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string secondaryHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                SecondHomePhone = secondaryHomePhone,
                Email1 = email,
                Email2 = email2,
                Email3 = email3,
                BDay = bDay,
                BMonth = bMonth,
                BYear = bYear,
                BAge = bAge,
                ADay = aDay,
                AMonth= aMonth,
                AYear = aYear,
                AAge = aAge,
                MiddleName = middleName,
                NickName = nickName,
                Company = company,
                Title = title,
                Fax = fax,
                HomePage = homePage,
                SecondAddress = secondAddress,
                Notes = notes
            };
            
        }

        internal ContactData GetContactDetailsFromDeatailsForm(int index)
        {
            manager.Navigator.GoToHomePage();
            ContactDetailsSelection(index);
            string allContactDetails = driver.FindElement(By.TagName("div#content")).Text;
            return new ContactData("", "") { AllContactDetails = allContactDetails };
        }


        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElements(By.XPath(".//td"))[2].Text,
                                                        element.FindElements(By.XPath(".//td"))[1].Text)
                    { ID = element.FindElement(By.XPath("//tr[@name='entry']//input")).GetAttribute("value") });

                }
                /*ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElements(By.TagName("td"))[2].Text,
                                                 element.FindElements(By.TagName("td"))[1].Text)
                    {ID= element.FindElement(By.XPath("//tr[@name='entry']//input")).GetAttribute("value")});
                }
                */

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
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
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
            FillContactForm(new ContactData("TT", "MM"));
            SubmitContactCreation();
            manager.Navigator.GoToContactHomePage();
            return this;
        }
        public ContactHelper Modify(int index)
        {
            manager.Navigator.GoToHomePage();
            ContactSelection(index);
            InitContactModification(index);
            FillContactForm(new ContactData("BB", "CC"));
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            manager.Navigator.GoToContactHomePage();
            return this;
        }

        public ContactHelper Removal(int index)
        {
            manager.Navigator.GoToHomePage();
            ContactSelection(index);
            DeteteButton();
            closePopUpwindow();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper ContactSelection(int index)
        {
            //driver.FindElement(By.XPath("//tbody/tr[2]/td[1]")).Click();
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper ContactDetailsSelection(int index)
        {
            //driver.FindElement(By.XPath("//tbody/tr[2]/td[1]")).Click();
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[6]
                  .FindElement(By.TagName("a")).Click();
            return this;
        }


        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[7]
                  .FindElement(By.TagName("a")).Click();
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

        public static string GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age.ToString();
        }
    }
}
