using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab5_Banks
{
    abstract class Account
    {
        public enum AccountType
        {
            Debit,
            Deposit,
            Credit
        }

        public Account(Client client)
        {
            Client = client;
        }

        public readonly Client Client;

        public int Amount { get; protected set; }
        protected int Balance;

        protected abstract Transaction WithdrawalTransaction(int sum);

        protected abstract Transaction DepositTransaction(int sum);

        public void Withdrawal(int sum)
        {
            Transaction transaction = WithdrawalTransaction(sum);
            if (transaction != null)
            {
                MakeTransaction(transaction);
            }
            else
            {
                Console.Error.WriteLine("The withdrawal is impossible!");
            }
        }

        public void Deposit(int sum)
        {
            Transaction transaction = DepositTransaction(sum);
            if (transaction != null)
            {
                MakeTransaction(transaction);
            }
            else
            {
                Console.Error.WriteLine("The deposit is impossible!");
            }
        }

        public void Transfer(Account account, int sum)
        {
            Transaction transaction1 = WithdrawalTransaction(sum);
            Transaction transaction2 = account.DepositTransaction(sum);
            if (transaction1 != null && transaction2 != null)
            {
                MakeTransaction(transaction1);
                account.MakeTransaction(transaction2);
                transaction1.Related = transaction2;
                transaction2.Related = transaction1;
            }
            else
            {
                Console.Error.WriteLine("The transfer is impossible!");
            }
        }

        protected void MakeTransaction(Transaction transaction)
        {
            Amount += transaction.Sum;
            World.Transactions.Add(transaction);
        }

        public virtual void CancelTransaction(Transaction transaction)
        {
            if (Amount - transaction.Sum >= 0)
            {
                Amount -= transaction.Sum;
            }
            else
            {
                Console.Error.WriteLine("This account can't have a negative sum!");
            }
        }

        public virtual void AddPercent() { }

        public void AddBalance()
        {
            Amount += Balance;
            Balance = 0;
        }

        public bool IsQuestionable
        {
            get
            {
                return Client.IsQuestionable;
            }
        }
    }
}
