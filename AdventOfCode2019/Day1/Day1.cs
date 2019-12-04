// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Day1.cs" company="">
//   
// </copyright>
// <summary>
//   The day 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;

namespace Day1
{
    /// <summary>
    /// The day 1.
    /// </summary>
    public class Day1 : Day
    {
        /// <summary>
        /// The input.
        /// </summary>
        private readonly string[] input;

        /// <summary>
        /// Initializes a new instance of the <see cref="Day1"/> class.
        /// </summary>
        public Day1()
        {
            var inputFile = "Input\\Day1.txt";
            input = File.ReadAllLines(inputFile);
        }

        /// <inheritdoc />
        protected override string Name => "Day 1";

        /// <summary>
        /// The puzzle 1.
        /// </summary>
        protected override void Puzzle1()
        {
            var moduleFuel = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                if (int.TryParse(line, out var mass))
                {
                    moduleFuel[i] = CalculateFuel(mass);
                }
            }

            var requiredFuel = moduleFuel.Sum();

            Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        /// <summary>
        /// The puzzle 2.
        /// </summary>
        protected override void Puzzle2()
        {
            var moduleFuel = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                if (int.TryParse(line, out var mass))
                {
                    moduleFuel[i] = CalculateFuelForModule(mass);
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