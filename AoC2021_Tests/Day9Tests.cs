using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day9Tests
{
    public ChallengeInput AoC2021_09_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                    "XXX"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_09_01_Example()
    {
        IChallenge cut = new LaserCrabs(AoC2021_09_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(-1, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_01_Challenge()
    {
        IChallenge cut = new LaserCrabs(new ChallengeInput(new StreamReader("Input_AoC2021_09.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(-1, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_02_Example()
    {
        IChallenge cut = new LaserCrabs(AoC2021_09_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(-1, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_02_Challenge()
    {
        IChallenge cut = new LaserCrabs(new ChallengeInput(new StreamReader("Input_AoC2021_09.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(-1, cut.Answer);
    }
}
