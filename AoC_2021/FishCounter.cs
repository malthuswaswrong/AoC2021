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
        private List<Fish> school;
        public FishCounter(ChallengeInput input, Part part) : base(input, part)
        {
            this.input = input;
            this.part = part;
            school = new List<Fish>();
            var initFish = input.Inputs[0].Split(",");
            foreach(var f in initFish)
            {
                school.Add(new Fish(int.Parse(f)));
            }
        }
        public override int Answer
        {
            get
            {
                int daysToLoop = (part == Part.ONE) ? 80 : 256;
                
                for(int i = 0; i < daysToLoop; i++)
                {
                    school.ForEach(fish => fish.ProcDay());
                }
                return school.Count() + school.Sum(x => x.MyFishCount);
            }
        }
    }
    internal class Fish
    {
        private int timer;
        private List<Fish> childFish;
        public Fish(int startingTimer)
        {
            timer = startingTimer;
            childFish = new List<Fish>();
        }
        public void ProcDay()
        {
            childFish.ForEach(fish => fish.ProcDay());

            timer--;
            if(timer < 0)
            {
                timer = 6;
                childFish.Add(new Fish(8));
            }
        }
        public int MyFishCount
        {
            get
            {
                int sum = 0;
                foreach(Fish f in childFish)
                {
                    sum++;
                    sum += f.MyFishCount;
                }
                return sum;
            }
        }
    }
}
