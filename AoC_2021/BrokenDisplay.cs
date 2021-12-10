using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class BrokenDisplay : ChallengeBase
{
    private readonly ChallengeInput input;
    private readonly Part part;
    List<Signal> signals;

    public BrokenDisplay(ChallengeInput input, Part part) : base(input, part)
    {
        this.input = input;
        this.part = part;

        signals = new List<Signal>();

        this.input.Inputs
            .ForEach(x => signals.Add(new Signal(x)));
    }

    public override long Answer
    {
        get
        {
            if (part == Part.ONE)
                return signals.Sum(x => x.Outputs.Count(y => y.Length == 2 || y.Length == 3 || y.Length == 4 || y.Length == 7));

            int sum = 0;
            foreach (Signal signal in signals)
            {
                Decoder d = new Decoder();
                int sanityCheck = 0;
                while (d.FullyTrained == false && sanityCheck < 10)
                {
                    sanityCheck++;
                    signal.Outputs.ForEach(w => d.Learn(w));
                    signal.Inputs.ForEach(w => d.Learn(w));
                }

                StringBuilder sb = new StringBuilder();
                foreach (var o in signal.Outputs)
                {
                    var v = d.Decode(o);
                    if (v < 0) throw new Exception($"{o} not decoded");
                    sb.Append(v.ToString());
                }
                sum += int.Parse(sb.ToString());
            }
            return sum;
        }
    }

    private class Signal
    {
        public List<string> Inputs { get; set; }
        public List<string> Outputs { get; set; }
        public Signal(string config)
        {
            Inputs = new();
            Outputs = new();

            var tarr = config.Split("|");
            tarr[0].Trim().Split(" ")
                .ToList()
                .ForEach(t => Inputs.Add(t));

            tarr[1].Trim().Split(" ")
                .ToList()
                .ForEach(t => Outputs.Add(t));

        }

    }
    private class Decoder
    {
        public bool FullyTrained => decoder.Count() == 10;

        private Dictionary<int, List<char>> decoder; //Expected, Actual
        public Decoder()
        {

            decoder = new();

        }

        public bool Learn(string sample)
        {
            if (FullyTrained) return true;
            if (Decode(sample) >= 0) return true;

            Dictionary<int, int> matchingSegments = new Dictionary<int, int>();
            foreach (var key in decoder.Keys)
                matchingSegments.Add(key, 0);

            for (int i = 0; i < sample.Length; i++)
            {
                foreach (var key in decoder.Keys)
                    matchingSegments[key] += (decoder[key].Contains(sample[i])) ? 1 : 0;
            }

            if (sample.Length == 2) //It's a 1
            {
                if (!decoder.ContainsKey(1))
                    decoder.Add(1, new List<char>(sample.ToCharArray()));
                return true;
            }
            if (sample.Length == 3) //It's a 7
            {
                if (!decoder.ContainsKey(7))
                    decoder.Add(7, new List<char>(sample.ToCharArray()));
                return true;
            }
            if (sample.Length == 4) //It's a 4
            {
                if (!decoder.ContainsKey(4))
                    decoder.Add(4, new List<char>(sample.ToCharArray()));
                return true;
            }
            if (sample.Length == 7) //It's an 8
            {
                if (!decoder.ContainsKey(8))
                    decoder.Add(8, new List<char>(sample.ToCharArray()));
                return true;
            }
            if (sample.Length == 5) //It's 2,3,5
            {
                if (matchingSegments.ContainsKey(2) && matchingSegments.ContainsKey(3) && !matchingSegments.ContainsKey(5)) decoder.Add(5, new List<char>(sample.ToCharArray()));
                if (matchingSegments.ContainsKey(2) && matchingSegments.ContainsKey(5) && !matchingSegments.ContainsKey(3)) decoder.Add(3, new List<char>(sample.ToCharArray()));
                if (matchingSegments.ContainsKey(3) && matchingSegments.ContainsKey(5) && !matchingSegments.ContainsKey(2)) decoder.Add(2, new List<char>(sample.ToCharArray()));

                if ((matchingSegments.ContainsKey(1) && matchingSegments[1] == 2) ||
                    (matchingSegments.ContainsKey(7) && matchingSegments[7] == 3))
                {
                    if (!decoder.ContainsKey(3))
                        decoder.Add(3, new List<char>(sample.ToCharArray()));
                    return true;
                }
                if (matchingSegments.ContainsKey(4))
                {
                    if (matchingSegments[4] == 2)
                    {
                        if (!decoder.ContainsKey(2))
                            decoder.Add(2, new List<char>(sample.ToCharArray()));
                        return true;
                    }
                }
                if (matchingSegments.ContainsKey(6))
                {
                    if (matchingSegments[6] == 5)
                    {
                        if (!decoder.ContainsKey(5))
                            decoder.Add(5, new List<char>(sample.ToCharArray()));
                        return true;
                    }
                    else
                    {
                        if (matchingSegments[6] == 4)
                        {
                            if (!decoder.ContainsKey(2))
                                decoder.Add(2, new List<char>(sample.ToCharArray()));
                            return true;
                        }   
                    }
                }

            }
            if (sample.Length == 6) //It's 0,6,9
            {
                if (matchingSegments.ContainsKey(9) && matchingSegments.ContainsKey(6) && !matchingSegments.ContainsKey(0)) decoder.Add(0, new List<char>(sample.ToCharArray()));
                if (matchingSegments.ContainsKey(9) && matchingSegments.ContainsKey(0) && !matchingSegments.ContainsKey(6)) decoder.Add(6, new List<char>(sample.ToCharArray()));
                if (matchingSegments.ContainsKey(0) && matchingSegments.ContainsKey(6) && !matchingSegments.ContainsKey(9)) decoder.Add(9, new List<char>(sample.ToCharArray()));

                if ((matchingSegments.ContainsKey(1) && matchingSegments[1] == 1) ||
                    (matchingSegments.ContainsKey(7) && matchingSegments[7] == 2))
                {
                    if (!decoder.ContainsKey(6))
                        decoder.Add(6, new List<char>(sample.ToCharArray()));
                    return true;
                }
                if ((matchingSegments.ContainsKey(4) && matchingSegments[4] == 4) ||
                   (matchingSegments.ContainsKey(3) && matchingSegments[3] == 5))
                {
                    if (!decoder.ContainsKey(9))
                        decoder.Add(9, new List<char>(sample.ToCharArray()));
                    return true;
                }
                if ((matchingSegments.ContainsKey(7) && matchingSegments[7] == 3))
                {
                    if ((matchingSegments.ContainsKey(5)))
                    {
                        if (matchingSegments[5] == 5)
                        {
                            if (!decoder.ContainsKey(9))
                                decoder.Add(9, new List<char>(sample.ToCharArray()));
                            return true;
                        }
                        else if (matchingSegments[5] == 3)
                        {
                            if (!decoder.ContainsKey(0))
                                decoder.Add(0, new List<char>(sample.ToCharArray()));
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public int Decode(string code)
        {
            foreach (var key in decoder.Keys)
            {
                int matchCount = 0;
                for (int i = 0; i < code.Length; i++) if (decoder[key].Contains(code[i])) matchCount++;

                if (matchCount == decoder[key].Count() && matchCount == code.Length)
                    return key;
            }

            return -1;
        }
    }
}
