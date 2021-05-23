using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    class Bank
    {
        public Bank(double debitPercent, uint depositPeriod, (uint sum, double percent)[] depositPercents, double creditCommission, int creditLimit, int maxSum)
        {
            DebitPercent = debitPercent;
            DepositPeriod = depositPeriod;
            DepositPercents = depositPercents;
            CreditCommission = creditCommission;
            CreditLimit = creditLimit;
            MaxSum = maxSum;
        }

        public readonly List<Client> Clients = new List<Client>();

        public readonly double DebitPercent;
        public readonly uint DepositPeriod;
        public readonly (uint Sum, double Percent)[] DepositPercents;
        public readonly double CreditCommission;
        public readonly int CreditLimit;
        public readonly int MaxSum;

        public Client AddClient(string name, string surname, string address = "", int passport = 0)
        {
            Client client = new Client(this, name, surname, address, passport);
            Clients.Add(client);
            return client;
        }
    }
}
