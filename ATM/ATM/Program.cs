using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    public class User
    {
        private static int _ids = 0;
        private double _balance;

        public static int Ids
        {
            get { return _ids; }
        }
        public int Pin { get; set; }
        public double Balance
        {
            get { return _balance; }
        }
        public UserInfo Info { get; set; }

        public User(string firstName, string lastName, string address, int pin, double balance)
        {
            Pin = pin;
            _balance = balance;
            Info = new UserInfo(++_ids, firstName, lastName, address);
        }

    }

    public class UserInfo
    {
        private int _uid;

        public int Uid
        {
            get { return _uid; }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public UserInfo(int uid, string firstName, string lastName, string address)
        {
            _uid = uid;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
    class Program
    {
        //Change user's pin
        private static void ChangePin(User user)
        {
            int newPin;
            int newPinConfirm;
            while (true)
            {
                Console.WriteLine("Enter new 4 digit pin:");
                newPin = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter pin again to confirm");
                newPinConfirm = int.Parse(Console.ReadLine());

                string newPinString = newPin.ToString();

                if (newPinString.Length != 4)
                {
                    Console.Write("\n\nPin must have 4 digits.");
                    Thread.Sleep(1500);
                }
                else if (newPin != newPinConfirm)
                {
                    Console.Write("\nThe pin you entered and confirmation pin do not match");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.Write("\n\nPin Changed!");
                    Thread.Sleep(1500);
                    user.Pin = newPin;
                }
                Console.Write("\nEnter 1 to try again or Any key to exit.\n");
                string userChoice = Console.ReadLine();
                if (userChoice != "1")
                    return;
            }
        }



        static void Main(string[] args)
        {
            User sashe = new User("Sashe", "Apostolovski", "Dimitar Bozinovski no:7, Resen", 1234, 15000);
            User jane = new User("Jane", "Doe", "Mite Bogoevski no: 3, Resen", 4567, 30000);
            User john = new User("John", "Malkovich", "Leninova no:1, Skopje", 8901, 35000);

            Console.ReadLine();
        }
    }
}
