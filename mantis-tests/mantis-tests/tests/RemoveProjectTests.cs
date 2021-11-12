using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mantis_tests
{
    //[TestFixture]
    public class DeleteProjectTests : ProjectManagementTabBase
    {
        [Test]
        public void RemoveProjectTest()
        {
            List<ProjectData> oldProjects = app.API.GetProjectsList();
            ProjectData projectToBeremoved = oldProjects[0];
            if (projectToBeremoved == null)
            { 
               //ProjectData projectData = new ProjectData("Project Namee", "Project Descriptione");
                //app.LeftMenu.ProjectManagementTab.Project.VerifySameProjectPresence(projectData);
                //app.LeftMenu.ProjectManagementTab.Project.Creation(projectData);
                app.API.ProjectCreation();
            }
            //List<ProjectData> oldProjects = app.LeftMenu.ProjectManagementTab.Project.GetAllProjectList();




            app.LeftMenu.ProjectManagementTab.Project.Remove(projectToBeremoved);
            Assert.AreEqual(oldProjects.Count - 1, app.LeftMenu.ProjectManagementTab.Project.GetProjectCount());

            //List<ProjectData> newProjects = app.LeftMenu.ProjectManagementTab.Project.GetAllProjectList();
            List<ProjectData> newProjects = app.API.GetProjectsList();

            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
            
            /*
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.ID, contactToBeRemoved.ID);
            }
            */
        }
    }
}