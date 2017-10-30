using PiArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiArt.Models
{
    public class UserViewModel
    {
       
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public string UserName { get; set; }
   
        public string Password { get; set; }
        public string UserRole { get; set; }


        //Navigation Prop
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual User user { get; set; }
        public int? UserId { get; set; }
    }
}