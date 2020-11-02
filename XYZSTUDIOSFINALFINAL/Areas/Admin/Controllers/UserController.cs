﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using XYZSTUDIOSFINALFINAL.Models.Data;
using XYZSTUDIOSFINALFINAL.Models.ViewModels.Account;

namespace XYZSTUDIOSFINALFINAL.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            // Declare list of PageVM
            List<UserVM> UserList;

            using (Db db = new Db())
            {
                // Init the list
                UserList = db.Users.ToArray().OrderBy(x => x.Id).Select(x => new UserVM(x)).ToList();
            }

            // Return view with list
            return View(UserList);
        }
    }
}