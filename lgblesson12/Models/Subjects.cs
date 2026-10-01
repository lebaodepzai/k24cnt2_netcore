using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lgblesson12.Models
{
    [Table("Subjects")]
    public class Subjects
    {
        [Key]
        [Display(Name = "Mã môn học")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên môn học không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên môn học")]
        public string SubjectName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Marks>? Marks { get; set; }
    }
}
