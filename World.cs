using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    class World
    {
        private static World instance;

        private World() { }

        public static World GetInstance()
        {
            if (instance == null)
                instance = new World();
            return instance;
        }

        public static uint Time { get; private set; } = 0;

        public readonly List<Bank> Banks = new List<Bank>();
        public static readonly List<Transaction> Transactions = new List<Transaction>();

        public Bank AddBank(double debitPercent, uint depositPeriod, (uint sum, double percent)[] depositPercents, double creditCommission, int creditLimit, int maxSum)
        {
            Bank bank = new Bank(debitPercent, depositPeriod, depositPercents, creditCommission, creditLimit, maxSum);
            Banks.Add(bank);
            return bank;
        }

        public void NextDay()
        {
            Time++;
            for (int i = 0; i < Banks.Count; i++)
            {
                for (int j = 0; j < Banks[i].Clients.Count; j++)
                {
                    for (int k = 0; k < Banks[i].Clients[j].Accounts.Count; k++)
                    {
                        Banks[i].Clients[j].Accounts[k].AddPercent();
                    }
                }
            }
            if (Time % 30 == 0)
            {
                for (int i = 0; i < Banks.Count; i++)
                {
                    for (int j = 0; j < Banks[i].Clients.Count; j++)
                    {
                        for (int k = 0; k < Banks[i].Clients[j].Accounts.Count; k++)
                        {
                            Banks[i].Clients[j].Accounts[k].AddBalance();
                        }
                    }
                }
            }
        }

        public void AddTime(uint time)
        {
            for (int i = 0; i < time; i++)
            {
                NextDay();
            }
        }
    }
}
