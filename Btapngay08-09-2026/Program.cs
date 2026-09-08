using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btapngay8_9_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Bài 1: BankAccount");
                Console.WriteLine("2. Bài 2: Employee Hierarchy");
                Console.WriteLine("3. Bài 3: Order Processing");
                Console.WriteLine("4. Bài 4: Payment Gateway");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        RunBai1();
                        break;
                    case "2":
                        RunBai2();
                        break;
                    case "3":
                        RunBai3();
                        break;
                    case "4":
                        RunBai4();
                        break;
                    case "0":
                        continueRunning = false;
                        break;
                    default:
                        break;
                }

                if (continueRunning)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            }
        }

        static void RunBai1()
        {
            try
            {
                BankAccount acc1 = new BankAccount("Đỗ Lê Gia Bảo", 100_000m);
                BankAccount acc2 = new BankAccount("Nguyễn Văn A", 500_000m);

                acc1.DisplayInfo();
                acc2.DisplayInfo();

                acc1.Deposit(50_000m);
                acc1.Withdraw(30_000m);
                acc1.Withdraw(100_000m);

                BankAccount accInvalid = new BankAccount("Trần Văn B", 20_000m);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void RunBai2()
        {
            int currentYear = DateTime.Now.Year;

            Employee emp = new Employee("NV01", "Trần Thị C", 2000, 10_000_000m);
            Manager mgr = new Manager("QL01", "Đỗ Lê Gia Bảo", 2006, 20_000_000m, 5_000_000m);

            Console.WriteLine($"{emp.FullName} | Tuổi: {emp.GetAge(currentYear)} | Lương CB: {emp.BaseSalary:N0} | Thu nhập: {emp.CalculateIncome():N0}");
            Console.WriteLine($"{mgr.FullName} | Tuổi: {mgr.GetAge(currentYear)} | Lương CB: {mgr.BaseSalary:N0} | Thu nhập: {mgr.CalculateIncome():N0}");
        }

        static void RunBai3()
        {
            decimal totalOrder = 1_000_000m;

            Console.WriteLine(DiscountCalculator.ApplyDiscount(totalOrder));
            Console.WriteLine(DiscountCalculator.ApplyDiscount(totalOrder, 15));
            Console.WriteLine(DiscountCalculator.ApplyDiscount(totalOrder, 100_000m, 500_000m));

            List<DeliveryService> deliveries = new List<DeliveryService>
            {
                new ExpressDelivery("DH01", 12.5),
                new EcoDelivery("DH02", 12.5),
                new DeliveryService("DH03", 12.5)
            };

            foreach (var delivery in deliveries)
            {
                Console.WriteLine($"{delivery.GetType().Name} | Quãng đường: {delivery.DistanceKm}km | Phí: {delivery.CalculateShippingFee():N0}");
            }
        }

        static void RunBai4()
        {
            MomoPayment momo = new MomoPayment("MM-2026-99", "0987654321");

            momo.ValidateConnection();

            IPayable payableService = momo;
            payableService.ProcessPayment(250_000m);

            IRefundable refundableService = momo;
            refundableService.ProcessRefund(250_000m, "Hủy đơn hàng");
        }
    }
}