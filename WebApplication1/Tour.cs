using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class Tour
    {
        public Tour()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string TourName { get; set; }
        public TimeSpan? TourDuration { get; set; }
        public int? ManegerId { get; set; }
        public int? HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Manager Maneger { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
