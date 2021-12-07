using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class LaserCrabs : ChallengeBase
{
    private readonly ChallengeInput input;
    private readonly Part part;
    List<int> crabPositions;
    public LaserCrabs(ChallengeInput input, Part part) : base(input, part)
    {
        this.input = input;
        this.part = part;

        crabPositions = new();

        input.Inputs[0]
            .Split(",")
            .ToList()
            .ForEach(x => crabPositions.Add(int.Parse(x)));

    }
    public override long Answer
    {
        get
        {
            int mid = (int)crabPositions.Average();
            int totalCrabMoveDistance = 0;
            foreach(int crab in crabPositions)
                totalCrabMoveDistance += Math.Abs(crab - mid);
            return totalCrabMoveDistance;
        }
    }
}
