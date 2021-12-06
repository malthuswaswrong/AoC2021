using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class VentTracker : ChallengeBase
{
    private readonly ChallengeInput input;
    private readonly Part part;
    private List<VentLine> floorData;

    public VentTracker(ChallengeInput input, Part part) : base(input, part)
    {
        this.input = input;
        this.part = part;
        floorData = new List<VentLine>();
        foreach (var line in this.input.Inputs)
        {
            var data = FormatInput(line);

            VentLine vAdd;
            if (data.P1.X < data.P2.X)
            {
                vAdd = new VentLine() { Start = data.P1, End = data.P2 };
            }
            else
            {
                if(data.P1.X == data.P2.X)
                {
                    if(data.P1.Y < data.P2.Y)
                        vAdd = new VentLine() { Start = data.P1, End = data.P2 };
                    else
                        vAdd = new VentLine() { Start = data.P2, End = data.P1 };
                }
                else
                {
                    vAdd = new VentLine() { Start = data.P2, End = data.P1 };
                }
            }
                

            if (this.part == Part.ONE)
            {
                if (vAdd.Start.X == vAdd.End.X || vAdd.Start.Y == vAdd.End.Y)
                {
                    floorData.Add(vAdd);
                }
            }
            else
            {
                floorData.Add(vAdd);
            }

        }
    }
    private (Point P1, Point P2) FormatInput(string inputLine)
    {
        var tarr1 = inputLine.Split(" -> ");
        if (tarr1.Length != 2) throw new ArgumentException(nameof(inputLine));
        var tarr2 = tarr1[0].Split(",");
        var tarr3 = tarr1[1].Split(",");
        return (
            new Point(int.Parse(tarr2[0]), int.Parse(tarr2[1])),
            new Point(int.Parse(tarr3[0]), int.Parse(tarr3[1]))
            );
    }
    public override int Answer
    {
        get
        {
            Dictionary<string, int> sums = new Dictionary<string, int>();
            foreach(var line in floorData)
            {
                foreach(var p in line.IntersectingPoints)
                {
                    string key = $"{p.X},{p.Y}";
                    if(!sums.ContainsKey(key)) sums.Add(key, 0);
                    sums[key]++;
                }
            }
            return sums.Count(x => x.Value > 1);
        }
    }
    public class VentLine
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        private List<Point> intersectingPoints = null;
        public List<Point> IntersectingPoints
        {
            get
            {
                if(intersectingPoints != null)
                    return intersectingPoints;

                intersectingPoints = new List<Point>();


                int xDirection = (End.X > Start.X) ? 1 : (End.X == Start.X) ? 0 : -1;
                int yDirection = (End.Y > Start.Y) ? 1 : (End.Y == Start.Y) ? 0 : -1;

                Point cursor = new Point(Start.X, Start.Y);
                while (true)
                {
                    intersectingPoints.Add(cursor);
                    cursor.X += xDirection;
                    cursor.Y += yDirection;
                    if ((cursor.X == End.X && cursor.Y == End.Y) || Math.Abs(cursor.X) > 10000)
                        break;
                }
                intersectingPoints.Add(cursor);

                return intersectingPoints;
            }
        }
        
    }
}
