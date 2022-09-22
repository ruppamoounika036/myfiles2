using System;
using System.Collections.Generic;

namespace Assign3.Models
{
    public partial class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
            Pays = new HashSet<Pay>();
        }

        public int Oid { get; set; }
        public string PackageName { get; set; } = null!;
        public int Pincode { get; set; }
        public int Cid { get; set; }
        public int PayMode { get; set; }
        public DateTime Otime { get; set; }

        public virtual Customer CidNavigation { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Pay> Pays { get; set; }
    }
}
