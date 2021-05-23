using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    class Transaction
    {
        public Transaction(Account account, int sum)
        {
            Account = account;
            Sum = sum;
        }

        public readonly Account Account;
        public readonly int Sum;
        public Transaction Related;

        public bool IsCanceled { get; private set; }

        public void Cancel()
        {
            IsCanceled = true;
            Account.CancelTransaction(this);
            if (Related != null)
            {
                if (!Related.IsCanceled)
                {
                    Related.Cancel();
                }
            }
        }
    }
}
