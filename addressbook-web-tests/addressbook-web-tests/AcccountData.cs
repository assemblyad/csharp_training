using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    class AcccountData
    {
        private string username;
        private string password;

        public AcccountData(string username, string passowrd)
        {
            this.username = username;
            this.password = passowrd;
        }
        public string Username 
        {
            get 
            {
                return username;
            }

            set
            {
                username = value;
            }
        }


        public string Password
        {
            get 
            { 
            return password;
            }
            set 
            { 
                password = value; 
            }
        }

    }
}
