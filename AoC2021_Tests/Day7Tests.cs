using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day07Tests
{
    public ChallengeInput AoC2021_07_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                    "16,1,2,0,4,2,7,1,2,14"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_07_01_Example()
    {
        IChallenge cut = new LaserCrabs(AoC2021_07_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(37, cut.Answer);
    }
    [Fact]
    public void AoC2021_07_01_Challenge()
    {
        IChallenge cut = new LaserCrabs(new ChallengeInput(new StreamReader("Input_AoC2021_07.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(357353, cut.Answer);
    }
    [Fact]
    public void AoC2021_07_02_Example()
    {
        IChallenge cut = new LaserCrabs(AoC2021_07_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(168, cut.Answer);
    }
    [Fact]
    public void AoC2021_07_02_Challenge()
    {
        IChallenge cut = new LaserCrabs(new ChallengeInput(new StreamReader("Input_AoC2021_07.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(104822130, cut.Answer);
    }
}
