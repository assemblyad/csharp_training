using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;

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
            Tree tree = dialogue.Get<Tree>("");

            TreeNode root = tree.Nodes[0];

            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text

                });
            }
            CloseGroupsDialogue(dialogue);
            return new List<GroupData>();
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue  = OpenGroupsDialogue();
            dialogue.Get<Button>("").Click();

            
            //aux.Send(newGroup.Name);
            //aux.Send("{ENTER}");
            CloseGroupsDialogue(dialogue);    
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("").Click();
            
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}