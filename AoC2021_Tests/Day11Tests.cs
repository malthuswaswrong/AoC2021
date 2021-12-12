using AoC2021;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AoC2021Tests;

public class Day11Tests {
    public ChallengeInput AoC2021_11_SampleInput {
        get {
            List<string> list = new List<string>() {
                    "5483143223",
                    "2745854711",
                    "5264556173",
                    "6141336146",
                    "6357385478",
                    "4167524645",
                    "2176841721",
                    "6882881134",
                    "4846848554",
                    "5283751526"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_11_01_Example() {
        IChallenge cut = new DumboFlash(AoC2021_11_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(1656, cut.Answer);
    }
    [Fact]
    public void AoC2021_11_01_Challenge() {
        IChallenge cut = new DumboFlash(new ChallengeInput(new StreamReader("Input_AoC2021_11.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(1773, cut.Answer);
    }
    [Fact]
    public void AoC2021_11_02_Example() {
        IChallenge cut = new DumboFlash(AoC2021_11_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(195, cut.Answer);
    }
    [Fact]
    public void AoC2021_11_02_Challenge() {
        IChallenge cut = new DumboFlash(new ChallengeInput(new StreamReader("Input_AoC2021_11.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(494, cut.Answer);
    }
}
