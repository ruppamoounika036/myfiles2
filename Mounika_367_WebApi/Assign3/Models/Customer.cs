using System;
using System.Collections.Generic;

namespace Assign3.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Pays = new HashSet<Pay>();
        }

        public int Cid { get; set; }
        public string Cname { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Pay> Pays { get; set; }
    }
}
