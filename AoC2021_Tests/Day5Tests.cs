using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day5Tests
{
    public ChallengeInput AoC2021_05_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                    "0,9 -> 5,9",
                    "8,0 -> 0,8",
                    "9,4 -> 3,4",
                    "2,2 -> 2,1",
                    "7,0 -> 7,4",
                    "6,4 -> 2,0",
                    "0,9 -> 2,9",
                    "3,4 -> 1,4",
                    "0,0 -> 8,8",
                    "5,5 -> 8,2"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_05_01_Example()
    {
        IChallenge cut = new VentTracker(AoC2021_05_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(5, cut.Answer);
    }
    [Fact]
    public void AoC2021_05_01_Challenge()
    {
        IChallenge cut = new VentTracker(new ChallengeInput(new StreamReader("Input_AoC2021_05.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(4655, cut.Answer);
    }
    [Fact]
    public void AoC2021_05_02_Example()
    {
        IChallenge cut = new VentTracker(AoC2021_05_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(12, cut.Answer);
    }
    [Fact]
    public void AoC2021_05_02_Challenge()
    {
        IChallenge cut = new VentTracker(new ChallengeInput(new StreamReader("Input_AoC2021_05.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(20500, cut.Answer);
    }
}
