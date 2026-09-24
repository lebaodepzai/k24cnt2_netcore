using System;
using System.ComponentModel.DataAnnotations;

namespace lgblesson09Annotation.Models
{
    public class LgbAccount
    {
        [Key]
        [Display(Name = "Mã tài khoản")]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Họ và tên phải có từ 3 đến 50 ký tự")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không đúng định dạng")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 0 và bao gồm đúng 10 chữ số")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không trùng khớp với mật khẩu")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "Tuổi không được để trống")]
        [Range(18, 65, ErrorMessage = "Tuổi phải trong khoảng từ 18 đến 65")]
        public int Age { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; } = "Nam";

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-20);

        [Display(Name = "Trang cá nhân / Facebook")]
        [Url(ErrorMessage = "Đường dẫn URL không hợp lệ")]
        public string? FacebookUrl { get; set; }

        [Display(Name = "Trạng thái kích hoạt")]
        public bool IsActive { get; set; } = true;
    }
}
