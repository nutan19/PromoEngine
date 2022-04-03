using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionEngine
{
	public class ComboDiscount:IDiscount
	{
		private class ComboDiscountProduct
		{
			public char[] products;
			public decimal discount;
		}

		private List<ComboDiscountProduct> _discountProducts = new List<ComboDiscountProduct>();
		public ComboDiscount()
		{
			initializeComboPromo(new char[] { 'C', 'D' }, 5m);
		}

		public void initializeComboPromo(char[] products,decimal discount)
		{
			_discountProducts.Add(new ComboDiscountProduct { products = products, discount = discount });
		}

		public decimal CalculateDiscount(IDictionary<char, int> products)
		{
			var discount = 0m;
			if (products==null || products.Count==0)
			{
				return discount;
			}
			foreach (var item in _discountProducts)
			{
				bool match = true;
				var currentcount = 0;
				foreach (var prod in item.products)
				{					
					if (!products.ContainsKey(prod))
					{
						match = false;
						break;
					}
					if (currentcount==0 || currentcount > products[prod])
					{
						currentcount = products[prod];
					}
				}
				if (match)
				{
					discount += item.discount* currentcount;
				}
			}
			return discount;
		}
	}
}
