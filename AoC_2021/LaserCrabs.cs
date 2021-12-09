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

            int lowestCrabDistance = int.MaxValue;
            int currentCrabMoveDistance = 0;

            int minSearch = crabPositions.Min(x => x);
            int maxSearch = crabPositions.Max(x => x);
            for (int i = minSearch; i < crabPositions.Count; i++)
            {
                currentCrabMoveDistance = crabPositions.Sum(x => fuelCalc(x, i));
                if (currentCrabMoveDistance < lowestCrabDistance)
                    lowestCrabDistance = currentCrabMoveDistance;
            }
            return lowestCrabDistance;
        }
    }
    private int fuelCalc(int current, int check)
    {
        if(part == Part.ONE)
        {
            return Math.Abs(current - check);
        }
        else
        {
            int dist = Math.Abs(current - check);
            int cost = 1;
            int fuel = 0;
            for(int i = 0; i < dist; i++)
            {
                fuel+=cost;
                cost++;
            }
            return fuel;
        }
    }
}
