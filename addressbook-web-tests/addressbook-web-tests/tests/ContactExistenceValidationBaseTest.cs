using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    public class ContactExistenceValidationBaseTest: GroupExistenceValidationBaseTest
    {
        [SetUp]
        public void SetUpContactCreation()
        {
            if (app.Contacts.IsContactTableEmpty())
            {
                app.Contacts.Creation(new ContactData("FF","LL"));
            }

        }
    }
}
