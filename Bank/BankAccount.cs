using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank{
    public class BankAccount {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get {
                decimal balance = 0;
                foreach (var transaction in Transactions) {
                    balance += transaction.Amount;
                }

                return balance;
            }
        }

        private static int accountNumber = 1;

        private List<Transaction> Transactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance){
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Made a initial deposit for balance");
            this.Number = accountNumber.ToString();
            accountNumber++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note){
            if(amount <= 0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive!");
            }
            var deposit = new Transaction(amount, date, note);
            Transactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note){
            if(amount <= 0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive!");
            }

            if(Balance - amount < 0){
                throw new InvalidOperationException("Not sufficient funds for this withdrawal!");
            }

            var withdrawal = new Transaction(-amount, date, note);
            Transactions.Add(withdrawal);
        }

        public string GetAccountHistory(){
            var report = new StringBuilder();
            report.AppendLine("\tDate\t\t\tAmount\tNote");
            foreach(var transaction in Transactions){
                report.AppendLine($"{transaction.Date}\t\t{transaction.Amount}\t{transaction.Notes}");
            }

            return report.ToString();
        }
    }
}
