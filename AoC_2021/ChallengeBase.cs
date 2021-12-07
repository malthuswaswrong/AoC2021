using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public abstract class ChallengeBase : IChallenge
{
    public enum Part
    {
        ONE,
        TWO
    }
    public ChallengeBase(ChallengeInput input, Part part)
    {
    }

    public abstract long Answer { get; }
}
