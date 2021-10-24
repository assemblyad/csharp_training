using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    
    public class GroupExistenceValidationBaseTest: GroupTestBase
    {
        [SetUp]
        public void SetUpGroupCreation()
        {
            if (app.Groups.IsGroupTableEmpty())
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                app.Groups.Create(group);
            }

            
        }
    }
}
