using PiArt.Domain.Entities;
using System.Threading.Tasks;
using PiArt.Models;
using PiArt.Service;
using Service.Pattern;
using PiArt.Data.Infrastructure; 
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace PiArt.Controllers
{
    public class GalleryController : Controller
    {
        // RentService Re = new RentService(); 
        //  GalleryService Ga = null;
        GalleryService Ga = new GalleryService();
        User u = new User(); 

     


        public GalleryController()
        {
         
        }

        // GET: Gallery
        public async System.Threading.Tasks.Task<ActionResult> Index(String searchString)
        {
            List<GalleryViewModel> GalleryList = new List<GalleryViewModel>();



            foreach (var item in Ga.GetAll())
            {
                GalleryViewModel f = new GalleryViewModel();
                f.GalleryId = item.GalleryId;
                f.Address = item.Address;
                f.ImageUrl = item.ImageUrl;
                f.lat = item.lat;
                f.lng = item.lng;
                f.Price = item.Price;
                f.Name = item.Name;
                GalleryList.Add(f);
            }
            var Galleries = from m in GalleryList
                            select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                Galleries = Galleries.Where(s => s.Address.Contains(searchString)).AsEnumerable();
            }
           // return View(GalleryList);

           return View( Galleries);
        }


        // GET: Gallery
        public ActionResult IndexSort()
        {
            List<GalleryViewModel> GalleryList = new List<GalleryViewModel>();
         


            foreach (var item in Ga.ListSorted())
            {
                GalleryViewModel f = new GalleryViewModel();
                f.GalleryId = item.GalleryId;
                f.Address = item.Address;
                f.ImageUrl = item.ImageUrl;
                f.lat = item.lat;
                f.lng = item.lng;
                f.Price = item.Price;
                f.Name = item.Name;
              
                GalleryList.Add(f);
               
            }
          
            return View(GalleryList);

        
        }

        // GET : Gallery/LatLng()
        public ActionResult LatLng()
        {



            List<GalleryViewModel> GalleryList = new List<GalleryViewModel>();



            foreach (var item in Ga.GetAll())
            {
                GalleryViewModel f = new GalleryViewModel();
                f.GalleryId = item.GalleryId;
                f.Address = item.Address;
                f.ImageUrl = item.ImageUrl;
                f.lat = item.lat;
                f.lng = item.lng;
                f.Price = item.Price;
                f.Name = item.Name;

              
                GalleryList.Add(f);
              
            }
      
            //  ViewBag.Markers = GalleryList;
            // ViewBag.Markers = GalleryList;
            //  return View();
            return View(GalleryList);

        }

            // GET: Gallery/Details/5
        public ActionResult Details(int id)
        {
           GalleryViewModel EVM = new GalleryViewModel();
            Gallery a = Ga.GetById(id);
            EVM.Name = a.Name; 
             EVM.Address = a.Address;
             EVM.ImageUrl= a.ImageUrl ;
             EVM.lat= a.lat ;
            EVM.lng = a.lng ;
          EVM.Price =a.Price ;
            EVM.ImageUrl = a.ImageUrl;  
            return View(EVM);

        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            GalleryViewModel GAL = new GalleryViewModel();
            return View(GAL);
        }



        // POST: Gallery/Create

        [HttpPost]
        public ActionResult Create(GalleryViewModel EVM , HttpPostedFileBase Image1 , User u)
        {
        
            if (!ModelState.IsValid || Image1 == null || Image1.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            EVM.ImageUrl = Image1.FileName;

            Gallery e = new Gallery
                {
                    Name = EVM.Name,
                    Address = EVM.Address,
                    lat = EVM.lat,
                    lng = EVM.lng,
                    Price = EVM.Price,
                    ImageUrl = EVM.ImageUrl
                };
           
                Ga.Add(e);
                Ga.Commit();



            // Sauvgarde de l'image

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image1.FileName);
            Image1.SaveAs(path);

            System.Diagnostics.Debug.WriteLine(e.lat);
            return RedirectToAction("index");

        }

       

        // return RedirectToAction("Create");




        // GET: Gallery/Edit/5
        public ActionResult Edit(int id)
    {
            GalleryViewModel EVM = new GalleryViewModel();
            Gallery a = Ga.GetById(id);
            EVM.GalleryId = a.GalleryId;
            EVM.Name = a.Name; 
            EVM.Address = a.Address;
            EVM.ImageUrl = a.ImageUrl;
            EVM.lat = a.lat;
            EVM.lng = a.lng;
            EVM.Price = a.Price;
            return View(EVM);
           
    }

    //POST: Gallery/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, GalleryViewModel GAL)
        {
            Gallery g = Ga.GetById(id);
            g.Name = GAL.Name; 
            g.Address = GAL.Address;
            g.ImageUrl = GAL.ImageUrl;
            g.lat = GAL.lat;
            g.lng = GAL.lng;
            g.Price = GAL.Price;

            return RedirectToAction("Index"); 
                }

   // GET: Gallery/Delete/5
    public ActionResult Delete(int id)
    {
         //   Gallery a = new Gallery();
            Ga.Delete(Ga.GetById(id));
            Ga.Commit();
            return RedirectToAction("Index");
        }

  //  POST: Gallery/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, GalleryViewModel EVM )
    {
            Gallery g = Ga.GetById(id);
            g.Address = EVM.Address;
            g.ImageUrl = EVM.ImageUrl;
            g.lat = EVM.lat;
            g.lng = EVM.lng;
            g.Name = EVM.Name;
            g.Price = EVM.Price;
            Ga.Delete(g);
            Ga.Commit();  

        
            return RedirectToAction("index");
        }
     
    
}
}
