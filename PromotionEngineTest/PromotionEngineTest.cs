using PromotionEngine;
using System;
using Xunit;

namespace PromotionEngineTest
{
	public class PromotionEngineTest
	{
		private PromotionDiscountCalculator _PromotionDiscountCalculator = null;
		public PromotionEngineTest()
		{
			_PromotionDiscountCalculator = new PromotionDiscountCalculator();
		}

		[Fact]
		public void DiscountType_NoDiscount()
		{
			//Arrange
			var actual = _PromotionDiscountCalculator.Discount(new char[] { 'A', 'B', 'C' });
			//Assert
			var expected = 100m;
			Assert.Equal(actual, expected, 2);
		}
		[Fact]
		public void DiscountType_QuantityDiscount()
		{
			//Arrange
			var actual = _PromotionDiscountCalculator.Discount(new char[] { 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C' });
			//Assert
			var expected = 370m;
			Assert.Equal(actual, expected, 2);
		}

		[Fact]
		public void DiscountType_ComboDiscount()
		{
			var actual = _PromotionDiscountCalculator.Discount(new char[] { 'C', 'D', 'C' ,'D'});

			var expected = 60m;

			Assert.Equal(actual, expected, 2);
		}
		[Fact]
		public void CalulateWith_QuantityAndComboDiscount()
		{
			var actual = _PromotionDiscountCalculator.Discount(new char[] { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D' });

			var expected = 280m;

			Assert.Equal(actual, expected, 2);
		}
	}
}
