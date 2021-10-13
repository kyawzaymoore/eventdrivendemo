using System;
using EventDrivenDemo.Events;

namespace EventDrivenDemo.Services
{
    public interface IAuditService
    {
        //void WriteAuditLog(string log); // old
        void Subscribe(ITransactionService transactionService);
    }
    public class AuditService : IAuditService
    {
        public void Subscribe(ITransactionService transactionService)
        {
            transactionService.OnTransactionProcessed += WriteAuditLog;
        }

        public void WriteAuditLog(object sender, TransactionProcessedEventArgs e)
        {
            Console.WriteLine($"EVENT AUDIT LOG : {e.TransactionType} for ${e.Amount} processed");
        }

        // public void WriteAuditLog(string log) // old
        // {
        //     Console.WriteLine($"AUDIT LOG : {log}");
        // }
    }
}