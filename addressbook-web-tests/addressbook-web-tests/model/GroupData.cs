using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAdressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData: IEquatable<GroupData> , IComparable<GroupData>
    {
        public GroupData()
        {

        }
        public GroupData(string name)
        {
            Name = name;
        }
        [Column(Name = "group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header")]
        public string Header { get; set; }
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"),PrimaryKey, Identity]
        public string ID { get; set; } 

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

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
