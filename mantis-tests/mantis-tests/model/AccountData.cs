using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
    public class AccountData
    {
        public AccountData() { }
        public AccountData(string username, string passowrd)
        {
            this.Name = username;
            this.Password = passowrd;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}