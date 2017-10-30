using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PiArt.Models
{
    public class GalleryViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int GalleryId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
   
        public string Address { get; set; }
        public float Price { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        /// <summary>
        /// Image Name
        /// </summary>
       
        public string ImageUrl { get; set; }
        public IEnumerator<GalleryViewModel> GetEnumerator()
        {
            return GetEnumerator();
        }
    

    }
}