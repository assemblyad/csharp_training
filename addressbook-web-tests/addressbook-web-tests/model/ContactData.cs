using System;

namespace WebAdressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactDetails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set;}
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

        public string AllContactDetails
        {
            get {
                if (allContactDetails != null)
                { 
                    return Cleanup(allContactDetails);
                }
                else
                {
                    string value = Cleanup(Firstname +
                           MiddleName +
                           Lastname +
                           NickName +
                           Title +
                           Company +
                           Address +
                           HomePhone +
                           MobilePhone +
                           WorkPhone +
                           Fax +
                           Email1 +
                           Email2 +
                           Email3 +
                           HomePage +
                           BDay +
                           BMonth +
                           BYear+
                           BAge +
                           ADay +
                           AMonth +
                           AYear +
                           AAge +
                           SecondAddress +
                           SecondHomePhone +
                           Notes);

                    return value;
//                           "\r\n"; 
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
                    return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone))+Cleanup(SecondHomePhone).Trim();
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
                    return (Cleanup(Email1) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }

            }

            set { allEmails = value; }
        }

        public string BAge { get;  set; }
        public string AAge { get;  set; }

        private string Cleanup(string anyStrting)
        {
            if(anyStrting == null || anyStrting == "" )
            {
                return "";
            }

            return anyStrting.Replace(" ", "")
                        .Replace("-", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("Birthday", "")
                        .Replace("Anniversary", "")
                        .Replace("Homepage:","")
                        .Replace("H:", "")
                        .Replace("W:", "")
                        .Replace("F:", "")
                        .Replace(".", "")
                        .Replace("P:", " ")
                        .Replace(":", "")
                        .Replace(" ","")                        
                        .Replace("\r\n", "")
                + "\r\n";
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