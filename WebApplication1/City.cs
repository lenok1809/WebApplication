using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication1
{
    public partial class City
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        
        [Display(Name = "Назва міста")]
        public string Name { get; set; }
        public int? CountryId { get; set; }
        [Display(Name = "Назва країни")]
        public virtual Country Country { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
