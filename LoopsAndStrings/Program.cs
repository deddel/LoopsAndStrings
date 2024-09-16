
//Övning 2
using System.Numerics;
using System.Runtime.CompilerServices;

namespace LoopsAndStrings
{
    internal class Program
    {
        static void Main(string[] args) //Execution starts
        {
            StartMain();
            
        }

        //Start method
        private static void StartMain()
        {
            //Boolean menu variable
            bool isAlive = true;

            do
            {                
                Menu.ShowMainMenu();
                uint input = Input.AskForUInt("Val ");
                
                //Menu alternatives
                switch (input)
                {
                    case Menu.Quit: // Exit program
                        isAlive = false;
                        break;
                
                    case Menu.AgeCheck: //Calculate the price
                        DisplayPrice();
                        break;
                 
                    case Menu.Group: // Calculate the price for a group
                        DisplayGroupPrice();
                        break;
                
                    case Menu.MPrintTenTimes: //Print a string ten times
                        PrintTenTimes();
                        break;
                 
                    case Menu.MThirdWord: //Extract the third word from a string
                        ThirdWord();
                        break;
                
                    default: //If no condition is met
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
            while (isAlive);
        }
        
        private static int Price(uint age)
        {
            //Returns the price in kr for a cinema ticket based on customer age
            if (age < 20)
            {
                if (age < 5)
                {
                    return 0; //Free if under 5 years old
                }
                else
                {
                    return 80;
                }          
            }

            else if (age > 64)
            {
                if (age >= 100)
                { 
                    return 0; //Free if over 100 years old
                }
                else 
                { 
                    return 90; 
                }
                
            }
            else
            {
                return 120;
            }
        }
        
        private static void DisplayPrice()
        {
            // Displays the price for a cinema ticket.
            uint customerAge;
            customerAge = Input.AskForUInt("Ålder ");
            int price = Price(customerAge);

            if (customerAge < 20)
            {
                if (customerAge < 5)
                {
                    Console.WriteLine("Gratis för barn under fem år");
                }
                else
                {
                    Console.WriteLine($"Ungdomspris: {price}kr");
                }
            }
            else if (customerAge > 64)
            {
                if (customerAge >= 100)
                {
                    Console.WriteLine("Gratis för personer över 100 år");
                }
                else
                {
                    Console.WriteLine($"Pensionärspris: {price}kr"); ;
                }
            }
            else
            {
                Console.WriteLine($"Standardpris: {price}kr"); ;
            }
        }
        
        private static void DisplayGroupPrice()
        {
            // Displays the price for a group of moviegoers.
            int totalAmount = 0;
            uint customerAge;
            uint numberOfCustomers = Input.AskForUInt("Antal besökare: ");
            for (int i = 0; i < numberOfCustomers; i++)
            {
                customerAge = Input.AskForUInt("Ålder ");
                totalAmount += Price(customerAge);
            }
            Console.WriteLine($"\nAntal personer: {numberOfCustomers}");
            Console.WriteLine($"Totalkostnad: {totalAmount}kr");
        }
        
        private static void PrintTenTimes()
        {
            // Prints a string ten times
            string inputString = Input.AskForString("Skriv en text");
            for (int i = 0; i < 10; i++)
            {

                Console.Write($"{i + 1}. {inputString}, ");
            }

            Console.WriteLine();
        }
        
        private static void ThirdWord()
        {
            // Extracts the third word from a string 
            string inputString = Input.AskForString("Skriv en mening med minst tre ord");
            // Split the string and remove all whitespaces and empty strings
            var ordLista = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            // Display the third word
            Console.WriteLine(ordLista[2]);
        }
        //Menu helper class
        private static class Menu
        {
            public const uint Quit = 0;
            public const uint AgeCheck = 1;
            public const uint Group = 2;
            public const uint MPrintTenTimes = 3;
            public const uint MThirdWord = 4;

            public static void ShowMainMenu()
            {
                
                Console.WriteLine("\nMainMenu - Type your choice and press Enter to try various functions");
                Console.WriteLine($"{AgeCheck}: View the movie ticket price based on customer age" +
                       $"\n{Group}: View the price for a group" +
                       $"\n{MPrintTenTimes}: Display your input 10 times" +
                       $"\n{MThirdWord}: Display the third word in a sentence" +
                       $"\n{Quit}: Quit");
            }
        }
        //Input helper class
        private static class Input
        {
            public static string AskForString(string prompt)
            //Get inputstring and return if not null or whitespace
            {
                bool success = false;
                string answer;

                do
                {
                    Console.Write($"{prompt}:");
                    answer = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(answer))
                    {
                        Console.WriteLine($"Wrong input {prompt}");
                    }
                    else
                    {
                        success = true;
                    }

                } while (!success);

                return answer;
            }

            public static uint AskForUInt(string prompt)
            //Get uint value and return if input is a numeric integer and not negative.
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
                        Console.WriteLine($"Wrong input {prompt}");
                    }


                } while (true);
            }

        }
    }
}
