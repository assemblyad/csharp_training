using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    class AddNewIssueTests: TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectData = new ProjectData()
            {
                Id = "[All Projects] General"
            };


            IssueData issueData = new IssueData()
            {
                Summary = "some text",
                Description = "some long test",
                Catergory = "1"
            };
            app.API.CreateNewIssue(account, issueData, projectData);

        }
    }
}
