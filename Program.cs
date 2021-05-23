using System;

namespace OOP_Lab5_Banks
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = World.GetInstance();
            Bank bank = world.AddBank(0.0001, 30, new (uint, double)[] { (0, 0.0003), (1000000, 0.0004), (10000000, 0.0005) }, 0.05, -10000000, 1000000);
            Client client1 = bank.AddClient("Alex", "Smith", passport: 1234);

            Account account1 = client1.AddAccount(Account.AccountType.Debit, 10000000);
            Account account2 = client1.AddAccount(Account.AccountType.Deposit, 1000000);
            Account account3 = client1.AddAccount(Account.AccountType.Deposit, 10000000);

            int a1s1 = account1.Amount;
            int a2s1 = account2.Amount;
            int a3s1 = account3.Amount;
            account2.Withdrawal(10000);
            int a2s2 = account2.Amount;

            world.AddTime(30);
            int a1s2 = account1.Amount;
            int a2s3 = account2.Amount;
            int a3s2 = account3.Amount;
            account2.Withdrawal(10000);
            int a2s4 = account2.Amount;

            Account account4 = client1.AddAccount(Account.AccountType.Credit, 0);
            Account account5 = client1.AddAccount(Account.AccountType.Credit, 0);

            int a4s1 = account4.Amount;
            int a5s1 = account5.Amount;
            account4.Withdrawal(5000000);
            account4.Withdrawal(10000000);
            int a4s2 = account4.Amount;
            int a5s2 = account5.Amount;

            Client client2 = bank.AddClient("Richard", "Brown");
            Account account6 = client2.AddAccount(Account.AccountType.Debit, 10000000);

            int a1s3 = account1.Amount;
            int a6s1 = account6.Amount;
            account1.Withdrawal(2000000);
            account6.Withdrawal(2000000);
            int a1s4 = account1.Amount;
            int a6s2 = account6.Amount;
            account1.Transfer(account6, 1000000);
            int a1s5 = account1.Amount;
            int a6s3 = account6.Amount;
            World.Transactions[^1].Cancel();
            int a1s6 = account1.Amount;
            int a6s4 = account6.Amount;
        }
    }
}
