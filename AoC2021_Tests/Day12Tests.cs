using AoC2021;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AoC2021Tests;

public class Day12Tests {
    public ChallengeInput AoC2021_12_SampleInput_Tiny1 {
        get {
            List<string> list = new List<string>();
            list.Add("start-A");
            list.Add("start-b");
            list.Add("A-c");
            list.Add("A-b");
            list.Add("b-d");
            list.Add("A-end");
            list.Add("b-end");
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_12_SampleInput_Tiny2 {
        get {
            List<string> list = new List<string>();
            list.Add("dc-end");
            list.Add("HN-start");
            list.Add("start-kj");
            list.Add("dc-start");
            list.Add("dc-HN");
            list.Add("LN-dc");
            list.Add("HN-end");
            list.Add("kj-sa");
            list.Add("kj-HN");
            list.Add("kj-dc");
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_12_SampleInput {
        get {
            List<string> list = new List<string>() {
                    "fs-end",
                    "he-DX",
                    "fs-he",
                    "start-DX",
                    "pj-DX",
                    "end-zg",
                    "zg-sl",
                    "zg-pj",
                    "pj-he",
                    "RW-he",
                    "fs-DX",
                    "pj-RW",
                    "zg-RW",
                    "start-pj",
                    "he-WI",
                    "zg-he",
                    "pj-fs",
                    "start-RW"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_12_01_Example_Tiny1() {
        IChallenge cut = new PathMapper(AoC2021_12_SampleInput_Tiny1, ChallengeBase.Part.ONE);
        Assert.Equal(10, cut.Answer);
    }
    [Fact]
    public void AoC2021_12_01_Example_Tiny2() {
        IChallenge cut = new PathMapper(AoC2021_12_SampleInput_Tiny2, ChallengeBase.Part.ONE);
        Assert.Equal(19, cut.Answer);
    }
    [Fact]
    public void AoC2021_12_01_Example() {
        IChallenge cut = new PathMapper(AoC2021_12_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(226, cut.Answer);
    }
    [Fact]
    public void AoC2021_12_01_Challenge() {
        IChallenge cut = new PathMapper(new ChallengeInput(new StreamReader("Input_AoC2021_12.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(3000, cut.Answer);
    }
    [Fact]
    public void AoC2021_12_02_Example_Tiny1() {
        IChallenge cut = new PathMapper(AoC2021_12_SampleInput_Tiny1, ChallengeBase.Part.TWO);
        Assert.Equal(36, cut.Answer);
    }
    [Fact]
    public void AoC2021_12_02_Example() {
        IChallenge cut = new PathMapper(AoC2021_12_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(3509, cut.Answer);
    }
    [Fact]
    public void AoC2021_12_02_Challenge() {
        IChallenge cut = new PathMapper(new ChallengeInput(new StreamReader("Input_AoC2021_12.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(74222, cut.Answer);
    }
}
