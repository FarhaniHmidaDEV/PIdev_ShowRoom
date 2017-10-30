using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Domain.Entities
{
    public class Rent
    {
        [Key]
        public int RentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public State State { get; set; }
        public string DescriptionRent { get; set; }


        //prop de navigation 
        public int GalleryId { get; set; }
        public virtual Gallery gallery { get; set; }
        public virtual User user {get; set; }
        public int? UserId { get; set;  }
    }
}
