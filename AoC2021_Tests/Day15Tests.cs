using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;

public class Day15Tests {
    [Fact]
    public void AoC2021_15_01_Example() {
        IChallenge cut = new MazeRunner(new ChallengeInput(new StreamReader("Example_AoC2021_15.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(40, cut.Answer);
    }
    [Fact]
    public void AoC2021_15_01_Challenge() {
        IChallenge cut = new MazeRunner(new ChallengeInput(new StreamReader("Input_AoC2021_15.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(0, cut.Answer);
    }
    [Fact]
    public void AoC2021_15_02_Example() {
        IChallenge cut = new MazeRunner(new ChallengeInput(new StreamReader("Example_AoC2021_15.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(0, cut.Answer);
    }
    [Fact]
    public void AoC2021_15_02_Challenge() {
        IChallenge cut = new MazeRunner(new ChallengeInput(new StreamReader("Input_AoC2021_15.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(0, cut.Answer);
    }
}
