using NUnit.Framework;
using System;
using System.Text;

namespace mantis_tests
{
    public class ProjectManagementTabBase : LeftMenuNavigationBase
    {

        [SetUp]
        public void ManagementProjectsTab()
        {
            app.LeftMenu.ProjectManagementTab.ManageProjects();
        }

    }
}