using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAdressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactDetails;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        [Column(Name = "id"),PrimaryKey,Identity]
        public string ID { get; set; }
        [Column(Name = "firstname")] 
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set;}
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string HomePage { get; set; }
        public string SecondAddress { get; set; }
        public string SecondHomePhone { get; set; }
        public string Notes { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }
        public string BAge { get; set; }
        public string AAge { get; set; }

        [Column(Name = "deprecated")]
        public string Depricated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x => x.Depricated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        public string AllContactDetails
        {
            get {
                if (allContactDetails != null)
                { 
                    return allContactDetails;
                }
                else
                {
                    return (EndLineSymbols(EndLineSymbols(ContactDetailsList(
                        FirstName, MiddleName, LastName, NickName, Title, Company, Address)))
                        + EndLineSymbols(EndLineSymbols(GetTelephoneList(HomePhone, MobilePhone, WorkPhone, Fax)))
                        + EndLineSymbols(EndLineSymbols(GetEmailList(Email1, Email2, Email3, HomePage)))
                        + StartLineSymbols(SecondAddress)
                        + EndLineSymbols(StartLineSymbols(StartLineSymbols(StringPhone2(SecondHomePhone))))
                        + StartLineSymbols(Notes)).Trim();
                }
                
            }

            set { allContactDetails = value; }
        }

        public string AllPhones {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone))+CleanUp(SecondHomePhone).Trim();
                }
            }
            set {
                allPhones = value;
            }
        }

        //public string ()

        public string AllEmails
        {
            get{
                if((allEmails != null))
                {
                    return allEmails;
                }
                else
                {
                    return (EndLineSymbols(Email1) + EndLineSymbols(Email2) + EndLineSymbols(Email3)).Trim();
                }
            }

            set { allEmails = value; }
        }
        //Glue the lines together to match tge contact details   fullname as on the details form
        public string GetFullName(string firstname, string middlename, string lastname)
        {
            string form = "";

            if (firstname != null && firstname != "")
            {
                form = FirstName + " ";
            }
            if (middlename != null && middlename != "")
            {
                form = form + MiddleName + " ";
            }
            if (lastname != null && lastname != "")
            {
                form = form + LastName + " ";
            }
            return form.Trim();
        }
        public string EndLineSymbols(string line)
        {
            if (line == null || line == "")
            {
                return "";
            }
            return line + "\r\n";
        }
        public string StartLineSymbols(string line)
        {
            if (line == null || line == "")
            {
                return "";
            }
            return "\r\n" + line;
        }

        // Glue the lines together same as on contact details form
        public string ContactDetailsList(
                  string firstname,
                  string middlename,
                  string lastname,
                  string nickname,
                  string title,
                  string company,
                  string address)
        {
            return (EndLineSymbols(GetFullName(firstname, middlename, lastname))
                + EndLineSymbols(nickname)
                + EndLineSymbols(title)
                + EndLineSymbols(company)
                + EndLineSymbols(address)).Trim();
        }
        // Glue the lines together for telephone list as on the details form
        public string GetTelephoneList(string home, string mobile, string work, string fax)
        {
            string form = "";

            if (home != null && home != "")
            {
                form = form + "H: " + EndLineSymbols(HomePhone);
            }
            if (mobile != null && mobile != "")
            {
                form = form + "M: " + EndLineSymbols(MobilePhone);
            }
            if (work != null && work != "")
            {
                form = form + "W: " + EndLineSymbols(WorkPhone);
            }
            if (fax != null && fax != "")
            {
                form = form + "F: " + EndLineSymbols(Fax);
            }
            return form.Trim();
        }

        // Glue the lines together for email list on contact details form
        public string GetEmailList(string email, string email2, string email3, string homepage)
        {
            string form = "";

            if (email != null && email != "")
            {
                form = form + EndLineSymbols(email);
            }
            if (email2 != null && email2 != "")
            {
                form = form + EndLineSymbols(email2);
            }
            if (email3 != null && email3 != "")
            {
                form = form + EndLineSymbols(email3);
            }
            if (homepage != null && homepage != "")
            {
                form = form + EndLineSymbols(StringHomePage(homepage));
            }
            return form.Trim();
        }

        //Returns'homepage' as on the contact details form
        public string StringHomePage(string homepage)
        {
            if (homepage == null || homepage == "")
            {
                return "";
            }
            return "Homepage:" + "\r\n" + homepage;
        }

        // Retunrs 'SecondHomePhone' as on the contact details form
        public string StringPhone2(string phone2)
        {
            if (phone2 == null || phone2 == "")
            {
                return "";
            }
            return "P: " + SecondHomePhone;
        }

        public string CleanUp(string phone)
         {
             if (phone == null || phone == "")
             {
                 return "";
             }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
         }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compResult = this.LastName.CompareTo(other.LastName);

            if (compResult!=0)
            {
                return compResult;
            }
            else
            {
                return LastName.CompareTo(other.LastName);
            }
            
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }

        override public int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }
/*
        public override string ToString()
        {
            return "First name = " + FirstName + " Last name = " + LastName;
        }
*/
        public override string ToString()
        {
            return "firstname = " + FirstName
                + "\nlastname = " + LastName
                + "\nmiddlename = " + MiddleName
                + "\nnickname = " + NickName
                + "\ntitle = " + Title
                + "\ncompany = " + Company
                + "\naddress = " + Address
                + "\nhomePhone = " + HomePhone
                + "\nmobilePhone = " + MobilePhone
                + "\nworkPhone = " + WorkPhone
                + "\nfax = " + Fax
                + "\nemail = " + Email1
                + "\nemail2 = " + Email2
                + "\nemail3 = " + Email3
                + "\nhomepage = " + HomePage
                + "\naddress2 = " + SecondAddress
                + "\nphone2 = " + SecondHomePhone
                + "\nnotes = " + Notes;
        }

    }
}