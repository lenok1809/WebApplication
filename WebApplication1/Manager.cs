using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class Manager
    {
        public Manager()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? TourId { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
