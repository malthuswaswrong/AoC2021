using AoC2021;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AoC2021Tests;

public class Day13Tests {
    
    public ChallengeInput AoC2021_13_SampleInput {
        get {
            List<string> list = new List<string>() {
                    "6,10",
                    "0,14",
                    "9,10",
                    "0,3",
                    "10,4",
                    "4,11",
                    "6,0",
                    "6,12",
                    "4,1",
                    "0,13",
                    "10,12",
                    "3,4",
                    "3,0",
                    "8,4",
                    "1,10",
                    "2,14",
                    "8,10",
                    "9,0",
                    "",
                    "fold along y=7",
                    "fold along x=5"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_13_01_Example() {
        IChallenge cut = new PapperFolder(AoC2021_13_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(17, cut.Answer);
    }
    [Fact]
    public void AoC2021_13_01_Challenge() {
        IChallenge cut = new PapperFolder(new ChallengeInput(new StreamReader("Input_AoC2021_13.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(704, cut.Answer);
    }
    [Fact]
    public void AoC2021_13_02_Example() {
        IChallenge cut = new PapperFolder(AoC2021_13_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(16, cut.Answer);
    }
    [Fact]
    public void AoC2021_13_02_Challenge() {
        IChallenge cut = new PapperFolder(new ChallengeInput(new StreamReader("Input_AoC2021_13.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(103, cut.Answer);
    }
}
