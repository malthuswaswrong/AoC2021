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
        if (flashesPerStep.ContainsKey(oct.Step) == false)
            flashesPerStep.Add(oct.Step, 0);

        flashesPerStep[oct.Step]++;
    }

    public override long Answer {
        get {
            int loopCnt = (part == Part.ONE) ? 100 : 9001;
            for (int i = 0; i < loopCnt; i++) {
                school.ForEach(x => x.IncreasePower());
                school.ForEach(x => x.ProcessFlash());
                school.ForEach(x => x.PostFlashCleanup());

                if (part == Part.TWO &&
                    flashesPerStep.ContainsKey(i) &&
                    flashesPerStep[i] == school.Count())
                    return i + 1;
            }
            return school.Sum(x => x.FlashCount);
        }
    }

    public class DumboOctopus {
        public int Step {
            get; set;
        }
        public readonly Point Location;
        public int ChargeLevel {
            get; set;
        }
        private bool hasFlashed;
        public event EventHandler Flashed;
        public long FlashCount {
            get; set;
        }
        public DumboOctopus(int x, int y, int initialChargeLevel) {
            Location = new Point(x, y);
            ChargeLevel = initialChargeLevel;
            hasFlashed = false;
            FlashCount = 0;
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
            FlashCount++;
            Flashed?.Invoke(this, EventArgs.Empty);
        }
        public void RegisterNeighborOctopus(DumboOctopus dumboOctopus) {
            if (Math.Abs(this.Location.X - dumboOctopus.Location.X) <= 1 &&
               Math.Abs(this.Location.Y - dumboOctopus.Location.Y) <= 1)
                dumboOctopus.Flashed += this.DumboOctopus_Flashed;
        }
        public void DumboOctopus_Flashed(object? sender, EventArgs e) {
            ChargeLevel++;
            if (ChargeLevel > 9)
                Flash();
        }
    }
}
