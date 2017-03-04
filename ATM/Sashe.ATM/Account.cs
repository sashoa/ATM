using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sashe.ATM
{
    public class Account
    {
        private static int _ids = 0;

        public static int Ids
        {
            get { return _ids; }
        }
        public int Pin { get; set; }
        public double Balance { get; set; }
        public UserInfo Info { get; set; }

        public Account(string firstName, string lastName, string address, int pin, double balance)
        {
            Pin = pin;
            Balance = balance;
            Info = new UserInfo(++_ids, firstName, lastName, address);
        }

    }
}
