using System;

namespace Bank{
    class Program{
        static void Main(string[] args){
            var account = new BankAccount("Acir", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");

            //var account2 = new BankAccount("Rudson", 2000);
            //Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance}");

            account.MakeWithdrawal(200, DateTime.Now, "Food");
            Console.WriteLine(account.Balance);

            account.MakeWithdrawal(500, DateTime.Now, "Clothes");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
            Console.WriteLine($"Current balance: {account.Balance}");

            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //} catch(ArgumentOutOfRangeException exception){
            //    Console.WriteLine("Caught creating account with negative balance");
            //    Console.WriteLine(exception.ToString());
            //}

        }
    }
}