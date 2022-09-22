using System;
using System.Collections.Generic;

namespace Assign_2.Models
{
    public partial class Pay
    {
        public int Id { get; set; }
        public decimal? Payable { get; set; }
        public int? Cid { get; set; }
        public int? Oid { get; set; }

        public virtual Customer? CidNavigation { get; set; }
        public virtual Order? OidNavigation { get; set; }
    }
}
