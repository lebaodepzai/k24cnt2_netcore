using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lgblesson12.Models
{
    [Table("StdClass")]
    public class StdClass
    {
        [Key]
        [Display(Name = "Mã lớp")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp không được để trống")]
        [StringLength(100, ErrorMessage = "Tên lớp giới hạn 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên lớp")]
        public string ClassName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Student>? Students { get; set; }
    }
}
