using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class ChallengeBase : IChallenge
{
    public enum Part
    {
        ONE,
        TWO
    }
    public ChallengeBase(ChallengeInput input, Part part)
    {
    }

    public virtual long Answer => throw new NotImplementedException();
}
