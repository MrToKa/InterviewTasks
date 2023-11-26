using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvilengradCasino
{
    internal class Player
    {
        string username;
        string password;
        decimal balance;

        public string Username { get; }

        public string Password { get; }

        public decimal Balance { get; set; }

        public Player(string username, string password, decimal balance)
        {
            this.Username = username;
            this.Password = password;
            this.Balance = balance;
        }

        public override string ToString()
        {
            return $"Username: {this.Username}, Password:{password}, Balance: {this.Balance}";
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.balance -= amount;
        }
    }
}
