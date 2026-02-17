using System;
using System.Collections.Generic;
using System.Text;

namespace BankSolutions
{
    public class InterestEarningAccount:BanckAccount
    {
        public InterestEarningAccount(string owner, decimal initialBalance) : base(owner, initialBalance)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 600m) {

                decimal interes = Balance * 0.05m;
                MakeDeposit(interes, DateTime.Now, "Pago de interes mensual");
            }
        }
    }
}
