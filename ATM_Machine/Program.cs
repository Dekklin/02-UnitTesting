using System;

namespace ATM_Machine
{
    public class Program
    {
        static void Main(string[] args)
        {
            int BankTotal = 1000;
            BeginTransaction(BankTotal);
        }
        static public void BeginTransaction(int Total)
        {
            Console.WriteLine("Hello User! What would you like to do?");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawl");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. Quit");
            string UserAnswer = Console.ReadLine();
            if (UserAnswer == "1")
            {
                //TransactionDeposit(Total);
                Total = TransactionDeposit(Total);
                BeginTransaction(Total);
            }
            else if (UserAnswer == "2")
            {
                Total = TransactionWithdrawl(Total);
                BeginTransaction(Total);
            }
            else if (UserAnswer == "3")
            {
                Console.WriteLine($"You currently have ${Total}");
                BeginTransaction(Total);
            }
            else
            {
                Console.ReadKey();
            }
        }

        static public int TransactionDeposit(int Total)
        {
            Console.WriteLine("How much would you like to deposit?");
            int UserAmount = Convert.ToInt32(Console.ReadLine());
            int NewTotal = UserAmount + Total;
            Console.WriteLine($"You now have ${NewTotal}");
            return NewTotal;

        }
        static public int TransactionWithdrawl(int Total)
        {
            Console.WriteLine("How much would you like to withrawl?");
            int UserAmount = Convert.ToInt32(Console.ReadLine());
            if (UserAmount < Total)
            {
                int NewTotal = Total - UserAmount;
                Console.WriteLine($"You now have ${NewTotal}");
                return NewTotal;
            }
            else
            {
                Console.WriteLine("Sorry, but you don't have enough money to make this transaction");
                Console.WriteLine($"You currently only have ${Total}");
                return TransactionWithdrawl
                    (Total);
            }
        }
    }
}
