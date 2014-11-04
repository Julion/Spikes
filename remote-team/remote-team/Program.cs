using System;
using System.Collections.Generic;

namespace remote_team
{
    class Program
    {
        private enum Fruits
        {
            Apples,
            Bananas,
            Cherries
        };

        private List<Fruits> _fruits = new List<Fruits>(); 

        static void Main(string[] args)
        {
            var priceLookup = new Dictionary<Fruits, decimal>
            {
                {Fruits.Apples, 1m}, 
                {Fruits.Bananas, 1.5m}, 
                {Fruits.Cherries, 0.75m}
            };


            string input;
            while ((input = Console.ReadLine()) != string.Empty)
            {
                decimal value;
                Fruits fruit;
                if(Enum.TryParse(input, true, out fruit))
                {
                    if (priceLookup.TryGetValue(fruit, out value))
                    {
                        // do something
                    }    
                }
                
            }

        }
    }
}