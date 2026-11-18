using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using TheThao247.Models;

namespace TheThao247.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private TheThao247DBContext db = new TheThao247DBContext();

        // 1. TRANG DANH SÁCH ĐƠN HÀNG (Index.cshtml)
        public ActionResult Index(string searchCustomerName, string searchPaymentStatus, DateTime? searchOrderDate, int? page)
        {
            var orders = db.Orders.Include(o => o.Customer).AsQueryable();

            if (!string.IsNullOrEmpty(searchCustomerName))
            {
                orders = orders.Where(o => o.Customer.CustomerName.Contains(searchCustomerName));
            }

            if (!string.IsNullOrEmpty(searchPaymentStatus))
            {
                orders = orders.Where(o => o.PaymentStatus == searchPaymentStatus);
            }

            if (searchOrderDate.HasValue)
            {
                DateTime dateOnly = searchOrderDate.Value.Date;
                orders = orders.Where(o => DbFunctions.TruncateTime(o.OrderDate) == dateOnly);
            }

            orders = orders.OrderByDescending(o => o.OrderDate).ThenByDescending(o => o.OrderID);

            int pageNumber = page ?? 1;
            int pageSize = 15; // Phân trang 15 đơn hàng/trang theo đề Ktra BE

            var vm = new OrderSearchVM
            {
                SearchCustomerName = searchCustomerName,
                SearchPaymentStatus = searchPaymentStatus,
                SearchOrderDate = searchOrderDate,
                Orders = orders.ToPagedList(pageNumber, pageSize)
            };

            return View(vm);
        }

        // 2. TRANG CHI TIẾT ĐƠN HÀNG (DetailedOrder.cshtml)
        public ActionResult DetailedOrder(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Order order = db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails.Select(d => d.Product))
                .FirstOrDefault(o => o.OrderID == id);

            if (order == null)
                return HttpNotFound();

            return View(order);
        }

        // 3. CẬP NHẬT TRẠNG THÁI (Sử dụng lại giao diện Edit tự sinh của Scaffolding)
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Order order = db.Orders.Find(id);
            if (order == null)
                return HttpNotFound();

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.CustomerID);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,OrderDate,TotalAmount,PaymentMethod,PaymentStatus,DeliveryMethod,AddressDelivery")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DetailedOrder", new { id = order.OrderID });
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.CustomerID);
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}