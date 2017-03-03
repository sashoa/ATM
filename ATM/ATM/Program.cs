using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    class User
    {
        private int _pin;
        private double _balance;
        private UserInfo _info;

        public int Pin { get; set; }
        public double Balance { get; }
        public UserInfo Info { get; }

        public User(int pin, double balance, UserInfo info)
        {
            Pin = pin;
            _balance = balance;
            _info = info;
        }
    }

    class UserInfo
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _address;

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public UserInfo(int id, string firstName, string lastName, string address)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
