using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux; 
        private GroupHelper groupHelper;
        
        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"C:\Users\ademidionok\source\repos\csharp_training\FreeAddressBookPortable\AddressBook.exe","",aux.SW_SHOW);
            WinWaitAndActivate(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        private void WinWaitAndActivate(string winTitleWindow)
        {
            aux.WinWait(winTitleWindow);
            aux.WinActive(winTitleWindow);
            Aux.WinWaitActive(winTitleWindow);
        }

        public void Stop()
        {
            aux.ControlClick("WINTITLE", "", "WindowsForms10.BUTTON.app.0.2c908d510");

        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
    }
}
