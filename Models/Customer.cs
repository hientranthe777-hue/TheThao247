using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheThao247.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string CustomerPhone { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }

        [StringLength(255)]
        [Display(Name = "Địa chỉ")]
        public string CustomerAddress { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        // Liên kết khóa ngoại tới bảng User
        [ForeignKey("Username")]
        public virtual User User { get; set; }

        // Liên kết tới bảng Order
        public virtual ICollection<Order> Orders { get; set; }
    }
}