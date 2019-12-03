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
using System.Linq;

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
            var input = File.ReadAllLines("Puzzle.txt");

            Console.WriteLine("Hello World!");
            Console.WriteLine("Going to solve Puzzle 1!");

            Puzzle1(input);

            Console.WriteLine("Puzzle 1 solved!");

            Console.WriteLine("Going to solve Puzzle 2!");

            Puzzle2(input);

            Console.WriteLine("Puzzle 2 solved!");

            Console.ReadLine();
        }

        /// <summary>
        /// The puzzle 1.
        /// </summary>
        /// <param name="lines">
        /// The lines.
        /// </param>
        private static void Puzzle1(string[] lines)
        {
            var moduleFuel = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (int.TryParse(line, out var mass))
                {
                    moduleFuel[i] = CalculateFuel(mass);
                }
            }

            var requiredFuel = moduleFuel.Sum();

            Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        /// <summary>
        /// The calculate will calculate the required fuel for the module based on its mass.
        /// The required fuel for the module will be calculated by: Take the mass of the module, divide by three, round down, and
        /// subtract 2.
        /// </summary>
        /// <param name="mass">
        /// The mass.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int CalculateFuel(int mass)
        {
            var fuel = (mass / 3) - 2;

            return fuel;
        }

        /// <summary>
        /// The puzzle 2.
        /// </summary>
        /// <param name="lines">
        /// The lines.
        /// </param>
        private static void Puzzle2(string[] lines)
        {
            var moduleFuel = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (int.TryParse(line, out var mass))
                {
                    moduleFuel[i] = CalculateFuelForModule(mass);
                }
            }

            var requiredFuel = moduleFuel.Sum();

            Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        /// <summary>
        /// The calculate fuel for module.
        /// </summary>
        /// <param name="mass">
        /// The mass.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int CalculateFuelForModule(int mass)
        {
            var fuelForModule = CalculateFuel(mass);

            var fuelForFuel = fuelForModule;
            do
            {
                fuelForFuel = CalculateFuel(fuelForFuel);

                if (fuelForFuel > 0)
                {
                    fuelForModule += fuelForFuel;
                }
            }
            while (fuelForFuel > 0);

            return fuelForModule;
        }
    }
}