using XYZSTUDIOSFINALFINAL.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Selectors;

namespace XYZSTUDIOSFINALFINAL.Models.ViewModels.Pages
{
    public class PageVM
    {
        public PageVM()
        {
        }

        public PageVM(PageDTO row)
        {
            Id = row.Id;
            UserId = row.UserId;
            Body = row.Body;
            Title = row.Title;
            Username = row.Username;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        [AllowHtml]
        public string Body { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string Username { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}