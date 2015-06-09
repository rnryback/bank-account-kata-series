﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    class AccountTests
    {
        [Test]
        public void CanConstructAccount()
        {
            new Account();
        }

        [Test]
        public void CanConstructAccountWithCash()
        {
            //Arrange
            var cash = new Cash(98.88);
            
            //Act
            new Account(cash);
        }

        [Test]
        public void CanDepositCash()
        {
            //Arrange
            var account = new Account();
            var cash = new Cash(10.45);
            
            //Act
            account.Deposit(cash);
        }
    }
}
