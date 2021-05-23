using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    class Client
    {
        public Client(Bank bank, string name, string surname, string address = "", int passport = 0)
        {
            Bank = bank;
            Name = name;
            Surname = surname;
            Address = address;
            Passport = passport;
        }

        public readonly Bank Bank;
        public readonly List<Account> Accounts = new List<Account>();

        public string Name;
        public string Surname;
        public string Address;
        public int Passport;

        public Account AddAccount(Account.AccountType type, int sum = 0)
        {
            Account account = null;
            switch (type)
            {
                case Account.AccountType.Debit:
                    if (sum > 0)
                    {
                        account = new DebitAccount(this, (uint)sum);
                        Accounts.Add(account);
                    }
                    else
                    {
                        Console.Error.WriteLine("A debit account can't have a negative sum!");
                    }
                    break;
                case Account.AccountType.Deposit:
                    if (sum > 0)
                    {
                        account = new DepositAccount(this, (uint)sum);
                        Accounts.Add(account);
                    }
                    else
                    {
                        Console.Error.WriteLine("A deposit account can't have a negative sum!");
                    }
                    break;
                case Account.AccountType.Credit:
                    account = new CreditAccount(this, sum);
                    Accounts.Add(account);
                    break;
            }
            return account;
        }

        public bool IsQuestionable
        {
            get
            {
                if (Address == "" && Passport == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
