using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day6Tests
{
    public ChallengeInput AoC2021_06_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                    "3,4,3,1,2"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_06_01_Example()
    {
        IChallenge cut = new FishCounter(AoC2021_06_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(5934, cut.Answer);
    }
    [Fact]
    public void AoC2021_06_01_Challenge()
    {
        IChallenge cut = new FishCounter(new ChallengeInput(new StreamReader("Input_AoC2021_06.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(363101, cut.Answer);
    }
    [Fact]
    public void AoC2021_06_02_Example()
    {
        IChallenge cut = new FishCounter(AoC2021_06_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(26984457539, cut.Answer);
    }
    [Fact]
    public void AoC2021_06_02_Challenge()
    {
        IChallenge cut = new FishCounter(new ChallengeInput(new StreamReader("Input_AoC2021_06.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(1644286074024, cut.Answer);
    }
}
