using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public void CreateNewIssue(AccountData account, IssueData issueData, ProjectData projectData)
        {
            /*
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Catergory;
            issue.project = new Mantis.ObjectRef(); mc_projects_get_user_accessible
            issue.project.id = projectData.Id;
            */
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Catergory;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = projectData.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public APIHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> list = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(adminLogin.Name, adminLogin.Password);
            foreach (Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData()
                {
                    Name = project.name,
                    Description = project.description
                });
            }
            return list;
        }
        public APIHelper ProjectCreation()
        {
            List<ProjectData> list = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.name = "New Project";
            projectData.description = "New Description";
            client.mc_project_add(adminLogin.Name, adminLogin.Password, projectData);
           
            return this;
        }

        //
    }
}
