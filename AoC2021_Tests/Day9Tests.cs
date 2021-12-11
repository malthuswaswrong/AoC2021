using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day09Tests
{
    public ChallengeInput AoC2021_09_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                    "2199943210",
                    "3987894921",
                    "9856789892",
                    "8767896789",
                    "9899965678"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_09_01_Example()
    {
        IChallenge cut = new SmokeVents(AoC2021_09_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(15, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_01_Challenge()
    {
        IChallenge cut = new SmokeVents(new ChallengeInput(new StreamReader("Input_AoC2021_09.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(607, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_02_Example()
    {
        IChallenge cut = new SmokeVents(AoC2021_09_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(1134, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_02_Challenge()
    {
        IChallenge cut = new SmokeVents(new ChallengeInput(new StreamReader("Input_AoC2021_09.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(900864, cut.Answer);
    }
}
