using PiArt.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiArt.Data.Infrastructure;
using System.Collections;
using System.Diagnostics;

namespace PiArt.Service
{
    public class RentService : Service<Rent>, IRentService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utk = new UnitOfWork(dbf);

        public RentService() : base(utk)
        {
        }
        public IEnumerable<Gallery> GetAllGalleries()
        {
            return utk.getRepository<Gallery>().GetAll();
        }

       
        public int BestRentGallery()
        {

            IEnumerable<Gallery> galleries = utk.getRepository<Gallery>().GetMany();
            IEnumerable<Rent> rents = utk.getRepository<Rent>().GetMany();


            var results = from a in rents 
                          group a by a.GalleryId into g
                          select new { id = g.Key, Count = g.Count() };


            int b = 0 ;
           
            foreach (var item in results)
            {
                b = item.id;
            }
            return b ; 
        } 
        public List<string> GetByName( )
        {
            GalleryService ga = new GalleryService(); 
            List<Rent> RentList = new List<Rent>();
            List<Gallery> galleryList = new List<Gallery>();
            int x = 0;
            string adr1 , des  = null ;
            DateTime d1 , d2 ; 

            var gal = from m in galleryList
                      join p in RentList on m.GalleryId equals p.GalleryId into ps
                      from i in ps
                      select new { o = i.DescriptionRent , k=i.gallery , 
                      d1 = i.StartDate ,
                      d2 = i.EndDate };
            
            List<String> ls = new List<string>();
            foreach (var item in gal)
            {
               
                adr1 =item.k.Address;
                des = item.o;
                d1 = item.d1;
                d2 = item.d2;
                ls.Add(adr1);
                ls.Add(des);
                ls.Add(""+d1);
                ls.Add("" +d2);


            }


            return ls; 
            
        }
    }
}


