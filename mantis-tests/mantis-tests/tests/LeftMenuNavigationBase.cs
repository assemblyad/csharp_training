using NUnit.Framework;
using System;
using System.Text;

namespace mantis_tests
{
    public class LeftMenuNavigationBase : AuthTestBase
    {

        [SetUp]
        public void ManageOverviewPage()
        {
            app.LeftMenu.ManageOverviewPage();
        }

    }
}