using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Domain.Entities
{
   public  class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// Image Name
        /// </summary>



        //prop de navigation 
        public virtual ICollection<Rent> Rents { get; set; }
        public int? UserId { get; set; }




    }
}
