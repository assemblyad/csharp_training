using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        List<ProjectData> projectCache = null;
        LeftManagementMenuHelper managementMenuHelper;
        public ProjectHelper(LeftManagementMenuHelper managementMenuHelper): base(managementMenuHelper)
        {
            this.managementMenuHelper = managementMenuHelper;
        }

        public List<ProjectData> GetAllProjectList()
        {
            projectCache = new List<ProjectData>();
            ICollection<IWebElement> elements =
            driver.FindElements(By.XPath("//table"))[0].FindElements(By.XPath(".//tbody//tr"));

            foreach (IWebElement element in elements)
            {
                projectCache.Add(new ProjectData(element.FindElements(By.XPath(".//td"))[0].Text,
                                                    element.FindElements(By.XPath(".//td"))[1].Text)
                { Status = element.FindElements(By.XPath(".//td"))[4].Text});

            }
            return new List<ProjectData>(projectCache);
        }

        public ProjectHelper Creation(ProjectData projectData)
        {
            
            InitCreateProject();
            FillProjectForm(projectData);
            SubmitProjectCreation();
            return this;
        }

        public void SubmitProjectCreation()
        {
           driver.FindElement(By.XPath("//input[@type='submit']")).Click();
           Thread.Sleep(5000);
        }

        public void FillProjectForm(ProjectData projectData)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(projectData.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(projectData.Description);
        }

        public void InitCreateProject()
        {
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round']")).Click();
        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.XPath("//table"))[0].FindElements(By.XPath(".//tbody//tr")).Count;
        }

        public void VerifySameProjectPresence(ProjectData project)
        {
            //manager.Navigator.GoToManageProjPage();
            ICollection<IWebElement> allCurrentOpenedProjects = driver.FindElements(By.XPath("//table"))[0].FindElements(By.XPath(".//tbody//tr/td[1]"));
            foreach (IWebElement projectElement in allCurrentOpenedProjects)
            {
                if (projectElement.Text == project.Name)
                {
                    Remove(project);
                    break;
                }
            }

        }
        public void Remove(ProjectData project)
        {
            //manager.Navigator.GoToManageProjPage();
            OpenManageProjEditPage(project.Name);
            RemoveProject();
            SubmitProjectRemoval();
        }
        public void OpenManageProjEditPage(String name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }
        public void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        public void SubmitProjectRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

    }

}