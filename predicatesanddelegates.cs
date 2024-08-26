using System.Globalization;

namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> {10,5,15,3,9,25,18};

            Console.WriteLine("Unsorted list!");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }


            /*
             In C#, a delegate is like a pointer or a reference to a method. 
            It allows you to pass methods as arguments to other methods, 
            store them in variables, and call them later. 
            This is useful when you want your code to be flexible and 
            able to handle different behaviors that aren't predetermined. 
             
             */


            // Define the predicate to check if a number is greater than 10
            Predicate<int> isGreaterThanTen = x => x > 10;

            List<int> higherTen = numbers.FindAll(isGreaterThanTen);


            Console.WriteLine("All number 10 and higher in our list numbers");
            foreach (int number in higherTen)
            {
                Console.WriteLine(number);
            }


            Console.ReadKey();
        }

        public static bool IsGreaterThanTen(int x)
        {
            return x > 10;
        }

        // A lambda expression consists of 2 Parts
        // 1. Parameters
        // 2. Expression or Statement Block

        // Parameters are written on the left side of =>
        // (this symbol is read as "goes to" or "becomes").
        // The expression or action to perform is on the right side.

        //This reads as:
        //"Take an input x and turn it into x multiplied by x."
        //x => x * x;

        static int Squaring(int num1)
        {
            return num1 *num1;
        }
    }
}