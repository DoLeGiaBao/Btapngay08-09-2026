using System;

\using System;

namespace Btapngay8_9_2026
{
    public class BankAccount
    {
        private static long _nextAccountNumber = 1000000001;
        private decimal _balance;
        private string _accountHolder;

        public long AccountNumber { get; private set; }

        public string AccountHolder
        {
            get => _accountHolder;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên chủ tài khoản không hợp lệ.");
                _accountHolder = value;
            }
        }

        public decimal Balance => _balance;

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            if (initialBalance < 50_000m)
                throw new ArgumentException("Số dư khởi tạo tối thiểu 50,000 VNĐ.");

            AccountNumber = _nextAccountNumber++;
            AccountHolder = accountHolder;
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0) _balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || _balance - amount < 50_000m) return false;
            _balance -= amount;
            return true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[STK: {AccountNumber}] | Chủ TK: {AccountHolder} | Số dư: {Balance:N0} VNĐ");
        }
    }
}