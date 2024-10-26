using System;
using System.Collections.Generic;

namespace SE171089_BusinessObject
{
    public partial class Rent
    {
        public Rent()
        {
            RentDetails = new HashSet<RentDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? TotalQuatity { get; set; }
        public DateTime? RentTime { get; set; }
        public DateTime? ReturnTime { get; set; }

        public virtual Account User { get; set; } = null!;
        public virtual ICollection<RentDetail> RentDetails { get; set; }
    }
}
