using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace addressbook_tests_white
{
    public class GroupExistenceValidationBaseTest:TestBase
    {
        //[SetUp]
        public void SetUpGroupCreation()
        {
            
            if (app.Groups.IsGroupTableEmpty())
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "white"
                };

                app.Groups.Add(newGroup);
            }

        }
    }
}
