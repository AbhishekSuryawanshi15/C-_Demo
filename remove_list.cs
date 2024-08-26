namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // Declaring a list and initializing
            List<string> colors =
            [
                // Adding items to the list
                "red",
                "blue",
                "green",
                "red",
            ];

            colors.Add("blue");

            Console.WriteLine("Current colors in the colors list!");
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }

            bool isDeletingSuccessful = colors.Remove("red");
            while (isDeletingSuccessful){
                isDeletingSuccessful= colors.Remove("red");
            }

            
            Console.WriteLine("Current colors in the colors list!");
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }

            Console.ReadKey();
        }
    }
}