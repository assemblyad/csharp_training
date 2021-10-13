using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    [TestFixture]
    class ContactDetailsTest: AuthTestBase
    {
        [Test]
        public void ContactDetailsDataValidationTest()
        {
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetailsForm = app.Contacts.GetContactDetailsFromDeatailsForm(0);

            //validate details
            Assert.AreEqual(fromEditForm.AllContactDetails.ToUpper(), fromDetailsForm.AllContactDetails.ToUpper());

        }
    }
}
