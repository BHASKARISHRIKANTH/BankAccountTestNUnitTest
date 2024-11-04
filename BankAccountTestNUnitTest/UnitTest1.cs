namespace BankAccountTestNUnitTest
{

    
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void SetUp()
        {
            account = new BankAccount(1000);
        }

        [Test]
         public void Deposit_ValidAmount_IncreasesBalance()
         {
             account.Deposit(500);
            Assert.AreEqual(1500, account.GetBalance());
         }


        [Test]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => account.Deposit(-100));
        }

        [Test]
        public void Deposit_ZeroAmount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => account.Deposit(0));
        }

        [Test]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            account.Withdraw(500);
            Assert.AreEqual(500, account.GetBalance());
        }

        [Test]
        public void Withdraw_AmountMoreThanBalance_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(2000));
        }

        [Test]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => account.Withdraw(-100));
        }

        [Test]
        public void Withdraw_ZeroAmount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => account.Withdraw(0));
        }

        [Test]
        public void GetBalance_ReturnsCorrectBalance()
        {
            Assert.AreEqual(1000, account.GetBalance());
        }


        [Test]
        public void Transfer_AmountMoreThanBalance_ThrowsInvalidOperationException()
        {
            var targetAccount = new BankAccount();
            Assert.Throws<InvalidOperationException>(() => account.Transfer(targetAccount, 2000));
        }

        [Test]
        public void Transfer_ToNullAccount_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => account.Transfer(null, 500));
        }

        [Test]
        public void Transfer_NegativeAmount_ThrowsArgumentException()
        {
            var targetAccount = new BankAccount();
            Assert.Throws<ArgumentException>(() => account.Transfer(targetAccount, -50));
        }

        [Test]
        public void Transfer_ZeroAmount_ThrowsArgumentException()
        {
            var targetAccount = new BankAccount();
            Assert.Throws<ArgumentException>(() => account.Transfer(targetAccount, 0));
        }
        
    }
}

