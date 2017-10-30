using PiArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiArt.Helper
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<Gallery> gallerys)
        {
            return
                gallerys.OrderBy(gal => gal.Address)
                      .Select(gal =>
                          new SelectListItem
                          {

                              Text = gal.Address + " ",
                              Value = gal.GalleryId.ToString()
                          });
        }
    }
}
    
