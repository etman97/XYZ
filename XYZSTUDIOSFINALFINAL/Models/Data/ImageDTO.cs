using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZSTUDIOSFINALFINAL.Models.Data
{
    [Table("tblImages")]
    public class ImageDTO
    {
        [Key]
        public int Id { get; set; }
        public int PageId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

        [ForeignKey("PageId")]
        public virtual PageDTO pages { get; set; }
    }
}