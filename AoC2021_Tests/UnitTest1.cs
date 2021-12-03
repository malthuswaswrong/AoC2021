using Xunit;
using AoC2021;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System;

namespace AoC2021_Tests
{
    public class UnitTest1
    {
        public ChallengeInput AoC2021_01_SampleInput
        {
            get
            {
                List<string> list = new List<string>(){"199","200","208","210","200","207","240","269","260","263"};
                return new ChallengeInput(list);
            }
        }
        public ChallengeInput AoC2021_02_SampleInput
        {
            get
            {
                List<string> list = new List<string>(){"forward 5","down 5","forward 8","up 3","down 8","forward 2"};
                return new ChallengeInput(list);
            }
        }
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
            IChallenge cut = new Depth(new(new StreamReader("Input_AoC2021_01_01.txt")), ChallengeBase.Part.ONE);
            Assert.Equal(1711, cut.Answer);
        }
        [Fact]
        public void AoC2021_01_02_Challenge()
        {
            IChallenge cut = new Depth(new(new StreamReader("Input_AoC2021_01_01.txt")), ChallengeBase.Part.TWO);
            Assert.Equal(1743, cut.Answer);
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


}