using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lgb2410900009_exam.Models
{
    [Table("LgbEmployee")]
    public class LgbEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã Nhân Viên")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
        [Display(Name = "Họ và Tên")]
        public string LgbName { get; set; } = string.Empty;

        [Display(Name = "Giới Tính")]
        [StringLength(10)]
        public string? LgbGender { get; set; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LgbBirthDay { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        [StringLength(100)]
        public string? LgbEmail { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(20)]
        public string? LgbPhone { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool LgbActive { get; set; } = true;
    }
}
