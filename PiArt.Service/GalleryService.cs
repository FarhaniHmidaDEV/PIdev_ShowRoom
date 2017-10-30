using PiArt.Domain.Entities;

using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiArt.Data.Infrastructure;

namespace PiArt.Service
{
   public class GalleryService : Service<Gallery>,IGalleryService
    {
          private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utk = new UnitOfWork(dbf);
    

        public GalleryService() : base(utk)
        {
        }
       public IEnumerable<Gallery> ListSorted( )
        {
            return utk.getRepository<Gallery>().GetAll().OrderBy(o => o.Price);
           
          
        }
       
    }
}
