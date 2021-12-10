using AoC2021;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AoC2021Tests;
public class Day8Tests
{
    public ChallengeInput AoC2021_08_TinyInput01
    {
        get
        {
            List<string> list = new List<string>()
            {
                "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput02
    {
        get
        {
            List<string> list = new List<string>()
            {
                "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput03
    {
        get
        {
            List<string> list = new List<string>()
            {
                "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput04
    {
        get
        {
            List<string> list = new List<string>()
            {
                "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput05
    {
        get
        {
            List<string> list = new List<string>()
            {
                "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput06
    {
        get
        {
            List<string> list = new List<string>()
            {
                "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput07
    {
        get
        {
            List<string> list = new List<string>()
            {
                "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput08
    {
        get
        {
            List<string> list = new List<string>()
            {
                "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput09
    {
        get
        {
            List<string> list = new List<string>()
            {
                "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput10
    {
        get
        {
            List<string> list = new List<string>()
            {
                "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_TinyInput11
    {
        get
        {
            List<string> list = new List<string>()
            {
                "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
            };
            return new ChallengeInput(list);
        }
    }
    public ChallengeInput AoC2021_08_SampleInput
    {
        get
        {
            List<string> list = new List<string>() {
                "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
                "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
                "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
                "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
                "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
                "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
                "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
                "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
                "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
                "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
                };
            return new ChallengeInput(list);
        }
    }
    [Fact]
    public void AoC2021_08_01_Example()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_SampleInput, ChallengeBase.Part.ONE);
        Assert.Equal(26, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_01_Challenge()
    {
        IChallenge cut = new BrokenDisplay(new ChallengeInput(new StreamReader("Input_AoC2021_08.txt")), ChallengeBase.Part.ONE);
        Assert.Equal(369, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample01()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput01, ChallengeBase.Part.TWO);
        Assert.Equal(5353, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample02()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput02, ChallengeBase.Part.TWO);
        Assert.Equal(8394, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample03()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput03, ChallengeBase.Part.TWO);
        Assert.Equal(9781, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample04()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput04, ChallengeBase.Part.TWO);
        Assert.Equal(1197, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample05()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput05, ChallengeBase.Part.TWO);
        Assert.Equal(9361, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample06()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput06, ChallengeBase.Part.TWO);
        Assert.Equal(4873, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample07()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput07, ChallengeBase.Part.TWO);
        Assert.Equal(8418, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample08()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput08, ChallengeBase.Part.TWO);
        Assert.Equal(4548, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample09()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput09, ChallengeBase.Part.TWO);
        Assert.Equal(1625, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample10()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput10, ChallengeBase.Part.TWO);
        Assert.Equal(8717, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_TinyExample11()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_TinyInput11, ChallengeBase.Part.TWO);
        Assert.Equal(4315, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_Example()
    {
        IChallenge cut = new BrokenDisplay(AoC2021_08_SampleInput, ChallengeBase.Part.TWO);
        Assert.Equal(61229, cut.Answer);
    }
    [Fact]
    public void AoC2021_08_02_Challenge()
    {
        IChallenge cut = new BrokenDisplay(new ChallengeInput(new StreamReader("Input_AoC2021_08.txt")), ChallengeBase.Part.TWO);
        Assert.Equal(1031553, cut.Answer);
    }
}
