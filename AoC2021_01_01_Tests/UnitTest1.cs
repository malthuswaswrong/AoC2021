using Xunit;
using AoC2021_01_01;
using System.IO;
using System.Diagnostics;

namespace AoC2021_01_01_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Depth cut = new();
            cut.AddDepth("199");
            cut.AddDepth("200");
            cut.AddDepth("208");
            cut.AddDepth("210");
            cut.AddDepth("200");
            cut.AddDepth("207");
            cut.AddDepth("240");
            cut.AddDepth("269");
            cut.AddDepth("260");
            cut.AddDepth("263");

            Assert.Equal(7, cut.Increaments);
        }

        [Fact]
        public void Test2()
        {
            Depth cut = new();
            using StreamReader sr = new StreamReader("Input_AoC2021_01_01.txt");
            while (!sr.EndOfStream) cut.AddDepth(sr.ReadLine());

            Debug.WriteLine(cut.Increaments.ToString());

            Assert.Equal(1711, cut.Increaments);

        }
    }
}