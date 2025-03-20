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
               var order = _context.Orders.Find(model.OrderID);

			ModelState.ClearValidationState("OrderStates");
			ModelState.ClearValidationState("Order");
			ModelState.MarkFieldValid("OrderStates");
			ModelState.MarkFieldValid("Order");


			if (!ModelState.IsValid)
            {
                model = new UpdateOrderModel(order.Id, order, _context.OrderStates.ToList(), order.OrderStateId);
                return View(model);

			}


            order.OrderStateId = model.OrderStateId;
            order.OrderState = null!;

            _context.Orders.Update(order);
            _context.SaveChanges();


            return RedirectToAction("Orders");
        }

        public IActionResult DeleteOrders(int id)
        {
            return new BadRequestResult();//ne nebude se mazat
        }
    }
}
