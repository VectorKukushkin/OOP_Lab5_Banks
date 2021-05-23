using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    class DepositAccount : Account
    {
        public DepositAccount(Client client, uint sum = 0) : base(client)
        {
            Amount = (int)sum;
            Period = World.Time + Client.Bank.DepositPeriod;
            Percent = 0;
            int amount = 0;
            for (int i = 0; i < Client.Bank.DepositPercents.Length && amount < sum; i++)
            {
                amount += (int)Client.Bank.DepositPercents[i].Sum;
                Percent = Client.Bank.DepositPercents[i].Percent;
            }
        }

        private readonly uint Period;
        private readonly double Percent;

        protected override Transaction WithdrawalTransaction(int sum)
        {
            if (World.Time >= Period && (!IsQuestionable || sum <= Client.Bank.MaxSum))
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
            Balance += (int)(Amount * Percent);
        }
    }
}
