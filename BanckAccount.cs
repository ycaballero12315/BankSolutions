using System;
using System.Collections.Generic;
using System.Text;

namespace BankSolutions
{
    public class BanckAccount
    {
        private static int s_accountNumberSeed = 1234567890;
        private readonly decimal _minimalBalance = 0m;
        public string Owner { get; set; }
        public string? Number { get; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }

        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount), "El monto debe ser mayor a cero");
            }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWhithdrawall(decimal amount, DateTime date, string note)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimalBalance);
            Transaction? withdrawal = new(-amount, date, note);
            _allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                _allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }
        public string GetAccountHistory()
        { 
            var report = new StringBuilder();
            foreach(var item in _allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()} : {item.Amount} : {item.Notes}");

            }
            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions()
        {
        }
        public BanckAccount(string owner, decimal initialBalance) : this(owner, initialBalance, 0)
        {
            
        }

        public BanckAccount(string owner, decimal initialBalance, decimal minimalBalance)
        {
            _minimalBalance = minimalBalance;
            Owner = owner;

            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "Initials Counts");
            }
            
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
        }

        private List<Transaction> _allTransactions = new List<Transaction>();
    }
    public record Transaction(decimal Amount, DateTime Date, string Notes);

}

