using System;

namespace WebAdressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string ID { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set;}

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }
        
        public string Email3 { get; set; }

        public string AllPhones {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
                }
            }
            set {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get{
                if((allEmails != null))
                {
                    return "";
                }
                else
                {
                    return (Cleanup(Email1) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }

            }

            set { allEmails = value; }
        }

        private string Cleanup(string phone)
        {
            if(phone == null || phone=="")
            {
                return "";
            }

            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compResuld = this.Lastname.CompareTo(other.Lastname);

            if (compResuld!=0)
            {
                return compResuld;
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
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
            return Firstname.Equals(other.Firstname) && Lastname.Equals(other.Lastname);
        }

        override public int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "First name = " + Firstname + " Last name = " + Lastname;
        }

    }
}