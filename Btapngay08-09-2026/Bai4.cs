using System;

namespace Btapngay8_9_2026
{
    public interface IPayable
    {
        bool ProcessPayment(decimal amount);
    }

    public interface IRefundable
    {
        bool ProcessRefund(decimal amount, string reason);
    }

    public abstract class PaymentGateway
    {
        public string TransactionId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Status { get; protected set; }

        protected PaymentGateway(string transactionId)
        {
            TransactionId = transactionId;
            CreationDate = DateTime.Now;
            Status = "Pending";
        }

        public abstract void ValidateConnection();

        public virtual void LogTransaction(string message)
        {
            Console.WriteLine($"[{CreationDate:HH:mm:ss}] [{Status}]: {message}");
        }
    }

    public class MomoPayment : PaymentGateway, IPayable, IRefundable
    {
        public string PhoneNumber { get; set; }

        public MomoPayment(string transactionId, string phoneNumber) : base(transactionId)
        {
            PhoneNumber = phoneNumber;
        }

        public override void ValidateConnection()
        {
            Console.WriteLine($"[MoMo API] Kết nối SĐT {PhoneNumber}... OK.");
        }

        public bool ProcessPayment(decimal amount)
        {
            Status = "Success";
            LogTransaction($"Thanh toán thành công {amount:N0} VNĐ.");
            return true;
        }

        public bool ProcessRefund(decimal amount, string reason)
        {
            Status = "Refunded";
            LogTransaction($"Hoàn tiền {amount:N0} VNĐ. Lý do: {reason}");
            return true;
        }
    }
}