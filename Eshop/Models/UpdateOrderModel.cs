﻿using Eshop.Entities;

namespace Eshop.Models
{
    public class UpdateOrderModel
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }    
        public List<OrderState> OrderStates { get; set; }
        public int OrderStateId { get; set; }

        public UpdateOrderModel()
        {
			OrderID = 0;
            Order = null!;
			OrderStates = [];
			OrderStateId = 0;
		}

        public UpdateOrderModel(int orderID, Order order, List<OrderState> orderStates, int orderStateId)
        {
            OrderID = orderID;
            Order = order;
            OrderStates = orderStates;
            OrderStateId = orderStateId;
        }
    }
}
