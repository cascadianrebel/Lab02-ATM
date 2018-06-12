using System;
using System.Threading;

namespace Lab02_ATM
{
    public class Program
    {
        // "Global" field
        public static decimal AcctBalance = 1000;

        public static void Main(string[] args)
        {
            Console.WriteLine("ATM");
            Console.WriteLine("Anthony's Teller Machine");

            //Display options for user to choose from
            Prompt();

        }
        /// <summary>
        /// displays the options for which the user can choose
        /// </summary>
        public static void Prompt()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Please choose an action below then press enter:");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("1. View Account Balance");
            Console.WriteLine("2. Withdraw Funds");
            Console.WriteLine("3. Make a Deposit");
            Console.WriteLine("4. Ignore adult responsibilities and get ice cream");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("----------------------------------------");

            // ensures only numbers are input by the user
            try
            {
                int PromptResponse = Convert.ToInt32(Console.ReadLine());
                //if number is input, the below method determines the next step
                PromptHandler(PromptResponse);
            }
            catch (FormatException )
            {
                Console.Clear();
                Console.WriteLine("please use only numericals");
                Thread.Sleep(2000);
                Console.Clear();
                Prompt();
                throw;
            }

        }

        /// <summary>
        /// directs the user to the requested action
        /// </summary>
        /// <param name="PromptResponse"> the number the user entered </param>
        public static void PromptHandler(int PromptResponse)
        {
            if (PromptResponse == 1)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Your account balance is ${ViewBalance()}");
                Console.WriteLine("----------------------------------------");
                Prompt();

            }
            if (PromptResponse == 2)
            {
                Console.Clear();
                Withdraw();
            }
            if (PromptResponse == 3)
            {
                DepositFunds();
            }
            if (PromptResponse == 4)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("*********************************************************");
                Console.WriteLine($"Your response of {PromptResponse} is not a valid input");
                Console.WriteLine("*********************************************************");
                Prompt();
            }
        }

        /// <summary>
        /// pulls global field "AcctBalance"into method
        /// </summary>
        /// <returns> Current Account Balance </returns>
        public static decimal ViewBalance()
        {
            return AcctBalance;
        }
        /// <summary>
        /// subtracts user input from AcctBalance value
        /// </summary>
        /// <returns>new account balance </returns>
        public static decimal Withdraw()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Funds Available: ${ViewBalance()}");
            Console.WriteLine("Enter the withdrawal amount");
            Console.WriteLine("----------------------------------------");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (AcctBalance >= amount)
            {
                AcctBalance -= amount;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Your new balance is: ${ ViewBalance()}");
                Console.WriteLine($"Requested withdrawal: ${amount}");
                Console.WriteLine("----------------------------------------");
                Prompt();
                return ViewBalance();
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Overdraft Warning: insufficient funds");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Requested withdrawal: ${amount}");
            Console.WriteLine($"Available Funds: ${ ViewBalance()}");
            Console.WriteLine("----------------------------------------");

            return Withdraw();
        }
        /// <summary>
        /// adds user input to AcctBalance value
        /// </summary>
        /// <returns>new account balance</returns>
        public static decimal DepositFunds()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Account Balance: ${ViewBalance()}");
            Console.WriteLine("Enter the Deposit amount:");
            Console.WriteLine("----------------------------------------");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount > 0)
            {
                //if number is input, add to account
                AcctBalance += amount;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Deposited Funds: ${amount}");
                Console.WriteLine($"Your new balance is: ${ ViewBalance()}");
                Console.WriteLine("----------------------------------------");
                Prompt();
                return ViewBalance();

            }
            else
            {
                Console.WriteLine("Please only enter numbers");
                Prompt();
                return ViewBalance();
            }


        }

    }
}
