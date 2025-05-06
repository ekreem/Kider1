using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class TeacherImage:BaseEntity
    {
        public string ImgUrl { get; set; }
        public bool IsPrime { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher{ get; set; }
    }
}
