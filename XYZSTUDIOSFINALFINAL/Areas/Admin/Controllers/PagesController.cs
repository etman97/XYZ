using XYZSTUDIOSFINALFINAL.Models.Data;
using XYZSTUDIOSFINALFINAL.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XYZSTUDIOSFINALFINAL.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            // Declare list of PageVM
            List<PageVM> pagesList;

            using (Db db = new Db())
            {
                // Init the list
                pagesList = db.pages.ToArray().OrderBy(x => x.Id).Select(x => new PageVM(x)).ToList();
            }

            // Return view with list
            return View(pagesList);
        }
        // GET: Admin/Pages/AddPage
        [HttpGet]
        public ActionResult AddPage()
        {
            PageVM model = new PageVM();

            // Add select list of categories to model
            using (Db db = new Db())
            {
                model.Users = new SelectList(db.Users.ToList(), "Id", "Username");
            }
            return View(model);
        }
        // POST: Admin/Pages/AddPage
        [HttpPost]
        public ActionResult AddPage(PageVM model)
        {
            // Check model state
            if (!ModelState.IsValid)
            {
                using (Db db = new Db())
                {
                    model.Users = new SelectList(db.Users.ToList(), "Id", "Username");
                    return View(model);
                }
            }

            using (Db db = new Db())
            {

                // Init pageDTO
                PageDTO dto = new PageDTO();

                // DTO title
                dto.Title = model.Title;
                dto.UserId = model.UserId;
                UserDTO userDTO = db.Users.FirstOrDefault(x => x.Id == model.UserId);
                dto.Username = userDTO.Username;

                // Make sure title and slug are unique
                if (db.pages.Any(x => x.Title == model.Title)|| db.pages.Any(x => x.UserId == model.UserId))
                {
                    ModelState.AddModelError("", "That title already exists.");
                    return View(model);
                }

                // DTO the rest

                dto.Body = model.Body;
             

                // Save DTO
                db.pages.Add(dto);
                db.SaveChanges();
            }

            // Set TempData message
            TempData["SM"] = "You have added a new page!";

            // Redirect
            return RedirectToAction("AddPage");
        }

        // GET: Admin/Pages/EditPage/id
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            // Declare pageVM
            PageVM model;

            using (Db db = new Db())
            {
                // Get the page
                PageDTO dto = db.pages.Find(id);

                // Confirm page exists
                if (dto == null)
                {
                    return Content("The page does not exist.");
                }

                // Init pageVM
                model = new PageVM(dto);
                model.Users = new SelectList(db.Users.ToList(), "Id", "Username");
            }

            // Return view with model
            return View(model);
        }

        // POST: Admin/Pages/EditPage/id
        [HttpPost]
        public ActionResult EditPage(PageVM model)
        {
            // Check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (Db db = new Db())
            {
                // Get page id
                int id = model.Id;

                model.Users = new SelectList(db.Users.ToList(), "Id", "Username");

                // Get the page
                PageDTO dto = db.pages.Find(id);

                // DTO the title
                dto.Title = model.Title;
                dto.UserId = model.UserId;
                UserDTO userDTO = db.Users.FirstOrDefault(x => x.Id == model.UserId);
                dto.Username = userDTO.Username;


                // Make sure title and slug are unique
                if (db.pages.Where(x => x.Id != id).Any(x => x.Title == model.Title)) 
                {
                    ModelState.AddModelError("", "That title or slug already exists.");
                    return View(model);
                }

                // DTO the rest
                dto.Body = model.Body;
                // Save the DTO
                db.SaveChanges();
            }

            // Set TempData message
            TempData["SM"] = "You have edited the page!";

            // Redirect
            return RedirectToAction("EditPage");
        }

    }
}