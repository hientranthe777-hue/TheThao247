using System;
using PagedList;

namespace TheThao247.Models
{
    public class OrderSearchVM
    {
        public string SearchCustomerName { get; set; }
        public string SearchPaymentStatus { get; set; }
        public DateTime? SearchOrderDate { get; set; }
        public IPagedList<Order> Orders { get; set; }
    }
}