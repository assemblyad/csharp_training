using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementTabHelper : HelperBase
    {
        private string baseManageProjectUrl;
        private ProjectHelper projectHelper;
        public ProjectManagementTabHelper(LeftManagementMenuHelper managementMenuHelper, string baseManageProjectUrl): base(managementMenuHelper)
        {
            this.baseManageProjectUrl = baseManageProjectUrl;
            projectHelper = new ProjectHelper(managementMenuHelper);
        }

        public void ManageProjects()
        {
            if (driver.Url == baseManageProjectUrl + "/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseManageProjectUrl + "/manage_proj_page.php");
        }

        public ProjectHelper Project
        {
            get { return projectHelper; }
        }


    }
}
