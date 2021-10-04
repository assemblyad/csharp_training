using System;

namespace WebAdressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string ID { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set;}

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
            return Firstname == other.Firstname && Lastname == other.Lastname;
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