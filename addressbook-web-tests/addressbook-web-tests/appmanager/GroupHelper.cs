﻿using OpenQA.Selenium;
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

        public GroupHelper Remove()
        {
            manager.Navigator.GoToGroupsPage();
            
            if (IsGroupTableEmpty())
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                Create(group);
            }
            SelectGroupPage(1);
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
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
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

        public GroupHelper Modify(GroupData group, int index)
        {
            manager.Navigator.GoToGroupsPage();
            if (IsGroupTableEmpty())
            {
                GroupData groupNew = new GroupData("name");
                groupNew.Header = "header";
                groupNew.Footer = "footer";
                Create(group);
            }
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
            driver.FindElement(By.XPath("//input[@name ='selected[]'][@value='" + index + "']")).Click();
            return this;
        }

        public GroupHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public bool IsGroupTableEmpty()
        {
            return driver.FindElements(By.XPath("//div[@id='content']//span[@class='group']")).Count <1;
        }
    }
}
