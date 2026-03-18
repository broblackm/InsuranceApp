using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace InsuranceApp
{
    internal class Program
    {
        // Global Variables
        public static decimal deviceCost = 0;
        static void Main(string[] args)
        {
            // Local Variables
            List<string> QUESTIONS = new List<string> { "Enter Device Category:", "Enter the Device Name:","Enter Device Cost:"};
            List<string> DEVICECATERGORY = new List<string> { "Laptop", "Desktop", "Other"};
            // Opening page and title and app discription
            Console.WriteLine(" _____                                          ___              \r\n|_   _|                                        / _ \\             \r\n  | | _ __  ___ _   _ _ __ __ _ _ __   ___ ___/ /_\\ \\_ __  _ __  \r\n  | || '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\  _  | '_ \\| '_ \\ \r\n _| || | | \\__ \\ |_| | | | (_| | | | | (_|  __/ | | | |_) | |_) |\r\n \\___/_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___\\_| |_/ .__/| .__/ \r\n                                                    | |   | |    \r\n                                                    |_|   |_|    ");
            Console.WriteLine("\n\n\n\nThis device insurance app lets users track which devices they have insured and see the cost of each insurance plan in \none convenient place. Users can quickly view all their devices, check coverage details, and monitor insurance expenses\nwithout digging through paperwork.");
            Console.WriteLine("\n\n\n\nPress Alt f4 to Continue");
            Console.ReadLine();
            Console.Clear();

            // Ask for Category and Name
            Console.WriteLine(QUESTIONS[0]);
            Console.ReadLine();
            Console.WriteLine(QUESTIONS[1]);
            Console.ReadLine();
            Console.WriteLine(QUESTIONS[2]);
            deviceCost = Convert.ToDecimal(Console.ReadLine());
            
            // Check if they want to add another device
            char continueInput = 'y';
            while (continueInput == 'y' || continueInput.Equals('y'))
            {
                Console.WriteLine();

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();

                Console.Clear();


                continueInput = CheckContinueInput("\n\nDo you want to add another device? (y/n)");

                Console.Clear();
            }
            
        }
        // 6 months insurance and generate top device and cost
        static string OneDevice()
        {
            for(decimal i = )
            {

            }

            return "Device Insured";
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
    }
}
