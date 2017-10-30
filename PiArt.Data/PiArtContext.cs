using PiArt.Data.CustumConventions;
using PiArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace PiArt.Data
{
    public class PiArtContext : DbContext  

    {
        public PiArtContext(): base("name=MyDataBaseConnction")
        {

        }
      
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Deal> Deals { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Conventions.Add(new DateTime2Convention());
        }
    }
}
