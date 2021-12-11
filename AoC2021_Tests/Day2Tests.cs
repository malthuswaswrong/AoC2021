using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day02Tests
{
    public ChallengeInput AoC2021_02_SampleInput
    {
        get
        {
            List<string> list = new List<string>() { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_02_01_Example()
    {
        IChallenge cut = new NavigatingSub(AoC2021_02_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(150, cut.Answer);
    }
    [Fact]
    public void AoC2021_02_01_Challenge()
    {
        IChallenge cut = new NavigatingSub(new ChallengeInput(new StreamReader("Input_AoC2021_02.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(1840243, cut.Answer);
    }
    [Fact]
    public void AoC2021_02_02_Example()
    {
        IChallenge cut = new NavigatingSub(AoC2021_02_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(900, cut.Answer);
    }

    [Fact]
    public void AoC2021_02_02_Challenge()
    {
        IChallenge cut = new NavigatingSub(new ChallengeInput(new StreamReader("Input_AoC2021_02.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(1727785422, cut.Answer);
    }
}
