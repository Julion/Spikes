using System;
using System.Collections.Generic;

namespace remote_team
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceLookup = new Dictionary<string, decimal>
            {
                {"apples", 1m}, 
                {"bananas", 1.5m}, 
                {"cherries", 0.75m}
            };

            string input;
            while ((input = Console.ReadLine()) != string.Empty)
            {
                decimal value;
                if (priceLookup.TryGetValue(input.ToLower(), out value))
                {
                    // do something
                }
                else
                {
                    Console.WriteLine("invalid input");
                }
            }

        }
    }
}