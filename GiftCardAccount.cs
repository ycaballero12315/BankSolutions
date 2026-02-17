using System;
using System.Collections.Generic;
using System.Text;

namespace BankSolutions
{
    public class GiftCardAccount: BanckAccount
    {
        private readonly decimal _monthlyDeposit = 0m;
        public GiftCardAccount(string owner, decimal initialBalance, decimal monthlyDeposit) : base(owner, initialBalance)
        {
            _monthlyDeposit = monthlyDeposit;
        }

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Deposito mensual, agregado");
            }
        }
    }
}
