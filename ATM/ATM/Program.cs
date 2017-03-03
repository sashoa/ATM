using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
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
        // Draws Hader
        private static void Header(string title)
        {
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*************************************************************");
            Console.WriteLine($"************************* {title} *************************");
        }

        // Change pin action
        private static void ChangePin(Account account)
        {
            Console.Clear();
            Header("Change Pin");

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
                    account.Pin = newPin;
                }
                Console.Write("\nEnter 1 to try again or Any key to exit.\n");
                string userChoice = Console.ReadLine();
                if (userChoice != "1")
                    return;
            }
        }

        // Deposit action
        private static void Deposit(Account account)
        {
            do
            {
                Console.Clear();
                Header("Deposit");

                Console.WriteLine("Enter amount to deposit");
                double amountToDeposit = double.Parse(Console.ReadLine());

                account.Balance = account.Balance + amountToDeposit;
                Console.Write($"\nSuccessfully deposited {amountToDeposit} den.");

            } while (WantAnotherTransaction());
        }

        // Withdraw action
        private static void Withdraw(Account account)
        {
            do
            {
                Console.Clear();
                Header("Withdraw");
                Console.WriteLine("Enter amount to withdraw");
                double amountToWithdraw = double.Parse(Console.ReadLine());
                double newBalance = account.Balance - amountToWithdraw;

                if (amountToWithdraw < 100 || amountToWithdraw > 30000)
                {
                    Console.WriteLine("The ammount to withdraw should be bigger than 100 and smaller than 30000");
                    Thread.Sleep(1500);
                }
                else if (newBalance >= 0)
                {
                    Console.Write($"\nSuccessfully withdrawn {amountToWithdraw} den.");
                    Thread.Sleep(1500);
                    account.Balance = newBalance;
                }
                else
                {
                    Console.WriteLine("You don't have that much money");
                    Thread.Sleep(1500);
                }

            } while (WantAnotherTransaction());
        }

        // Info action
        private static void Info(Account account)
        {
            Console.Clear();
            Header("Account Info");

            Console.WriteLine($"User ID: {account.Info.Uid}");
            Console.WriteLine($"Name: {account.Info.FirstName} {account.Info.LastName}");
            Console.WriteLine($"Address: {account.Info.Address}");

            PromptForExit();
        }

        // Check Balance action
        private static void CheckBalance(Account account)
        {
            Console.Clear();
            Header("ACCOUNT BALANCE");
            Console.WriteLine($"Your account balance is {account.Balance}");

            PromptForExit();
        }

        // Helpers
        private static bool WantAnotherTransaction()
        {
            Console.Write("\n\nDo you want another transaction?\nYES - 1  NO - Any key\n");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
                return true;
            return false;
        }

        private static void PromptForExit()
        {
            Console.WriteLine($"\nBack - 1\n");
            string back = string.Empty;
            while (back != "1")
            {
                back = Console.ReadLine();
            }
        }


        static void Main(string[] args)
        {
            Account sashe = new Account("Sashe", "Apostolovski", "Dimitar Bozinovski no:7, Resen", 1234, 15000);
            Account jane = new Account("Jane", "Doe", "Mite Bogoevski no: 3, Resen", 4567, 30000);
            Account john = new Account("John", "Malkovich", "Leninova no:1, Skopje", 8901, 35000);

            Console.ReadLine();
        }
    }
}
