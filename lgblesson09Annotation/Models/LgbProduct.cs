using System;
using System.ComponentModel.DataAnnotations;

namespace lgblesson09Annotation.Models
{
    public class LgbProduct
    {
        [Key]
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên sản phẩm từ 2 đến 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Đơn giá (VNĐ)")]
        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(1000, 100000000, ErrorMessage = "Đơn giá phải từ 1,000 đến 100,000,000 VNĐ")]
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng tồn kho")]
        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Range(0, 10000, ErrorMessage = "Số lượng tồn kho từ 0 đến 10,000")]
        public int Stock { get; set; }

        [Display(Name = "Ngày nhập kho")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Tên hình ảnh")]
        public string Image { get; set; } = "default.png";
    }
}
