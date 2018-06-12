using System;

namespace ATM_Machine
{
    public class Program
    {
        //main method that sets a bank total (resets on opening program) and starts up the atm
        static void Main(string[] args)
        {
            int BankTotal = 1000;
            BeginTransaction(BankTotal);
        }
        // decision handler, displays options, saves userInput and directs user dependingly
        static public void BeginTransaction(int Total)
        {
            Console.WriteLine("Hello User! What would you like to do?");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawl");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. Quit");
            string UserAnswer = Console.ReadLine();
            if (UserAnswer == "1") //if statement for deposit
            {
                Console.WriteLine("How much would you like to deposit?");
                try
                {
                    int userAmount = Convert.ToInt32(Console.ReadLine());
                    Total = TransactionDeposit(Total, userAmount);
                    BeginTransaction(Total);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: you didn't enter a valid number!");
                    Console.WriteLine("Withdrawal failed.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Withdrawal failed.");
                    throw;
                }
                finally
                {
                    Console.WriteLine("Returning to main menu.\n");
                    BeginTransaction(Total);
                }
                
            }

            else if (UserAnswer == "2") // if they wanted to withdrawl
            {
            Console.WriteLine("How much would you like to withrawl?");
            int userAmount = Convert.ToInt32(Console.ReadLine());
                Total = TransactionWithdrawl(Total, userAmount);
                BeginTransaction(Total);
            }
            else if (UserAnswer == "3") //if they simply wanted to view their current balance
            {
                Console.WriteLine($"You currently have ${Total}");
                BeginTransaction(Total);
            }
            else
            {
                Console.ReadKey();
            }
        }
        // if the user wanted to deposit money, this is where they are sent, simply adds the amount they want.
        static public int TransactionDeposit(int Total, int userAmount)
        {
            int NewTotal = userAmount + Total;
            Console.WriteLine($"You now have ${NewTotal}");
            return NewTotal;

        }
        //if the user wanted to withdrawl, they are sent here
        static public int TransactionWithdrawl(int Total, int userAmount)
        {

            if (userAmount <= Total)
            {
                int NewTotal = Total - userAmount;
                Console.WriteLine($"You now have ${NewTotal}");
                return NewTotal;
            }
            else
            {
                Console.WriteLine("Sorry, but you don't have enough money to make this transaction");
                Console.WriteLine($"You currently only have ${Total}");
                return Total;
            }
        }
    }
}
