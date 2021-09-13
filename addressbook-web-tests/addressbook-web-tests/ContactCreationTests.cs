﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreation : TestBase
    {
        [Test]
        public void TheContactCreationTest()
        {
            GoToHomePage();
            Login(new AcccountData("admin", "secret"));
            InitCreateContact();
            FillContactForm(new Contact("F","L"));
            SubmitContactCreation();
            GoToContactHomePage();
        }
    }
}
