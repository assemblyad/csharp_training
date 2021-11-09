﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper( ApplicationManager manager): base(manager)
        {

        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url);
            SubmitPasswordForm();

        }

        public void SubmitPasswordForm()
        {
            throw new NotImplementedException();
        }

        public void FillPasswordForm(string url)
        {
            throw new NotImplementedException();
        }

        public string GetConfirmationUrl(AccountData account)
        {
            String messsage = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(messsage, @"http://\S*");
            return match.Value;
        }

        public void OpenRegistrationForm()
        {
            driver.FindElement(By.XPath("//a[@class='back-to-login-link pull-left']")).Click(); //CssSelector("back-to-login-link pull-left")
        }

        public void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@value='Signup']")).Click(); //CssSelector("input.submit")
        }

        public void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);

        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.24.2/login_page.php";
        }
    }
}
