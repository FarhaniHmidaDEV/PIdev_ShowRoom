using PiArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiArt.Models
{
    public class RentViewModel
    {
        public int RentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public State State { get; set; }
        public string DescriptionRent { get; set; }



        public int GalleryId { get; set;  }
        public IEnumerable<SelectListItem> gallerys{ get; set; }
        public virtual User user { get; set; }
        public int? UserId { get; set; }
        public IEnumerator<RentViewModel> GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}