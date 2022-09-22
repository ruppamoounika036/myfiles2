using System;
using System.Collections.Generic;

namespace Assign_2.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Iname { get; set; } = null!;
        public decimal Iprice { get; set; }
        public int Iquant { get; set; }
        public bool Idiscount { get; set; }
        public decimal? Isubtotal { get; set; }
        public int Oid { get; set; }

        public virtual Order OidNavigation { get; set; } = null!;
    }
}
