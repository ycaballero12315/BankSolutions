using System;
using System.Collections.Generic;
using System.Text;

namespace BankSolutions
{
    public class LineOfCreditAccount:BanckAccount
    {
        public LineOfCreditAccount(string owner, decimal initialBalance, decimal creditlimit) : base(owner, initialBalance, -creditlimit)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance <= 0)
            {
                decimal interes = -Balance * 0.09m;
                MakeWhithdrawall(interes, DateTime.Now, "Cambiado el monto de interes.");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)=>
            isOverdrawn ? new Transaction(-20m, DateTime.Now, "Cobro por sobregiro") : default;
    }
}
