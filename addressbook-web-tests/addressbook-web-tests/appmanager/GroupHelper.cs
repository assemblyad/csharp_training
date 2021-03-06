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

        private List<GroupData> groupCache = null;

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.ID);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach(IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null) {
                        ID=element.FindElement(By.TagName("input")).GetAttribute("value")});
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string [] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i=0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i-shift].Trim();
                    }
                    
                }
            }
            return new List<GroupData>(groupCache);
        }

        

        internal int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
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
            groupCache = null;
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
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
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Modify(String id, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(id);
            Edit();
            FillGroupForm(group);
            SubmitGroupModification();
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

        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("//input[@name ='selected[]' and @value='"+id+"']")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        public bool IsGroupTableEmpty()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.XPath("//div[@id='content']//span[@class='group']")).Count <1;
        }
    }
}
