namespace Dictionaries
{   

    
    internal class Program
    {
        static void Main(string[] args)
        {   
            
            var codes = new Dictionary<string, string>{
                ["NY"] = "New York",
                ["CA"] = "California",
                ["TX"] = "Texas"

            };


            if(codes.TryGetValue("NY", out string state)){
                Console.WriteLine(state);
            }

            foreach (var item in codes)
            {
                Console.WriteLine($"The statecode is {item.Key}" +
                    $" and the state name is {item.Value}");
            }

            Console.ReadKey();
        }
    }
}