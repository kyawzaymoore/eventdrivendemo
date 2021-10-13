using System;
using EventDrivenDemo.Events;

namespace EventDrivenDemo.Services
{
    public interface ITransactionService
    {
        void MakeDeposit(decimal amount);
        void MakeWithdrawal(decimal amount);
        event EventHandler<TransactionProcessedEventArgs> OnTransactionProcessed;
    }
    public class TransactionService : ITransactionService
    {
        public event EventHandler<TransactionProcessedEventArgs> OnTransactionProcessed;
        public void MakeDeposit(decimal amount)
        {
            ProcessDeposit(amount);
            if(OnTransactionProcessed != null)
            {
                OnTransactionProcessed(this, new TransactionProcessedEventArgs(amount, TransactionType.Deposit));
            }
        }

        public void MakeWithdrawal(decimal amount)
        {
            ProcessWithdrawal(amount);
             if(OnTransactionProcessed != null)
            {
                OnTransactionProcessed(this, new TransactionProcessedEventArgs(amount, TransactionType.Withdrawal));
            }
        }

        private void ProcessDeposit(decimal amount)
        {
            Console.WriteLine("Process Deposit Function");
        }

        private void ProcessWithdrawal(decimal amount)
        {
             Console.WriteLine("Process Withdrawal Function");
        }
    }
}