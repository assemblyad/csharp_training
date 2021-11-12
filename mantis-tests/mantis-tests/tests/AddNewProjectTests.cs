using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mantis_tests
{
    //[TestFixture]
    public class AddNewProjectTests: ProjectManagementTabBase
    {
        [Test]
        public void AddNewProjectTest()
        {
            //List<AccountData> accounts = app.Admin.GetAllAccounts();
            //AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

            ProjectData projectData = new ProjectData("Project Namee", "Project Descriptione");
            app.LeftMenu.ProjectManagementTab.Project.VerifySameProjectPresence(projectData);

            //List<ProjectData> oldProjects = app.LeftMenu.ProjectManagementTab.Project.GetAllProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectsList();

            app.LeftMenu.ProjectManagementTab.Project.Creation(projectData);
            Assert.AreEqual(oldProjects.Count + 1, app.LeftMenu.ProjectManagementTab.Project.GetProjectCount());

            //List<ProjectData> newProjects = app.LeftMenu.ProjectManagementTab.Project.GetAllProjectList();
            List<ProjectData> newProjects = app.API.GetProjectsList();
            oldProjects.Add(projectData);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects.Count, newProjects.Count);
            Assert.AreEqual(newProjects, newProjects);
        }
    }
}
