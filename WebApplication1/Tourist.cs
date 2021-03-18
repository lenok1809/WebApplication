using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class Tourist
    {
        public Tourist()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public int? Number { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
