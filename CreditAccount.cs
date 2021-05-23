using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    class CreditAccount : Account
    {
        public CreditAccount(Client client, int sum = 0) : base(client)
        {
            Amount = sum;
        }

        protected override Transaction WithdrawalTransaction(int sum)
        {
            if (Amount - (int)(sum * (1 + Client.Bank.CreditCommission)) >= Client.Bank.CreditLimit && (!IsQuestionable || (int)(sum * (1 + Client.Bank.CreditCommission)) <=  Client.Bank.MaxSum))
            {
                if (Amount - sum >= 0)
                {
                    return new Transaction(this, -sum);
                }
                else
                {
                    return new Transaction(this, -(int)(sum * (1 + Client.Bank.CreditCommission)));
                }
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

        public override void CancelTransaction(Transaction transaction)
        {
            if (Amount - transaction.Sum >= Client.Bank.CreditLimit)
            {
                Amount -= transaction.Sum;
            }
            else
            {
                Console.Error.WriteLine("The cancel of this transaction is impossible!");
            }
        }
    }
}
