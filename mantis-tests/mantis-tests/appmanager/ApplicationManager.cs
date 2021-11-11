using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        private string baseURL = "http://localhost/mantisbt-2.24.2";
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }

        private LoginHelper loginHelper;
        private LeftManagementMenuHelper navigator;

        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }

        //private ProjectHelper projectHelper;

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            loginHelper = new LoginHelper(this);
            navigator = new LeftManagementMenuHelper(this, baseURL);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                //newInstance.Navigator.GoToHomePage();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }
        
        
        public IWebDriver Driver { get { return driver; } }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }
        public LeftManagementMenuHelper LeftMenu
        {
            get { return navigator; }
        }
    }
}
