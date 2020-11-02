using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using XYZSTUDIOSFINALFINAL.Models.Data;

namespace XYZSTUDIOSFINALFINAL.Models.ViewModels.Images
{
    public class ImageVM
    {
        public ImageVM()
        {
        }

        public ImageVM(ImageDTO row)
        {
            Id = row.Id;
            PageId = row.PageId;
            Title = row.Title;
            ImagePath = row.ImagePath;
        }

        public int Id { get; set; }
        public int PageId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<SelectListItem> pages { get; set; }
    }
}