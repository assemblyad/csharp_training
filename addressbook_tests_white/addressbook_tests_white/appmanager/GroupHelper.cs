using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper: HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager): base(manager) { }

        public List<GroupData> GetGroupsList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");

            TreeNode root = tree.Nodes[0];

            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text

                });
            }
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue  = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);


            //aux.Send(newGroup.Name);
            //aux.Send("{ENTER}");
            CloseGroupsDialogue(dialogue);    
        }

        public void Remove(GroupData newGroup)
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            //dialogue.Get<Button>("uxNewAddressButton").Click();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");

            TreeNode root = tree.Nodes[0];

            foreach (TreeNode item in root.Nodes)
            {
                if (newGroup.Name== item.Name)
                {
                    item.Click();
//                    TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
//                    textBox.Enter(newGroup.Name);
                    
                    
                    Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

                    dialogue.Get<Button>("uxDeleteAddressButton").Click();
                    dialogue.Get<Button>("uxOKAddressButton").Click();
                    break;
                }
            }

            //aux.Send(newGroup.Name);
            //aux.Send("{ENTER}");
            CloseGroupsDialogue(dialogue);
        }


        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
            
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public bool IsGroupTableEmpty()
        {
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            return tree.Nodes.Count>0;
        }
    }
}