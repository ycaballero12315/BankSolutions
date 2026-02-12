using System;
using System.Collections.Generic;
using System.Text;

namespace Banck_Operator
{
    public class Banck
    {
        private static int s_accountNumberSeed = 1234567890;
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

        public void Makewhithdrawall(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount), "El monto debe ser mayor a cero");
            }
            if ((Balance - amount) < 0)
            {
                throw new InvalidOperationException("No tienes suficiente fondos en withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }

        public Banck(string owner, decimal introBalance)
        {
            Owner = owner;
            MakeDeposit(introBalance, DateTime.Now, "Initials Counts");
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
        }

        private List<Transaction> _allTransactions = new List<Transaction>();
    }
    public record Transaction(decimal Amount, DateTime Date, string Notes);

}

