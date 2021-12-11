using Xunit;
using AoC2021;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System;

namespace AoC2021Tests;
public class Day01Tests
{
    public ChallengeInput AoC2021_01_SampleInput
    {
        get
        {
            List<string> list = new List<string>() { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void CreateAChallengeInput()
    {
        List<string> input = new List<string>() {
                "one",
                "Two",
                "THREE"
            };

        ChallengeInput cut = new(input, (input) => { return input.ToUpper(); });
        Assert.NotNull(cut);
        Assert.Equal(3, cut.Inputs.Count);
        Assert.True(Char.IsUpper(cut.Inputs[0][0]));

        cut = new(input);
        Assert.NotNull(cut);
        Assert.Equal(3, cut.Inputs.Count);
        Assert.False(Char.IsUpper(cut.Inputs[0][0]));
    }

    [Fact]
    public void AoC2021_01_01_Example()
    {
        IChallenge cut = new Depth(AoC2021_01_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(7, cut.Answer);
    }
    [Fact]
    public void AoC2021_01_02_Example()
    {
        IChallenge cut = new Depth(AoC2021_01_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(5, cut.Answer);
    }
    [Fact]
    public void AoC2021_01_01_Challenge()
    {
        IChallenge cut = new Depth(new(new StreamReader("Input_AoC2021_01.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(1711, cut.Answer);
    }
    [Fact]
    public void AoC2021_01_02_Challenge()
    {
        IChallenge cut = new Depth(new(new StreamReader("Input_AoC2021_01.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(1743, cut.Answer);
    }
}