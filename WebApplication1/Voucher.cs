using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class Voucher
    {
        public int Id { get; set; }
        public int? TourId { get; set; }
        public int? TouristId { get; set; }
        public int? Price { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
