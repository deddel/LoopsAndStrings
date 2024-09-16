
using System.Numerics;
using System.Runtime.CompilerServices;

namespace LoopsAndStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isAlive = true;
            uint customerAge;
            
            do
            {
                Menu.ShowMainMenu();
                uint input = Input.AskForUInt("Val ");
                switch (input)
                {
                    case Menu.Quit:
                        isAlive = false;
                        break;
                    case Menu.AgeCheck:
                        customerAge = Input.AskForUInt("Ålder ");
                        //int price = Price(customerAge);
                        DisplayPrice(customerAge, Price(customerAge));
                        break;
                    case Menu.Group:
                        int totalAmount = 0;
                        uint numberOfCustomers = Input.AskForUInt("Antal besökare: ");
                        for (int i = 0; i < numberOfCustomers; i++)
                        {
                            customerAge = Input.AskForUInt("Ålder ");
                            totalAmount += Price(customerAge);
                        }
                        Console.WriteLine($"\nAntal personer: {numberOfCustomers}");
                        Console.WriteLine($"Totalkostnad: {totalAmount}kr");
                        break;
                    case Menu.MPrintTenTimes:
                        PrintTenTimes();
                        break;
                    case Menu.MThirdWord:
                        ThirdWord();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
            while (isAlive);
        }

        private static void ThirdWord()
        {
            throw new NotImplementedException();
        }

        private static void PrintTenTimes()
        {
            string inputString = Input.AskForString("Skriv en text");
            for (int i = 0; i < 10; i++)
            {

                Console.Write($"{i+1}. {inputString}, ");
            }

            Console.WriteLine();
        }

        private static int Price(uint age)
        {
            
            if (age < 20)
            {
                return 80;
            }
            else if (age > 64)
            {
                return 90;
            }
            else 
            {
                return 120;
            }

        }

        private static void DisplayPrice(uint age, int price)
        {
            
            
            if (age < 20)
            {
                Console.WriteLine($"Ungdomspris: {price}kr");
            }
            else if (age > 64)
            {
                Console.WriteLine($"Pensionärspris: {price}kr");
            }
            else
            {
                Console.WriteLine($"Standardpris: {price}kr");
            }

        }

        private static class Menu
        {
            public const uint Quit = 0;
            public const uint AgeCheck = 1;
            public const uint Group = 2;
            public const uint MPrintTenTimes = 3;
            public const uint MThirdWord = 4;

            public static void ShowMainMenu()
            {
                
                Console.WriteLine("\nMainMenu - Write your choice and press Enter");
                Console.WriteLine($"{AgeCheck}: View the price based on customer age" +
                       $"\n{Group}: View the price for a group" +
                       $"\n{MPrintTenTimes}: Display your input 10 times" +
                       $"\n{MThirdWord}: Display the third word in a sentence" +
                       $"\n{Quit}: Quit");
            }
        }
        private static class Input
        {
            public static string AskForString(string prompt)
            {
                bool success = false;
                string answer;

                do
                {
                    Console.Write($"{prompt}:");
                    answer = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(answer))
                    {
                        Console.WriteLine($"You must enter a valid {prompt}");
                    }
                    else
                    {
                        success = true;
                    }

                } while (!success);

                return answer;
            }

            public static uint AskForUInt(string prompt)
            {
                do
                {
                    string input = AskForString(prompt);
                    if (uint.TryParse(input, out uint result))
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a valid {prompt}");
                    }


                } while (true);
            }

        }
    }
}
