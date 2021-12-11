using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day03Tests
{
    public ChallengeInput AoC2021_03_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                    "00100",
                    "11110",
                    "10110",
                    "10111",
                    "10101",
                    "01111",
                    "00111",
                    "11100",
                    "10000",
                    "11001",
                    "00010",
                    "01010"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_03_01_Example()
    {
        IChallenge cut = new DiagnosticsSub(AoC2021_03_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(198, cut.Answer);
    }
    [Fact]
    public void AoC2021_03_01_Challenge()
    {
        IChallenge cut = new DiagnosticsSub(new ChallengeInput(new StreamReader("Input_AoC2021_03.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(2972336, cut.Answer);
    }
    [Fact]
    public void AoC2021_03_02_Example()
    {
        IChallenge cut = new DiagnosticsSub(AoC2021_03_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(23, ((DiagnosticsSub)cut).O2);
        Assert.Equal(10, ((DiagnosticsSub)cut).CO2);
        Assert.Equal(230, cut.Answer);
    }
    [Fact]
    public void AoC2021_03_02_Challenge()
    {
        IChallenge cut = new DiagnosticsSub(new ChallengeInput(new StreamReader("Input_AoC2021_03.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(3368358, cut.Answer);
    }
}
