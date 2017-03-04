using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sashe.ATM;

namespace ATM
{
    class Program
    {
        private static Account[] _accounts = new Account[3]; //   <---- I will (maybe) implement this with List or Dictionary (LoginDetails<Card, Pin> : Account) when we get there.

        public static Account[] Accounts
        {
            get { return _accounts; }
        }

        // Draws Hader
        private static void RenderHeader(string title)
        {
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*************************************************************");
            Console.WriteLine($"************************* {title} *************************");
        }

        // Draws Menu
        private static void RenderMenu()
        {
            Console.Clear();
            RenderHeader("Welcome");
            Console.WriteLine("1 - Change Pin          Customer Information - 4");
            Console.WriteLine("2 - Check Balance                    Deposit - 5");
            Console.WriteLine("3 - Withdraw                            EXIT - 6");
        }

        // Change pin action
        private static void ChangePin(Account account)
        {
            Console.Clear();
            RenderHeader("Change Pin");

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
                    return;
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
                RenderHeader("Deposit");

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
                RenderHeader("Withdraw");
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
            RenderHeader("Account Info");

            Console.WriteLine($"User ID: {account.Info.Uid}");
            Console.WriteLine($"Name: {account.Info.FirstName} {account.Info.LastName}");
            Console.WriteLine($"Address: {account.Info.Address}");

            PromptForExit();
        }

        // Check Balance action
        private static void CheckBalance(Account account)
        {
            Console.Clear();
            RenderHeader("ACCOUNT BALANCE");
            Console.WriteLine($"Your account balance is {account.Balance}");

            PromptForExit();
        }

        // Log In
        private static Account LogIn(int pin)
        {
            Account account = null;

            foreach (Account acc in Accounts)
            {
                if (acc.Pin == pin)
                {
                    account = acc;
                }
                else
                {
                }
            }

            return account;
        }

        // Client Area
        private static void ClientArea(Account account)
        {
            while (true)
            {
                RenderMenu();
                Console.Write("\nChoose action: ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        {
                            ChangePin(account);
                        }
                        break;
                    case "2":
                        {
                            CheckBalance(account);
                        }
                        break;
                    case "3":
                        {
                            Withdraw(account);
                        }
                        break;
                    case "4":
                        {
                            Info(account);
                        }
                        break;
                    case "5":
                        {
                            Deposit(account);
                        }
                        break;
                    case "6":
                        {
                            Console.Clear();
                            RenderHeader("Good Bye!");
                            Thread.Sleep(1500);
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong key!");
                        break;
                }
            }

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
            Accounts[0] = new Account("Sashe", "Apostolovski", "Dimitar Bozinovski no:7, Resen", 1234, 15000);
            Accounts[1] = new Account("Jane", "Doe", "Mite Bogoevski no: 3, Resen", 4567, 30000);
            Accounts[2] = new Account("John", "Malkovich", "Leninova no:1, Skopje", 8901, 35000);

            int loginAttempts = 0;

            while (loginAttempts < 3)
            {
                Console.Clear();
                RenderHeader("Log In");
                Console.Write("\n\nInput your pin: ");
                int inputPin = int.Parse(Console.ReadLine());

                Account account = LogIn(inputPin);

                if (account != null)
                {
                    ClientArea(account);
                    loginAttempts = 0;
                }
                else
                {
                    Console.WriteLine("Wrong pin!");
                    Thread.Sleep(1500);
                    loginAttempts++;
                }

            }

            if (loginAttempts == 3)
            {
                Console.Write($"\nYou entered wrong pin 3 times. Exiting...");
                Thread.Sleep(2500);
                return;
            }


            Console.ReadLine();
        }
    }
}
