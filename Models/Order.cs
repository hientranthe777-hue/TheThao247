using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheThao247.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Display(Name = "Khách hàng")]
        public int CustomerID { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Tổng giá trị")]
        public decimal TotalAmount { get; set; }

        [StringLength(100)]
        [Display(Name = "Phương thức thanh toán")]
        public string PaymentMethod { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Trạng thái thanh toán")]
        public string PaymentStatus { get; set; }

        [StringLength(100)]
        [Display(Name = "Phương thức giao hàng")]
        public string DeliveryMethod { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Địa chỉ giao hàng")]
        public string AddressDelivery { get; set; }

        // Liên kết khóa ngoại tới bảng Customer
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        // Liên kết tới bảng OrderDetail
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}