﻿using System;

namespace BankingKata
{
    public class DebitEntry : ITransaction
    {
        private DateTime transactionDate;
        private Money transactionAmount;

        public DebitEntry(DateTime transactionDate, Money transactionAmount)
        {
            this.transactionDate = transactionDate;
            this.transactionAmount = transactionAmount;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - transactionAmount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as ATMDebitEntry);
            return transaction != null && transactionAmount.Equals(transaction.transactionAmount);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", transactionDate.ToString("dd MMM yyyy"), transactionAmount);
        }
    }
}