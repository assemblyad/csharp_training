namespace WebAdressbookTests
{
    public class Contact
    {
        private string firstname;
        private string lastname;

        public Contact(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }


    }
}