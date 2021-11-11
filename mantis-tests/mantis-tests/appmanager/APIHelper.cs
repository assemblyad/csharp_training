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
        private string baseUrl;

        public void CreateNewIssue(AccountData account, IssueData issueData, ProjectData projectData)
        {
            /*
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Catergory;
            issue.project = new Mantis.ObjectRef();
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


    }
}
