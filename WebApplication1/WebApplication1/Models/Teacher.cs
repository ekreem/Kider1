using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class Teacher : BaseEntity
    {

        public string? ImgUrl { get; set; }
        [Required, MaxLength(25, ErrorMessage = "25i kecdune QaQa")]
        public string FullName { get; set; }
        public List<TeacherImage>? Images { get; set; }
        public string Job { get; set; }
    }
}
