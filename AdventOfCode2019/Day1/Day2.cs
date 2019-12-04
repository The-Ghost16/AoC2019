// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Day2.cs" company="">
//   
// </copyright>
// <summary>
//   The day 2.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    /// <summary>
    /// The day 2.
    /// </summary>
    public class Day2 : Day
    {
        /// <summary>
        /// The input.
        /// </summary>
        private readonly List<int> input = new List<int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Day2" /> class.
        /// </summary>
        public Day2()
        {
            var inputFile = "Input\\Day2.txt";
            var inputLines = File.ReadAllLines(inputFile);

            foreach (var inputLine in inputLines)
            {
                input.AddRange(inputLine.Split(',').Select(int.Parse));
            }
        }

        /// <inheritdoc />
        protected override string Name => "Day 2";

        /// <summary>
        /// The puzzle 1.
        /// </summary>
        protected override void Puzzle1()
        {
            var value = GetValueAtPosition0(12, 2);

            Console.WriteLine($"Value at position 0 is: {value}");
        }

        /// <summary>
        /// The puzzle 2.
        /// </summary>
        protected override void Puzzle2()
        {
            for (var noun = 0; noun <= 99; noun++)
            {
                for (var verb = 0; verb <= 99; verb++)
                {
                    var value = GetValueAtPosition0(noun, verb);

                    if (value == 19690720)
                    {
                        Console.WriteLine($"Found the correct values for the output: {value}. Noun: {noun}. Verb: {verb}.");

                        var answer = (100 * noun) + verb;

                        Console.WriteLine($"The answer for 100 * noun + verb is: {answer}");
                    }
                }
            }
        }

        /// <summary>
        /// The get value at position 0.
        /// </summary>
        /// <param name="noun">
        /// The noun.
        /// </param>
        /// <param name="verb">
        /// The verb.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetValueAtPosition0(int noun, int verb)
        {
            var startInput = new List<int>(input) { [1] = noun, [2] = verb };

            for (var i = 0; i <= startInput.Count; i = i + 4)
            {
                var opcode = startInput[i];
                var position1 = startInput[i + 1];
                var position2 = startInput[i + 2];
                var storePosition = startInput[i + 3];

                var value1 = startInput[position1];
                var value2 = startInput[position2];

                switch (opcode)
                {
                    case 1:
                        var sum = value1 + value2;
                        startInput[storePosition] = sum;
                        break;
                    case 2:
                        var multiply = value1 * value2;
                        startInput[storePosition] = multiply;
                        break;
                    case 99:
                        return startInput[0];
                    default:
                        throw new Exception();
                }
            }

            return startInput[0];
        }
    }
}