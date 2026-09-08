using System;

namespace Btapngay8_9_2026
{
    public static class DiscountCalculator
    {
        public static decimal ApplyDiscount(decimal totalAmount) => totalAmount * 0.95m;

        public static decimal ApplyDiscount(decimal totalAmount, double percentage)
        {
            if (percentage < 0 || percentage > 100) return totalAmount;
            return totalAmount * (1 - (decimal)percentage / 100m);
        }

        public static decimal ApplyDiscount(decimal totalAmount, decimal fixedVoucher, decimal minimumOrder)
        {
            if (totalAmount >= minimumOrder)
            {
                decimal result = totalAmount - fixedVoucher;
                return result < 0 ? 0 : result;
            }
            return totalAmount;
        }
    }

    public class DeliveryService
    {
        public string OrderId { get; set; }
        public double DistanceKm { get; set; }

        public DeliveryService(string orderId, double distanceKm)
        {
            OrderId = orderId;
            DistanceKm = distanceKm;
        }

        public virtual decimal CalculateShippingFee() => (decimal)DistanceKm * 5000m;
    }

    public class ExpressDelivery : DeliveryService
    {
        public ExpressDelivery(string orderId, double distanceKm) : base(orderId, distanceKm) { }
        public override decimal CalculateShippingFee() => (base.CalculateShippingFee() * 1.5m) + 20_000m;
    }

    public class EcoDelivery : DeliveryService
    {
        public EcoDelivery(string orderId, double distanceKm) : base(orderId, distanceKm) { }
        public override decimal CalculateShippingFee()
        {
            decimal baseFee = base.CalculateShippingFee();
            return DistanceKm > 10 ? baseFee * 0.9m : baseFee;
        }
    }
}