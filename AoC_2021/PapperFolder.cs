using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class PapperFolder : ChallengeBase {
    private readonly Part part;
    List<Point> marks;
    List<Point> folds;
    public PapperFolder(ChallengeInput input, Part part) : base(input, part) {
        this.part = part;
        marks = new();
        folds = new();
        foreach (var line in input.Inputs) {
            if (String.IsNullOrEmpty(line)) continue;
            if (line.StartsWith("fold along")) {
                var coord = line.Split(" ").Last();
                var tarr = coord.Split("=");
                Point tPoint = (tarr[0] == "y") ? new Point(-1, int.Parse(tarr[1])) : new Point(int.Parse(tarr[1]), -1);
                folds.Add(tPoint);
            } else {
                var tarr = line.Split(",");
                Point tPoint = new Point(int.Parse(tarr[0]), int.Parse(tarr[1]));
                marks.Add(tPoint);
            }
        }

    }

    public override long Answer {
        get {
            if (part == Part.ONE) {
                var firstFold = folds[0];
                Fold(firstFold);
                return marks.Count();
            } else {
                int i = 1;
                foreach (var fold in folds) {
                    Fold(fold);
                    DumpMarks($@"c:\temp\paper{i++}.txt");
                }
                
                return marks.Count();
            }


            void Fold(Point pivotPoint) {
                List<Point> movingMarks;
                if (pivotPoint.X < 0) {
                    //Folding horizontally
                    movingMarks = marks.Where(mark => mark.Y > pivotPoint.Y).ToList();
                    for (int i = 0; i < movingMarks.Count(); i++) {
                        var p = new Point(movingMarks[i].X, movingMarks[i].Y - ((movingMarks[i].Y - pivotPoint.Y) * 2));
                        if (marks.Count(m => m.X == p.X && m.Y == p.Y) == 0)
                            marks.Add(p);
                    }
                } else {
                    //Folding vertically
                    movingMarks = marks.Where(mark => mark.X > pivotPoint.X).ToList();
                    for (int i = 0; i < movingMarks.Count(); i++) {
                        var p = new Point(movingMarks[i].X - ((movingMarks[i].X - pivotPoint.X) * 2), movingMarks[i].Y);
                        if (marks.Count(m => m.X == p.X && m.Y == p.Y) == 0)
                            marks.Add(p);
                    }
                }
                movingMarks.ForEach(m => marks.Remove(m));
            }

            void DumpMarks(string filename) {
                using StreamWriter sw = new StreamWriter(filename, false);
                int maxX = marks.Max(m => m.X);
                int maxY = marks.Max(m => m.Y);
                for (int y = 0; y <= maxY; y++) {
                    for (int x = 0; x <= maxX; x++) {
                        bool isMark = marks.Any(p => p.X == x && p.Y == y);
                        if (isMark) {
                            sw.Write("#");
                        } else {
                            sw.Write(" ");
                        }
                    }
                    sw.WriteLine("");
                }
            }
        }
    }
}
