﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using XYZSTUDIOSFINALFINAL.Models.Data;

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
            Title = row.Title;
            Username = row.Username;
            Body = row.Body;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string Username { get; set; }
        [AllowHtml]
        public string Body { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

    }
}