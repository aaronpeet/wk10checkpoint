using System.ComponentModel.DataAnnotations;

namespace wk10checkpoint.Models
{
   public class Blogs
   {
       public int Id { get; set; }
       [Required]
       [MaxLength(20)]
       public string Title { get; set; }
       public string Body { get; set; }
       public string ImgUrl { get; set; } 
       public bool Published { get; set; }
       public string CreatorId { get; set; }


    } 
}