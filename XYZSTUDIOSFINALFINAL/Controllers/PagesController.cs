using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Xml.Schema;
using XYZSTUDIOSFINALFINAL.Models.Data;
using XYZSTUDIOSFINALFINAL.Models.ViewModels.Pages;

namespace XYZSTUDIOSFINALFINAL.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            PageVM  model;
            PageDTO dto;

            using (Db db = new Db())
            {
                // Get user id
                UserDTO user = db.Users.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                int userId = user.Id;

                dto = db.pages.Where(x => x.UserId == userId).FirstOrDefault();
            }

            // Set page title
            if (dto is null)
            {
                return RedirectToAction("pages");
            }
            else
            {
                ViewBag.PageTitle = dto.Title;
            }
            // Init model
            model = new PageVM(dto);

            // Return view with model
            return View(model);
        }

        public ActionResult pages()
        {
            return View();
        }
    }
}