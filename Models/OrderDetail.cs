using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheThao247.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }

        public int ProductID { get; set; }
        public int OrderID { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
    }
}