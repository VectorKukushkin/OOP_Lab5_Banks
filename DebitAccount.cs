using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    class DebitAccount : Account
    {
        public DebitAccount(Client client, uint sum = 0) : base(client)
        {
            Amount = (int)sum;
        }

        protected override Transaction WithdrawalTransaction(int sum)
        {
            if (Amount >= sum && (!IsQuestionable || sum <= Client.Bank.MaxSum))
            {
                return new Transaction(this, -sum);
            }
            else
            {
                return null;
            }
        }

        protected override Transaction DepositTransaction(int sum)
        {
            return new Transaction(this, sum);
        }

        public override void AddPercent()
        {
            Balance += (int)(Amount * Client.Bank.DebitPercent);
        }
    }
}
