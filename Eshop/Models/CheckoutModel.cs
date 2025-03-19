﻿using System.ComponentModel.DataAnnotations;

namespace Eshop.Models
{
	public class CheckoutModel
	{
		public CheckoutModel()
		{
		}
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(50)]

		public string Lastname { get; set; }


		[MaxLength(100)]
		public string Adress { get; set; }


		[MaxLength(100)]
		public string Mail { get; set; }

		public int DeliveryType;
		public int PaymentType;



		public CheckoutModel(string name, string lastname, string adress, string mail, int deliveryType, int paymentType)
		{
			Name = name;
			Lastname = lastname;
			Adress = adress;
			Mail = mail;
			DeliveryType = deliveryType;
			PaymentType = paymentType;
		}
	}
}
