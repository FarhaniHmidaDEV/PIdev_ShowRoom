using PiArt.Data.Migrations;
using PiArt.Domain.Entities;
using PiArt.Helper;
using PiArt.Models;
using PiArt.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiArt.Controllers
{
    public class RentController : Controller
    {
        RentService Re = new RentService();
        GalleryService ga = new GalleryService();
        User U = new User();
        public RentController()
        {
      
        }


        // GET: Rent
        public ActionResult Index()
        { 
            List<RentViewModel> RentList = new List<RentViewModel>();
            foreach (var item in Re.GetAll())
            {
                RentViewModel R = new RentViewModel();
                R.RentId = item.RentId;
                R.StartDate = item.StartDate;
                R.EndDate = item.EndDate;
                R.DescriptionRent= item.DescriptionRent;
                R.State = item.State;
              
                RentList.Add(R);

            }
            
            return View(RentList);
        }

        // GET : RentOwner
        public ActionResult IndexOwner()
        {
            RentViewModel R = new RentViewModel();
            List<Rent> RentList = new List<Rent>();
            List<Gallery> galleryList = new List<Gallery>();
           // List<String> l1 = (Re.GetByName());
            int x = 0;
            string adr1, des = null;
            DateTime d1, d2;
            var gal = from m in galleryList
                      join p in RentList on m.GalleryId equals p.GalleryId into ps
                      from i in ps.DefaultIfEmpty()
                      select new
                      {
                          o = i.DescriptionRent,
                          k = i.gallery,
                          d1 = i.StartDate,
                          d2 = i.EndDate
                      };

            List<String> ls = new List<string>();
            foreach (var item in gal)
            {
                adr1 = item.k.Address;
                des = item.o;
                d1 = item.d1;
                d2 = item.d2;
                ls.Add(adr1);
                ls.Add(des);
                ls.Add("" + d1);
                ls.Add("" + d2);

                
            }



            ViewBag.Data = ls; 

            return View();
        }



        // GET: RentGalleryOwner
        public ActionResult IndexGalleryOwner()
        {
            List<RentViewModel> RentList = new List<RentViewModel>();
        
            foreach (var item in Re.GetAll())
            {
                RentViewModel R = new RentViewModel();
                ViewBag.data =item.gallery.Address; 
                R.GalleryId = item.GalleryId;
                R.RentId = item.RentId;
                R.StartDate = item.StartDate;
                R.EndDate = item.EndDate;
                R.DescriptionRent = item.DescriptionRent;
                R.State = item.State;

                RentList.Add(R);

            }

            return View(RentList);
        }

        //GET : Rent/BestGallery
        public ActionResult BestGallery()
        {
            int adr = Re.BestRentGallery();
            Gallery rent = new Gallery ();
       Gallery g   = ga.GetById(adr);

            rent.Address = g.Address;
            rent.Name = g.Name;
            rent.Price = g.Price; 
        
              

          
            return View(g);
      
        }

        // GET: Rent/Details/5
        public ActionResult Details(int id)
        {
          
            Rent R = Re.GetById(id);
            RentViewModel REN = new RentViewModel();
            REN.StartDate = R.StartDate;
            REN.EndDate = R.EndDate;
            REN.DescriptionRent = R.DescriptionRent;
            return View (REN);
        }
       
    
        // GET: Rent/DetailsOwner/5
        public ActionResult DetailsOwner(int id)
        {
            Rent R = Re.GetById(id);
            RentViewModel REN = new RentViewModel();
            
            R.State = State.On_Hold;
            REN.StartDate = R.StartDate;
            REN.EndDate = R.EndDate;
            REN.State = R.State; 
            REN.DescriptionRent = R.DescriptionRent;
            ViewBag.state = REN.State; 
            return View(REN);
        }

        // GET: Rent/Refuse/
        public ActionResult Refuse(int id )
        {
            Rent R = Re.GetById(id);
            RentViewModel REN = new RentViewModel();

            R.State = State.Refused;
            REN.StartDate = R.StartDate;
            REN.EndDate = R.EndDate;
            REN.State = R.State;
            REN.DescriptionRent = R.DescriptionRent;
            // ViewBag.state = REN.State;
            Re.Update(R);
            Re.Commit();
            return RedirectToAction("IndexGalleryOwner");
           
          
        }
        // GET: Rent/Accepted
        public ActionResult Accepted(int id)
        {
            Rent R = Re.GetById(id);
            RentViewModel REN = new RentViewModel();

            R.State = State.Accepted;
            REN.StartDate = R.StartDate;
            REN.EndDate = R.EndDate;
            REN.State = R.State;
            REN.DescriptionRent = R.DescriptionRent;
            Re.Update(R);
            Re.Commit();
            //ViewBag.state = REN.St
           return  RedirectToAction("IndexGalleryOwner");
           
        }

        // GET: Rent/Create
        public ActionResult Create()
        {
        var  REN = new RentViewModel();
           REN.gallerys = Re.GetAllGalleries().ToSelectListItems();
           
            return View(REN);
        }

        // POST: Rent/Create
        [HttpPost]
        public ActionResult Create(RentViewModel REN )

        {
            REN.State = State.On_Hold; 

        
            Rent R = new Rent
            {

                StartDate = REN.StartDate,
                EndDate = REN.EndDate,
                State = REN.State,
                DescriptionRent = REN.DescriptionRent,
                GalleryId = REN.GalleryId,
                UserId = 4 , 
            

              
            };
            Re.Add(R);
            Re.Commit();
          
            return RedirectToAction("Index");
        }

        // GET: Rent/Edit/5
        public ActionResult Edit(int id)
        {
           Rent R = Re.GetById(id);
            RentViewModel REN = new RentViewModel();
            REN.RentId = R.RentId; 
            REN.StartDate = R.StartDate;
            REN.EndDate = R.EndDate;
            REN.DescriptionRent = R.DescriptionRent;
            Re.Update(R);
            Re.Commit();
            if (REN == null)
            {
                return HttpNotFound();
            }
            return View(REN);
        }

        // POST: Rent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RentViewModel REN)
        {

            Rent R = Re.GetById(id);
       
            R.StartDate = REN.StartDate;
            R.EndDate = REN.EndDate;
            R.DescriptionRent = REN.DescriptionRent;
            Re.Update(R);
            Re.Commit();

            return RedirectToAction("Index"); 
        }

        // GET: Rent/Delete/5
        public ActionResult Delete(int id)
        {
            Rent R = Re.GetById(id);
            RentViewModel REN = new RentViewModel();
            REN.StartDate = R.StartDate;
            REN.EndDate = R.EndDate;
            REN.DescriptionRent = REN.DescriptionRent; 
           
            return View(REN);
        }

        // POST: Rent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RentViewModel REN )
        {
            Rent R = Re.GetById(id);
            Re.Delete(R);
            Re.Commit();
            return RedirectToAction("Index") ; 
        }
    }
}
