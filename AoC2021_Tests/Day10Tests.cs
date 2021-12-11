using AoC2021;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AoC2021Tests;

public class Day10Tests
{
    public ChallengeInput AoC2021_10_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                    "[({(<(())[]>[[{[]{<()<>>",
                    "[(()[<>])]({[<{<<[]>>(",
                    "{([(<{}[<>[]}>{[]{[(<()>",
                    "(((({<>}<{<{<>}{[]{[]{}",
                    "[[<[([]))<([[{}[[()]]]",
                    "[{[{({}]{}}([{[{{{}}([]",
                    "{<[[]]>}<{[{[{[]{()[[[]",
                    "[<(<(<(<{}))><([]([]()",
                    "<{([([[(<>()){}]>(<<{{",
                    "<{([{{}}[<[[[<>{}]]]>[]]"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_09_01_Example()
    {
        IChallenge cut = new SyntaxChecker(AoC2021_10_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(26397, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_01_Challenge()
    {
        IChallenge cut = new SyntaxChecker(new ChallengeInput(new StreamReader("Input_AoC2021_10.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(311895, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_02_Example()
    {
        IChallenge cut = new SyntaxChecker(AoC2021_10_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(-1, cut.Answer);
    }
    [Fact]
    public void AoC2021_09_02_Challenge()
    {
        IChallenge cut = new SyntaxChecker(new ChallengeInput(new StreamReader("Input_AoC2021_10.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(-1, cut.Answer);
    }
}
