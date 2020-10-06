using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XYZSTUDIOSFINALFINAL.Models.Data
{
    [Table("tblPages")]
    public class PageDTO
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
       [AllowHtml]
        public string Body { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDTO Users { get; set; }


    }
}