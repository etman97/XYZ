using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XYZSTUDIOSFINALFINAL.Models.Data;
using XYZSTUDIOSFINALFINAL.Models.ViewModels.Pages;

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
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddPage(PageVM model, IEnumerable<HttpPostedFileBase> files)
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
                if (db.pages.Any(x => x.Title == model.Title) || db.pages.Any(x => x.UserId == model.UserId))
                {
                    ModelState.AddModelError("", "That title already exists.");
                    return View(model);
                }

                //DTO the rest
                dto.Body = model.Body;

                // Save DTO
                db.pages.Add(dto);
                db.SaveChanges();

            }

            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var pathString = Path.Combine(Server.MapPath("~/UploadedFiles/"),model.Title );
                    if (!Directory.Exists(pathString))
                    { Directory.CreateDirectory(pathString); }

                    var path = string.Format("{0}\\{1}", pathString, fileName);

                    file.SaveAs(path);
                }
            }
                // Set TempData message
                TempData["SM"] = "You have added a new page!";
            // Redirect
            return RedirectToAction("AddPage");
        }

        // GET: Admin/Pages/PageDetails/id
        public ActionResult PageDetails(int id)
        {
            // Declare PageVM
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

                // Init PageVM
                model = new PageVM(dto);
            }

            // Return view with model
            return View(model);
        }

        // GET: Admin/Pages/DeletePage/id
        public ActionResult DeletePage(int id)
        {
            using (Db db = new Db())
            {
                // Get the page
                PageDTO dto = db.pages.Find(id);

                // Remove the page
                db.pages.Remove(dto);

                // Save
                db.SaveChanges();
                

                string Path = Server.MapPath("~/UploadedFiles/"+ dto.Title);

                Directory.Delete(Path, true);
            }
            // Redirect
            return RedirectToAction("Index");
        }
    }
}