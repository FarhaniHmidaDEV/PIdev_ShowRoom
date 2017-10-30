using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiArt.Models
{
    public class DealViewModel
    {
        public int DealId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set; }
        public string NomArtiste { get; set; }
    }
}