using Xunit;
using AoC2021_01_01;
using System.IO;
using System.Diagnostics;

namespace AoC2021_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AoC2021_01_01_Example()
        {
            Depth cut = new();
            cut.AddSingleDepth("199");
            cut.AddSingleDepth("200");
            cut.AddSingleDepth("208");
            cut.AddSingleDepth("210");
            cut.AddSingleDepth("200");
            cut.AddSingleDepth("207");
            cut.AddSingleDepth("240");
            cut.AddSingleDepth("269");
            cut.AddSingleDepth("260");
            cut.AddSingleDepth("263");

            Assert.Equal(7, cut.Increaments);
        }
        [Fact]
        public void AoC2021_01_02_Example()
        {
            Depth cut = new();
            cut.AddMultiDepth("199");
            cut.AddMultiDepth("200");
            cut.AddMultiDepth("208");
            cut.AddMultiDepth("210");
            cut.AddMultiDepth("200");
            cut.AddMultiDepth("207");
            cut.AddMultiDepth("240");
            cut.AddMultiDepth("269");
            cut.AddMultiDepth("260");
            cut.AddMultiDepth("263");

            Assert.Equal(5, cut.Increaments);
        }

        [Fact]
        public void AoC2021_01_01_Challenge()
        {
            Depth cut = new();
            using StreamReader sr = new StreamReader("Input_AoC2021_01_01.txt");
            while (!sr.EndOfStream) cut.AddSingleDepth(sr.ReadLine());

            Debug.WriteLine(cut.Increaments.ToString());

            Assert.Equal(1711, cut.Increaments);

        }
        [Fact]
        public void AoC2021_01_02_Challenge()
        {
            Depth cut = new();
            using StreamReader sr = new StreamReader("Input_AoC2021_01_01.txt");
            while (!sr.EndOfStream) cut.AddMultiDepth(sr.ReadLine());

            Debug.WriteLine(cut.Increaments.ToString());

            Assert.Equal(1743, cut.Increaments);
        }
    }
}