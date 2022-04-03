using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
	public class QuantityDiscount : IDiscount
	{
		private class DiscountProduct
		{
			public char productId;
			public int quantity;
			public decimal discount;
		}

		private List<DiscountProduct> _discountProducts = new List<DiscountProduct>();
		public QuantityDiscount()
		{
			initializeQuantityPromo('A', 3, 20m);
			initializeQuantityPromo('B', 2, 15m);
		}

		public void initializeQuantityPromo(char productId, int quantity, decimal discount)
		{
			_discountProducts.Add(new DiscountProduct { productId = productId, quantity = quantity, discount = discount });
		}

		public decimal CalculateDiscount(IDictionary<char, int> products)
		{
			var discount = 0m;
			foreach (var product in products)
			{
				var availableDiscount = _discountProducts.Where(a => a.productId == product.Key).FirstOrDefault();

				if (availableDiscount != null)
				{
					discount += (products[product.Key] / availableDiscount.quantity) * availableDiscount.discount;
				}
			}
			return discount;
		}
	}
}
