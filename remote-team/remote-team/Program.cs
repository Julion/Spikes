using System;
using System.Collections.Generic;
using System.Linq;

namespace remote_team
{
    class Program
    {
        const decimal CherryDiscount = 0.2m;

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
                {Fruits.Cherries, 0.75m},
                
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
                IEnumerable<string> fruits = input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());

                foreach (string fruitStr in fruits)
                {
                    Fruits fruit;
                    if (nameLookup.TryGetValue(input.ToLower(), out fruit))
                    {
                        fruitsCount[(int) fruit]++;
                    }
                }

                WriteTotalValue(priceLookup, fruitsCount);
            }

        }

        private static void WriteTotalValue(Dictionary<Fruits, decimal> priceLookup, int[] fruitsCount)
        {
            decimal totalValue = 0.0m;
            totalValue += (priceLookup[Fruits.Apples] * fruitsCount[(int) Fruits.Apples]);
            totalValue += (priceLookup[Fruits.Cherries] * fruitsCount[(int) Fruits.Cherries]);
            totalValue += (priceLookup[Fruits.Bananas] * fruitsCount[(int) Fruits.Bananas]);

            totalValue -= GetCherryDiscount(fruitsCount);
            totalValue -= GetBananaDiscount(priceLookup, fruitsCount);

            Console.WriteLine(totalValue * 100);
        }

        private static decimal GetBananaDiscount(Dictionary<Fruits, decimal> priceLookup, int[] fruitsCount)
        {
            return fruitsCount[(int)Fruits.Bananas] / 2 * priceLookup[Fruits.Bananas];
        }

        private static decimal GetCherryDiscount(int[] fruitsCount)
        {
            return fruitsCount[(int)Fruits.Cherries] / 2 * CherryDiscount;
        }
    }
}