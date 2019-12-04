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
            input.AddRange(Input.Split(',').Select(int.Parse));
        }

        /// <inheritdoc />
        protected override string Name => "Day 2";

        /// <inheritdoc />
        protected override sealed string Input => "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,9,19,23,1,23,5,27,2,27,10,31,1,6,31,35,1,6,35,39,2,9,39,43,1,6,43,47,1,47,5,51,1,51,13,55,1,55,13,59,1,59,5,63,2,63,6,67,1,5,67,71,1,71,13,75,1,10,75,79,2,79,6,83,2,9,83,87,1,5,87,91,1,91,5,95,2,9,95,99,1,6,99,103,1,9,103,107,2,9,107,111,1,111,6,115,2,9,115,119,1,119,6,123,1,123,9,127,2,127,13,131,1,131,9,135,1,10,135,139,2,139,10,143,1,143,5,147,2,147,6,151,1,151,5,155,1,2,155,159,1,6,159,0,99,2,0,14,0";

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

                        return;
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