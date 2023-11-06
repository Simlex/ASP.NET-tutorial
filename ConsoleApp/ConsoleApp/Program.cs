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
        public static void Main(string[] args)
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
 