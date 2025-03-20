using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
namespace Eshop.Controllers
{
    public partial class AdminController
    {
        public IActionResult EditOrders(int id)
        {
            var order = _context.Orders.Find(id);
            UpdateOrderModel model = new UpdateOrderModel(order.Id,order,_context.OrderStates.ToList(),order.OrderStateId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditOrders(UpdateOrderModel model)
        {
          // var order = _context.Orders.Find(id);
          // UpdateOrderModel model = new UpdateOrderModel(order.Id, order, _context.OrderStates.ToList(), order.OrderStateId);
            return View(model);
        }
    }
}
