// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Day.cs" company="">
//   
// </copyright>
// <summary>
//   The day.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Day1
{
    /// <summary>
    /// The day.
    /// </summary>
    public abstract class Day
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        protected abstract string Name { get; }

        /// <summary>
        /// The puzzle 1.
        /// </summary>
        protected abstract void Puzzle1();

        /// <summary>
        /// The puzzle 2.
        /// </summary>
        protected abstract void Puzzle2();

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine($"Going to solve the puzzles for {Name}.");

            Console.WriteLine("Puzzle 1 starting.");
            Puzzle1();
            Console.WriteLine("Puzzle 1 finished.");

            Console.WriteLine("Puzzle 2 starting.");
            Puzzle2();
            Console.WriteLine("Puzzle 2 finished.");
        }
    }
}