using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;

public class Day14Tests {
    [Fact]
    public void AoC2021_14_01_Example() {
        IChallenge cut = new PolymerInserts(new ChallengeInput(new StreamReader("Example_AoC2021_14.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(1588, cut.Answer);
    }
    [Fact]
    public void AoC2021_14_01_Challenge() {
        IChallenge cut = new PolymerInserts(new ChallengeInput(new StreamReader("Input_AoC2021_14.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(2590, cut.Answer);
    }
    [Fact]
    public void AoC2021_14_02_Example() {
        IChallenge cut = new PolymerInserts(new ChallengeInput(new StreamReader("Example_AoC2021_14.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(2188189693529, cut.Answer);
    }
    [Fact]
    public void AoC2021_14_02_Challenge() {
        IChallenge cut = new PolymerInserts(new ChallengeInput(new StreamReader("Input_AoC2021_14.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(2875665202438, cut.Answer);
    }
}
