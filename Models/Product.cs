using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheThao247.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Danh mục")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [StringLength(200)]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Mô tả")]
        public string ProductDescription { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Đơn giá")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Hình ảnh")]
        public string ProductImage { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn không hợp lệ")]
        [Display(Name = "Số lượng tồn")]
        public int Quantity { get; set; }

        // Liên kết khóa ngoại tới bảng Category
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        // Liên kết tới bảng OrderDetail
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}