using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests

{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager): base(manager)
        {
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroupPage();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper RemoveGroupPage()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SelectGroupPage(int index)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]']["+(index+1)+"]")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            Edit();
            FillGroupForm(group);
            Update();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Edit()
        {
            driver.FindElement(By.XPath("//input[@name='edit']")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//input[@name ='selected[]'][" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public bool IsGroupTableEmpty()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.XPath("//div[@id='content']//span[@class='group']")).Count <1;
        }
    }
}
