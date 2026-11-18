using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheThao247.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Phân quyền")]
        public string UserRole { get; set; }

        // Khóa ngoại nối sang bảng Customer
        public virtual ICollection<Customer> Customers { get; set; }
    }
}