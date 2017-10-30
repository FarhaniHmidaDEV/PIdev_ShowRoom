using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Domain.Entities
{
    public class Deal
    {
        [Key]
        public int DealId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set;  }
        public string NomArtiste { get; set;  }
    }
}
