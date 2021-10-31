using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    class AddingContactToGroupTests:AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            GroupData group = groups[0];

            List<ContactData> oldList = ContactData.GetAll();
            ContactData contact = oldList[0];

            if(contact == null)
            {
                app.Contacts.Creation(new ContactData("FF", "LL"));
                oldList = ContactData.GetAll();
                contact = oldList[0];
            }

            if (group == null)
            {
                group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                app.Groups.Create(group);
                group = GroupData.GetAll()[0];
            }
            else
            {
                int numberOfGroups = groups.Count();
                for (int i= 0; i< numberOfGroups; i++)
                {
                    group = groups[i];
                    oldList = group.GetContacts();
                    try 
                    { 
                        contact = ContactData.GetAll().Except(oldList).First();
                        break;
                    }
                    catch(ArgumentNullException ex)
                    {
                        if ((numberOfGroups-1) == i)
                        {
                            app.Contacts.Creation(new ContactData("FF", "LL"));
                            contact = ContactData.GetAll()[0];
                        }
                    }
                }
            }

            //group = GroupData.GetAll()[0];
            //List<ContactData> oldList = group.GetContacts();
            //ContactData contact = ContactData.GetAll().Except(oldList).First();
            //actions 
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
