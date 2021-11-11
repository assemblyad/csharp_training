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
            ProjectData projectData = new ProjectData("Project Namee", "Project Descriptione");
            app.LeftMenu.ProjectManagementTab.Project.VerifySameProjectPresence(projectData);

            List<ProjectData> oldProjects = app.LeftMenu.ProjectManagementTab.Project.GetAllProjectList();

            app.LeftMenu.ProjectManagementTab.Project.Creation(projectData);
            Assert.AreEqual(oldProjects.Count + 1, app.LeftMenu.ProjectManagementTab.Project.GetProjectCount());

            List<ProjectData> newProjects = app.LeftMenu.ProjectManagementTab.Project.GetAllProjectList();
            oldProjects.Add(projectData);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects.Count, newProjects.Count);
            Assert.AreEqual(newProjects, newProjects);
        }
    }
}
