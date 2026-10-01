using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lgblesson12.Models
{
    [Table("Marks")]
    public class Marks
    {
        [Display(Name = "Môn học")]
        public int SubjectId { get; set; }

        [Display(Name = "Sinh viên")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Điểm số không được để trống")]
        [Range(0, 10, ErrorMessage = "Điểm số phải từ 0 đến 10")]
        [Display(Name = "Điểm số")]
        public float Score { get; set; }

        // Navigation properties
        public Subjects? Subject { get; set; }
        public Student? Student { get; set; }
    }
}
