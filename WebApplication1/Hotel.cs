using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class Hotel
    {
        public Hotel()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string HotelName { get; set; }
        public int? Stars { get; set; }
        public int? CityId { get; set; }
        public string RoomType { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
