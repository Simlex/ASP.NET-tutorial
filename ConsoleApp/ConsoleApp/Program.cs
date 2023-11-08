using System;
using System.Collections.Generic;
using System.Linq;



namespace ConsoleApplication1
{

    /// <summary>
    /// Class is a collection of objects
    /// </summary>
    class Program
    {

        private byte myPrivateByte; // Accessible only within this class

        protected byte myByte = 52; // Only accessible within this class and any class that overrides it e.g ClassB

        public byte myByte2 = 52; // No access restrictions

        internal // Only anything defined in that project is accessible to that project -> Similar to public


        // VARIABLES
        byte b; // Declaring variable
        byte c = 34; // Defining variable

        /// <summary>
        /// This is a function
        /// </summary>
        /// <param name="args"></param>
        /*public static void Main(string[] args)
        {
            byte myByte = 255;          // 8 bit
            // char myChar = (char)65; 'A' // 16 bits 
            char myChar = 'A';          // 16 bits 
            short myShort = 65;
            int myInt = 2147483647;     // 32 bits -> Can't be more
            uint myUInt = 4294967294;   // 32 bits -> Larger numbers
            float myFloat = 1.2345f;    // 32 bits
            double myDouble = 1.2345;   // 64bits
            decimal myDecimal = (decimal)1.444;  // 128 bits


            string myString = "Hello world";

            bool myBool1 = false;
            bool myBool2 = true;



            Console.WriteLine("Hello, World!");
            Console.WriteLine("Please enter a number between 1 and 10...");

            string userResponse = Console.ReadLine();


            // PARSING

            int userNumber;
            
            if(int.TryParse(userResponse, out userNumber))
            {
                if (userNumber < 1 || userNumber > 10)
                {
                    Console.WriteLine("Sorry, the number was outside the range");
                }
                else
                {
                    userNumber = userNumber * 2;
                    // Console.WriteLine("Your new number is: " + userNumber); -> Old way
                    Console.WriteLine($"Your new number is: {userNumber}");
                } 
            }
            else
            {
                Console.WriteLine("Please input a recognized number");
            }

            Console.WriteLine("Press enter to close.");
            Console.ReadLine();

        }*/

        public static void Main(string[] args)
        {
            // Ask user to think of a number between 0 and 100
            Console.WriteLine("Think of a number between 0 and 100");
            // Wait for them to press enter
            Console.ReadLine();

            // Define the maximum number the user can guess
            int max = 100;

            // Keep track of the number of guesses
            int guesses = 0;

            // The start guess from
            int guessMin = 0;

            // The start guess to (half of the max)
            int guessMax = max / 2;

            // While the guess isn't the same as the known maximum value
            while (guessMin != max)
            {
                // Increase guess amount (by 1)
                guesses++;

                // Ask the user if the number is between a guess range
                Console.WriteLine($"Is your number between {guessMin} and {guessMax}");

                string response = Console.ReadLine();

                // If the user confirmed their number is within the current range...
                // Check if response starts with lower case y or uppercase Y
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    // We know the number is between guessFrom and guessTo
                    // So we set the new max number
                    max = guessMax;

                    // Change the next guess range to be half of the new maximum range
                    guessMax = guessMax - (guessMax - guessMin) / 2;
                }
                // The number is greater than guessMax and less than or equal to max
                else
                {
                    Console.WriteLine("You answered no");
                    // The new minium is one above the old maximum
                    guessMin = guessMax + 1;

                    // Guess the bottom half of the new range
                    int remainingDifference = max - guessMax;

                    // Set the guess max to half way between the guessMin and max
                    // NOTE: Math.Ceiling would round up the remaining difference to 2
                    guessMax += (int)Math.Ceiling(remainingDifference / 2f);
                } 

                // If we only have two numbers left, guess one of them
                if (guessMin + 1 == max)
                {
                    // Increase the guess amount (by 1)
                    guesses++;

                    // Ask the user if their number is the lower number
                    Console.WriteLine($"Is your number {guessMin}");
                    response = Console.ReadLine();


                    // If the user confirmed their number is the lower number...
                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        // That means the number must be the higher of the two
                        guessMin = max;
                        break;  
                    }
                }
            }

            // Tell the user their number
            Console.WriteLine($"** Your number is {guessMin}");

            // Let the user know how many guess it took
            Console.WriteLine($"Guessed in {guesses} guesses");

            Console.ReadLine();
        }
        

    }

    class ClassB : Program
    {
        public ClassB() 
        {

            this.myByte = 255;

        }
    }

    class ClassC
    {
        public ClassC()
        {
            var a = new Program();

            a.myByte2 = 23; ;

        }
    }
}
 