using System;
using System.Collections.Generic;

namespace PromotionEngine
{
	public class ProductRepo
	{
		private static List<Product> _products = new List<Product>()
		{
			new Product() { ID = 'A', Price = 50 },
			new Product() { ID = 'B', Price = 30 },
			new Product() { ID = 'C', Price = 20 },
			new Product() { ID = 'D', Price = 15 },
		};

		public static List<Product> GetProducts => _products;
	}
}
