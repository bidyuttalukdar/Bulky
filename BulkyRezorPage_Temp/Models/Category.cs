using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyRezorPage_Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public String Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Value must be in between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
