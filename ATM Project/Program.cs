using System;


public class CardHolder
{
    public string CardNum { get; set; }
    public int Pin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Balance { get; set; }

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }

    public static void Main(string[] args)
    {
        CardHolder john = new CardHolder("1111 2222 3333 4444", 1234, "John", "Ly", 1250.00);

        void printOptions(CardHolder cardHolder)
        {
            Console.WriteLine($"Hello, {cardHolder.FirstName}. What would you like to do?");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void Deposit(CardHolder cardHolder)
        {
            Console.WriteLine("How much do you want to deposit?");

            if (Double.TryParse(Console.ReadLine(), out double amount))
            {
                if (amount > 0)
                {
                    cardHolder.Balance = amount;
                    Console.WriteLine($"Deposit of ${amount} successful. New balance: ${cardHolder.Balance}");
                }
                else
                {
                    Console.WriteLine("Invald input. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        void Withdrawal(CardHolder cardHolder)
        {
            Console.WriteLine("How much do you want to withdrawl?");

            double max = cardHolder.Balance;

            if (Double.TryParse(Console.ReadLine(), out double amount))
            {
                if (amount > 0 && amount <= max)
                {
                    cardHolder.Balance -= amount;
                    Console.WriteLine($"Withdrawal of ${amount} successful. Remaining balance: ${cardHolder.Balance}");
                }
                else if (amount <= 0)
                {
                    Console.WriteLine("Invalid withdrawal amount. Please enter a positive amount.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }     

        void ShowBalance(CardHolder cardHolder)
        {
            Console.WriteLine($"Balance: ${cardHolder.Balance}");
        }

        void Exit()
        {
            Console.WriteLine("Goodbye!");
        }

        int choice;
        do
        {
            printOptions();
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Deposit(john);
                    break;
                case 2:
                    Withdrawal(john);
                    break;
                case 3:
                    ShowBalance(john);
                    break;
                case 4:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        } while (choice != 4);

    }

}