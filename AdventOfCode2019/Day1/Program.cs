// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;

namespace Day1
{
    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Going to solve Puzzle 1!");

            Puzzle1();

            Console.WriteLine("Puzzle 1 solved!");

            Console.ReadLine();
        }

        /// <summary>
        /// The puzzle 1.
        /// </summary>
        private static void Puzzle1()
        {
            var requiredFuel = 0;

            var lines = File.ReadAllLines("Puzzle1.txt");
            foreach (var line in lines)
            {
                if (int.TryParse(line, out var mass))
                {
                    requiredFuel += Calculate(mass);
                }
            }

            Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        /// <summary>
        /// The calculate will calculate the required fuel for the module based on its mass.
        /// The required fuel for the module will be calculated by: Take the mass of the module, divide by three, round down, and subtract 2.
        /// </summary>
        /// <param name="mass">
        /// The mass.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int Calculate(decimal mass)
        {
            var division = mass / 3;
            var rounded = Convert.ToInt32(Math.Floor(division));
            var subtracted = rounded - 2;

            return subtracted;
        }
    }
}