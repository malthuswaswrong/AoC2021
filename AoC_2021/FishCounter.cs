using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class FishCounter : ChallengeBase
    {
        private readonly ChallengeInput input;
        private readonly Part part;
        private long[] fishByDay = new long[9];
        public FishCounter(ChallengeInput input, Part part) : base(input, part)
        {
            this.input = input;
            this.part = part;
            Array.Clear(fishByDay, 0, 9);
            input.Inputs[0]
                .Split(",")
                .ToList()
                .ForEach(f => fishByDay[int.Parse(f)]++);
        }
        public override long Answer
        {
            get
            {
                int daysToLoop = (part == Part.ONE) ? 80 : 256;
                long[] storage = new long[9];
                for (int day = 0; day < daysToLoop; day++)
                {
                    Array.Clear(storage, 0, 9);
                    for (int pointer = 8; pointer >= 0; pointer--)
                    {
                        if (pointer == 0)
                        {
                            storage[8] = fishByDay[0];
                            storage[6] += fishByDay[0];
                        }
                        else
                            storage[pointer - 1] = fishByDay[pointer];
                    }
                    storage.CopyTo(fishByDay, 0);
                }
                return fishByDay.ToList().Sum(x => x);
            }
        }
    }
}
