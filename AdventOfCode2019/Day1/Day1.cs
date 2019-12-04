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
            input = Input.Split(Environment.NewLine);
        }

        /// <inheritdoc />
        protected override string Name => "Day 1";

        /// <inheritdoc />
        protected override sealed string Input => @"90903
135889
120859
137397
56532
92489
87979
149620
137436
62999
71672
61022
139765
69690
109513
67615
77803
146519
96432
129440
67912
143886
126992
129921
122339
61684
149706
52779
106421
145896
145977
76585
136021
63976
97063
114899
118570
102196
129126
98521
136186
68054
72452
92433
145851
98487
149980
114477
125479
62351
131559
115553
129371
147164
83125
146200
68621
55982
79131
64907
95570
132347
76889
96461
123627
128180
113508
70342
139386
131234
140377
119825
80791
52090
62615
101366
138512
113752
77912
64447
146047
94578
82228
116731
123488
103839
120854
54663
129242
51587
149536
71096
110104
145155
139278
78799
62410
64645
112849
60402
";

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