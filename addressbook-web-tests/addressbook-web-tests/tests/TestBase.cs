﻿using NUnit.Framework;
using System;
using System.Text;

namespace WebAdressbookTests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_GROUPS_CHECKS = true;
        public static bool PERFORM_LONG_UI_CONTACTS_CHECKS = true;
        protected ApplicationManager app;
        public static Random rnd = new Random();
        [SetUp]
        public void SetUpApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for(int i =0; i<l; i++)
            {
                builder.Append(Convert.ToChar(65+ Convert.ToInt32(rnd.NextDouble() * 25)));
            }
            
            return builder.ToString();
        }
    }
}
