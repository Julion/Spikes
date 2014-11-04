﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace remote_team
{
    class Program
    {
        const decimal CherryDiscount = 0.2m;
        const decimal PommesDiscount = 1.0m;
        const decimal MeleDiscount = 0.5m;


        private enum Fruits
        {
            Apples,
            Bananas,
            Cherries,
            Pommes,
            Mele
        };

        private static Dictionary<Fruits, decimal> _priceLookup = new Dictionary<Fruits, decimal>
            {
                {Fruits.Apples, 1m}, 
                {Fruits.Bananas, 1.5m}, 
                {Fruits.Cherries, 0.75m},
                {Fruits.Pommes, 1m}, 
                {Fruits.Mele, 1m}, 
                
            };

        private static Dictionary<string, Fruits> _nameLookup = new Dictionary<string, Fruits>
            {
                {"apples", Fruits.Apples},
                {"bananas", Fruits.Bananas},
                {"cherries", Fruits.Cherries},
                {"pommes", Fruits.Pommes},
                {"mele", Fruits.Mele},
            };

        static void Main(string[] args)
        {
            
            int[] fruitsCount = new int[Enum.GetValues(typeof(Fruits)).Length];
            string input;
            while ((input = Console.ReadLine()) != string.Empty)
            {
                IEnumerable<string> fruits = input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());

                foreach (string fruitStr in fruits)
                {
                    Fruits fruit;
                    if (_nameLookup.TryGetValue(fruitStr.ToLower(), out fruit))
                    {
                        fruitsCount[(int) fruit]++;
                    }
                }

                WriteTotalValue(_priceLookup, fruitsCount);
            }

        }

        private static void WriteTotalValue(Dictionary<Fruits, decimal> priceLookup, int[] fruitsCount)
        {
            decimal totalValue = 0.0m;
            foreach (var fruit in Enum.GetValues(typeof(Fruits)).Cast<Fruits>())
            {
                totalValue += (priceLookup[fruit]*fruitsCount[(int)fruit]);
            }
            totalValue -= GetCherryDiscount(fruitsCount);
            totalValue -= GetBananaDiscount(fruitsCount);
            totalValue -= GetPommesDiscount(fruitsCount);
            totalValue -= GetMeleDiscount(fruitsCount);

            Console.WriteLine(totalValue * 100);
        }

        private static decimal GetBananaDiscount(int[] fruitsCount)
        {
            return fruitsCount[(int)Fruits.Bananas] / 2 * _priceLookup[Fruits.Bananas];
        }

        private static decimal GetCherryDiscount(int[] fruitsCount)
        {
            return fruitsCount[(int)Fruits.Cherries] / 2 * CherryDiscount;
        }

        private static decimal GetPommesDiscount(int[] fruitsCount)
        {
            return fruitsCount[(int)Fruits.Pommes] / 3 * PommesDiscount;
        }

        private static decimal GetMeleDiscount(int[] fruitsCount)
        {
            return fruitsCount[(int)Fruits.Mele] / 2 * MeleDiscount;
        }


    }
}