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
            decimal CHERRY_DISCOUNT = 0.2m;

            var priceLookup = new Dictionary<Fruits, decimal>
            {
                {Fruits.Apples, 1m}, 
                {Fruits.Bananas, 1.5m}, 
                {Fruits.Cherries, 0.75m}
            };

            var nameLookup = new Dictionary<string, Fruits>
            {
                {"apples", Fruits.Apples},
                {"bananas", Fruits.Bananas},
                {"cherries", Fruits.Cherries},
            };

            int[] fruitsCount = new int[3];
            string input;
            while ((input = Console.ReadLine()) != string.Empty)
            {
                Fruits fruit;
                if (nameLookup.TryGetValue(input.ToLower(), out fruit))
                {
                    fruitsCount[(int)fruit]++;
                }
                WriteTotalValue(priceLookup, fruitsCount, CHERRY_DISCOUNT);
                
            }

        }

        private static void WriteTotalValue(Dictionary<Fruits, decimal> priceLookup, int[] fruitsCount, decimal CHERRY_DISCOUNT)
        {
            decimal totalValue = 0.0m;
            totalValue += (priceLookup[Fruits.Apples]*fruitsCount[(int) Fruits.Apples]);
            totalValue += (priceLookup[Fruits.Cherries]*fruitsCount[(int) Fruits.Cherries]) -
                          fruitsCount[(int) Fruits.Cherries]/2*CHERRY_DISCOUNT;
            totalValue += (priceLookup[Fruits.Bananas]*fruitsCount[(int) Fruits.Bananas]);

            Console.WriteLine(totalValue);
        }
    }
}