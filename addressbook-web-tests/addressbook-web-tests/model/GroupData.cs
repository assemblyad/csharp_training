﻿using System;

namespace WebAdressbookTests
{
    public class GroupData: IEquatable<GroupData> , IComparable<GroupData>
    {
        public GroupData()
        {

        }
        public GroupData(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public string Header { get; set; }
        
        public string Footer { get; set; }

        public string ID { get; set; } 

        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name.Equals(other.Name);
        }

        override public int GetHashCode()
        {
            return Name.GetHashCode();
        }

        override public string ToString()
        {
            return "name=" + Name + "\nheader = " + Header+ "\nfooter = "+Footer;
        }
    }
}
