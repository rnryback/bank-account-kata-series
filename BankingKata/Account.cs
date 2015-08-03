using System;

namespace BankingKata
{
    public class Account
    {
        private readonly ILedger _ledger;

        public Account(ILedger ledger)
        {
            _ledger = ledger;
        }

        public Account()
            : this(new Ledger())
        {
        }

        public void Deposit(DateTime transactionDate, Money money)
        {
            var depositTransaction = new CreditEntry(transactionDate, money);
            _ledger.Record(depositTransaction);
        }

        public Money CalculateBalance()
        {
            return _ledger.Accept(new BalanceCalculatingVisitor(), new Money(0m));
        }

        public void Withdraw(DateTime transactionDate, Money money)
        {
            var debitEntry = new ATMDebitEntry(transactionDate, money);
            _ledger.Record(debitEntry);
        }

        public void ChequeWithdraw(Cheque cheque)
        {
            _ledger.Record(cheque);
        }

        public void PrintBalance(IPrinter printer)
        {
            var balance = CalculateBalance();
            printer.PrintBalance(balance);
        }

        public void PrintLastTransaction(IPrinter printer)
        {
            printer.PrintLastTransaction(_ledger);
        }
    }
}