using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class DiagnosticsSub : ChallengeBase
    {
        private readonly ChallengeInput input;
        private readonly Part part;

        public DiagnosticsSub(ChallengeInput input, Part part) : base(input, part)
        {
            this.input = input;
            this.part = part;
        }
        
        
        public int Gamma
        {
            get
            {
                var result = new char[input.Inputs[0].Length];
                for(int i = 0; i < result.Length; i++)
                    result[i] = input.Inputs.mostestChar(i, '1');

                return charArrToInt(result);
            }
        }

        public int Epsilon
        {
            get
            {
                var result = new char[input.Inputs[0].Length];
                for (int i = 0; i < result.Length; i++)
                    result[i] = input.Inputs.leastestChar(i, '0');

                return charArrToInt(result);
            }
        }
        public int CO2
        {
            get
            {
                List<string> digger = new List<string>();
                digger.AddRange(input.Inputs);
                for (int i = 0; i < input.Inputs[0].Length; i++)
                {
                    digger = digger.Where(x => x[i] == digger.leastestChar(i, '0')).ToList();
                    if (digger.Count() == 1) break;
                }
                if (digger.Count() == 1) return charArrToInt(digger[0].ToCharArray());

                throw new Exception("Expected exactly 1 result");
            }
        }
        public int O2
        {
            get
            {
                List<string> digger = new List<string>();
                digger.AddRange(input.Inputs);
                for(int i = 0; i < input.Inputs[0].Length; i++)
                {
                    digger = digger.Where(x => x[i] == digger.mostestChar(i, '1')).ToList();
                    if (digger.Count() == 1) break;
                }
                if (digger.Count() == 1) return charArrToInt(digger[0].ToCharArray());

                throw new Exception("Expected exactly 1 result");
            }
        }
        private int charArrToInt(char[] input)
        {
            int adder = 1;
            int result = 0;
            for(int i = input.Length - 1; i >= 0; i-- )
            {
                if (input[i] == '1') result += adder;
                adder *= 2;
            }
            return result;
        }

        
        public override int Answer
        {
            get
            {
                if (part == Part.ONE) return Gamma * Epsilon;
                else return O2 * CO2;
            }
        }
    }
    public static class Extensions
    {
        public static char mostestChar(this List<string> inputs, int index, char tiedChar)
        {
            Dictionary<char, int> counter = new();
            inputs.ForEach(x => {
                if (!counter.ContainsKey(x[index])) counter.Add(x[index], 0);
                counter[x[index]]++;
            });

            int topVal = counter.Max(x => x.Value);

            bool tied = (counter.Count(x => x.Value == topVal) > 1);
            if (tied) return tiedChar;

            var ret = counter.Where(x => x.Value == topVal).Select(y => y.Key).First();

            return ret;
        }
        public static char leastestChar(this List<string> inputs, int index, char tiedChar)
        {
            var result = inputs.mostestChar(index, 'X');
            return (result == 'X') ? tiedChar : (result == '1') ? '0' : '1';
        }
    }
}
