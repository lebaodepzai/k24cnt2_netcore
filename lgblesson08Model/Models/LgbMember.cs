using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LgbLesson08Models.Models
{
    public class LgbMember
    {
        [DisplayName("Mã thành viên")]
        public string LgbMemberId { get; set; } = string.Empty;

        [DisplayName("Tên đăng nhập")]
        public string LgbUserName { get; set; } = string.Empty;

        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        public string LgbPassword { get; set; } = string.Empty;

        [DisplayName("Họ và tên")]
        public string LgbFullName { get; set; } = string.Empty;

        [DisplayName("Email")]
        [EmailAddress]
        public string LgbEmail { get; set; } = string.Empty;

        [DisplayName("Tuổi")]
        public int LgbAge { get; set; }
    }
}
