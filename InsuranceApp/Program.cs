using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Xml.Linq;

namespace InsuranceApp
{
    internal class Program
    {
        // Global Variables
        public static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0, quanity;
        public static double totalCost = 0;
        public static double deviceCost;

        static void Main(string[] args)
        {
            // Opening page and title and app discription
            Console.WriteLine(" _____                                          ___              \r\n|_   _|                                        / _ \\             \r\n  | | _ __  ___ _   _ _ __ __ _ _ __   ___ ___/ /_\\ \\_ __  _ __  \r\n  | || '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\  _  | '_ \\| '_ \\ \r\n _| || | | \\__ \\ |_| | | | (_| | | | | (_|  __/ | | | |_) | |_) |\r\n \\___/_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___\\_| |_/ .__/| .__/ \r\n                                                    | |   | |    \r\n                                                    |_|   |_|    ");
            Console.WriteLine("\n\n\n\nThis device insurance app lets users track which devices they have insured and see the cost of each insurance plan in \none convenient place. Users can quickly view all their devices, check coverage details, and monitor insurance expenses\nwithout digging through paperwork.");
            Console.WriteLine("\n\n\n\nPress Enter to Continue");
            Console.ReadLine();
            Console.Clear();

            // check y or n method
            // Check if they want to add another device
            char continueInput = 'y';
            while (continueInput == 'y' || continueInput.Equals('y'))
            {

                Console.WriteLine(OneDevice());

                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.Clear();


                continueInput = CheckContinueInput("\n\nDo you want to add another device? (y/n)");

                Console.Clear();

            }
            //check if hours worked is greater than currnt top hours worked

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Category 1(Laptop) has  {laptopCounter} devices insured\n");
            Console.WriteLine($"Category 2(Desktop) has {desktopCounter} devices insured\n");
            Console.WriteLine($"Category 3(Other) has {otherCounter} devices insured\n");
            Console.WriteLine($"The Device Total Cost:{CalculateDiscount(quanity, deviceCost, totalCost):C}");
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        // generate top device and cost
        static string OneDevice()
        {
            // Local Variables
            List<string> QUESTIONS = new List<string> { $"Enter Device Category:", $"Enter the Device Name:", "Enter the number of devices from the device name from before", "Enter Device Cost:" };

            string deviceName;
            int deviceCategory;

            // Ask for Category,Name,N.O of Devices and Cost
            deviceCategory = CheckCategory(QUESTIONS[0]);
            deviceName = CheckName(QUESTIONS[1]);
            quanity = CheckQuanity(QUESTIONS[2]);
            deviceCost = CheckCost(QUESTIONS[3]);

            // calculate insurance cost/amount

            // show device summary
            Console.Clear();
            Console.WriteLine("------------------Device Added-------------------");
            Console.WriteLine($"The device name is {deviceName}");
            Console.WriteLine(CalculateDepression(deviceCost));
            Console.WriteLine($"The Devices Category is {deviceCategory}\n");
            Console.WriteLine($"The Devices cost is {deviceCost:C}");
            Console.WriteLine("-------------------------------------------------");
            // add device cost to total insurance

            // If statment that adds catergory thing
            if (deviceCategory == 1)
            {
                laptopCounter += quanity;
            }
            else if (deviceCategory == 2)
            {
                desktopCounter += quanity;
            }
            else
            {
                otherCounter += quanity;
            }

            return "";
        }
        // 6 months depression
        public static string CalculateDepression(double deviceCost)
        {
            //Local Variables
            double depressionCost = deviceCost;
            string depressionSummary = "";
            for (int monthCounter = 1; monthCounter < 7; monthCounter++)
            {
                // Calculate the device depression
                depressionCost = depressionCost * 0.95;
                depressionSummary += $"Month {monthCounter}: {depressionCost:C}\n";
            }

            return depressionSummary;
        }
        // Check if y or n is y or n for another device or to not want to add
        static char CheckContinueInput(string question)
        {
            while (true)
            {
                string userInput;
                Console.WriteLine(question);
                userInput = Console.ReadLine();

                //check if userInput is not empty and is either 'y' or 'n'
                if (!string.IsNullOrEmpty(userInput) && Regex.IsMatch(userInput, "^[yYnN]$"))
                {
                    return userInput.ToLower()[0];
                }
                else
                {
                    Console.WriteLine("Error: only use 'y' or 'n' can be used");
                }


            }
        }
        // Calculate the above 5 device discount
        public static double CalculateDiscount(int quanity, double deviceCost, double totalCost)
        {

            if (quanity > 5)
            {
                totalCost += (5 * deviceCost) + ((quanity - 5) * 0.9);
            }
            else
            {
                totalCost += quanity * deviceCost;
            }

            return totalCost;
        }
        // Check if a name is lowercase and convert to capital if needed
        static string CheckName(string question)
        {
            while (true)
            {
                //ask user for name input
                Console.WriteLine(question);

                string nameInput = Console.ReadLine();

                // check if name input is alphabetical characters and '-' only
                if (Regex.IsMatch(nameInput, @"^[A-Za-z-0-9]+$"))
                {
                    nameInput = nameInput[0].ToString().ToUpper() + nameInput.Substring(1);

                    return nameInput;
                }
                else
                {
                    Console.WriteLine("Error: names can only contain alphabetical letters and numbers");
                }
            }

        }
        //Check if cost and quantity of devices
        static int CheckCost(string questions)
        {
            //Local Variables
            int min = 0, max = 10000;
            while (true)
            {

                try
                {
                    Console.WriteLine(questions);
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    //check if user input a number between a min and max
                    if (userInput >= min && userInput <= max)
                    {
                        return userInput;
                    }
                    else
                    {
                        Console.WriteLine($"Please enther a number between {min} and {max}");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: You must enter a number between {min} and {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
        static int CheckCategory(string questions)
        {

            int min = 1, max = 3;
            while (true)
            {

                try
                {
                    Console.WriteLine(questions);
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    //check if user input a number between a min and max
                    if (userInput >= min && userInput <= max)
                    {
                        return userInput;
                    }
                    else
                    {
                        Console.WriteLine($"Please enther a number between {min} and {max}");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: You must enter a number between {min} and {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }

        }
        static int CheckQuanity(string questions)
        {

            int min = 1, max = 250;
            while (true)
            {

                try
                {
                    Console.WriteLine(questions);
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    //check if user input a number between a min and max
                    if (userInput >= min && userInput <= max)
                    {
                        return userInput;
                    }
                    else
                    {
                        Console.WriteLine($"Please enther a number between {min} and {max}");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: You must enter a number between {min} and {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}
