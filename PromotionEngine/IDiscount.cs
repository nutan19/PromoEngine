using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
	public interface IDiscount
	{
		decimal CalculateDiscount(IDictionary<char, int> products);
	}
}
