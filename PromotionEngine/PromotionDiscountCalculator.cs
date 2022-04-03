using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
	public class PromotionDiscountCalculator
	{
		private List<IDiscount> _discountCalculators = null;
		public PromotionDiscountCalculator()
		{
			_discountCalculators = new List<IDiscount>();
			_discountCalculators.Add(new QuantityDiscount());
			_discountCalculators.Add(new ComboDiscount());
		}

		public decimal Discount(char[] products)
		{
			var discountedPrice = 0m;
			if (products == null || products.Length == 0)
			{
				return discountedPrice;
			}
			var productsAndQty = products.GroupBy(p => p).ToDictionary(a => a.Key, a => a.Count());

			var allProducts = ProductRepo.GetProducts;

			foreach (var pro in productsAndQty)
			{
				discountedPrice += allProducts.Find(a => a.ID == pro.Key).Price * pro.Value;
			}

			foreach (var discountType in _discountCalculators)
			{
				discountedPrice -= discountType.CalculateDiscount(productsAndQty);
			}
			return discountedPrice;
		}
	}
}

