using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class DumboFlash : ChallengeBase {
    private readonly ChallengeInput input;
    private readonly Part part;
    private Dictionary<int, int> flashesPerStep;
    List<DumboOctopus> school;
    public DumboFlash(ChallengeInput input, Part part) : base(input, part) {
        flashesPerStep = new();
        this.input = input;
        this.part = part;
        school = new();

        for (int y = 0; y < input.Inputs.Count(); y++)
            for (int x = 0; x < input.Inputs[y].Length; x++)
                school.Add(new(x, y, int.Parse(input.Inputs[y][x].ToString())));

        for (int i = 0; i < school.Count; i++)
            for (int j = 0; j < school.Count; j++)
                if (i != j) school[i].RegisterNeighborOctopus(school[j]);

        foreach (var octo in school) {
            octo.Flashed += Octo_Flashed;
        }
    }

    private void Octo_Flashed(object? sender, EventArgs e) {
        
        var oct = (DumboOctopus)sender;
        if (flashesPerStep.ContainsKey(oct.Step) == false) flashesPerStep.Add(oct.Step, 0);

        flashesPerStep[oct.Step]++;
    }

    public override long Answer {
        get {
            int loopCnt = (part == Part.ONE) ? 100 : 9001;
            for (int i = 0; i < loopCnt; i++) {
                school.ForEach(x => x.IncreasePower());
                school.ForEach(x => x.ProcessFlash());
                school.ForEach(x => x.PostFlashCleanup());

                if(part == Part.TWO &&
                    flashesPerStep.ContainsKey(i) &&
                    flashesPerStep[i] == school.Count())
                        return i + 1;

            }
            return school.Sum(x => x.FlashCount);

        }
    }

    private void DumpGrid(string filename) {
        StringBuilder sbPowerLevel = new StringBuilder();
        StringBuilder sbFlashCount = new StringBuilder();
        StringBuilder sbTurn = new StringBuilder();

        
        for (int y = 0; y < 10; y++) {
            for (int x = 0; x < 10; x++) {
                var oct = school.Where(o => o.Location.X == x && o.Location.Y == y).First();
                string powerOutput = (oct.ChargeLevel > 9) ? "*" : oct.ChargeLevel.ToString();
                sbPowerLevel.Append(powerOutput);
                sbFlashCount.Append($"{oct.FlashCount}|");
                sbTurn.Append($"{oct.Step}|");
            }
            sbPowerLevel.AppendLine("");
            sbFlashCount.AppendLine("");
            sbTurn.AppendLine("");
        }
        using StreamWriter sw = new StreamWriter($@"c:\temp\oct\{filename}.txt", false);
        sw.WriteLine("----------Power Levels-----------");
        sw.WriteLine(sbPowerLevel.ToString());
        sw.WriteLine("----------Flash Counts-----------");
        sw.WriteLine(sbFlashCount.ToString());
        sw.WriteLine("----------Turn Counts-----------");
        sw.WriteLine(sbTurn.ToString());
    }

    public class DumboOctopus {
        public int Step {
            get; set;
        }
        public readonly Point Location;
        public int ChargeLevel { get; set; }
        private bool hasFlashed;
        public event EventHandler Flashed;
        private long totalFlashCount;
        public long FlashCount {
            get {
                return totalFlashCount;
            }
        }
        public DumboOctopus(int x, int y, int initialChargeLevel) {
            Location = new Point(x, y);
            ChargeLevel = initialChargeLevel;
            hasFlashed = false;
            totalFlashCount = 0;
            Step = 0;
        }
        public void IncreasePower() {
            ChargeLevel++;
        }
        public void ProcessFlash() {
            if (ChargeLevel > 9) Flash();
        }
        public void PostFlashCleanup() {
            Step++;
            hasFlashed = false;
            if (ChargeLevel > 9) ChargeLevel = 0;
        }
        public void Flash() {
            if (hasFlashed) return;
            hasFlashed = true;
            totalFlashCount++;
            Flashed?.Invoke(this, EventArgs.Empty);
        }
        public void RegisterNeighborOctopus(DumboOctopus dumboOctopus) {
            if (Math.Abs(this.Location.X - dumboOctopus.Location.X) <= 1 &&
               Math.Abs(this.Location.Y - dumboOctopus.Location.Y) <= 1) {
                dumboOctopus.Flashed += this.DumboOctopus_Flashed;
                OctoLog($"Listening to (x:{dumboOctopus.Location.X},y:{dumboOctopus.Location.Y})");
            } else {
                //OctoLog($"Declined (x:{dumboOctopus.Location.X},y:{dumboOctopus.Location.Y})");
            }
        }

        private void OctoLog(string v) {
            using StreamWriter sw = new StreamWriter($@"c:\temp\oct\registration_{this.Location.X}_{this.Location.Y}", true);
            sw.WriteLine(v);
            sw.Close();
        }

        public void DumboOctopus_Flashed(object? sender, EventArgs e) {
            ChargeLevel++;
            if (ChargeLevel > 9)
                Flash();
        }
    }
}
