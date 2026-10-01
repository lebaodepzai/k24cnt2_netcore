using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lgblesson12.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Display(Name = "Mã SV")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên sinh viên không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Họ tên")]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Email")]
        public string StudentEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Số điện thoại")]
        public string StudentPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Địa chỉ")]
        public string StudentAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ảnh đại diện không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Ảnh đại diện")]
        public string StudentAvatar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime StudentBirthday { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn lớp học")]
        [Display(Name = "Lớp học")]
        public int ClassId { get; set; }

        // Navigation properties
        public StdClass? StdClass { get; set; }
        public ICollection<Marks>? Marks { get; set; }
    }
}
