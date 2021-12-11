using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class SmokeVents : ChallengeBase
{
    private readonly ChallengeInput input;
    private readonly Part part;
    private List<Cell> cells;
    public SmokeVents(ChallengeInput input, Part part) : base(input, part)
    {
        this.input = input;
        this.part = part;
        cells = new List<Cell>();
        for (int y = 0; y < input.Inputs.Count(); y++)
            for (int x = 0; x < input.Inputs[y].Length; x++)
                cells.Add(new Cell(
                        location: new Point(x, y),
                        height: int.Parse(input.Inputs[y][x].ToString()),
                        allCells: ref cells));

    }

    public override long Answer
    {
        get
        {
            if (part == Part.ONE)
            {
                return cells.Where(x => x.IsBasinOrigin).Sum(y => y.Height + 1);
            }
            else
            {
                Dictionary<Cell, int> basins = new ();
                foreach(var origin in cells.Where(cell => cell.IsBasinOrigin).ToList())
                {
                    List<Cell> storage = new List<Cell>();
                    origin.GetBasin(ref storage);
                    basins.Add(origin, storage.Count());
                }
                var orderedBasins = basins.OrderByDescending(kp => kp.Value).ToList();
                int answer = 0;
                for(int i = 0; i < orderedBasins.Count && i < 3; i++)
                {
                    answer = (answer == 0) ? orderedBasins[i].Value : answer * orderedBasins[i].Value;
                }
                return answer;
            }
            
        }
    }

    private class Cell
    {
        private Point Location { get; set; }
        public int Height { get; set; }
        private List<Cell> allCells;

        private Cell Up => allCells.Where(cell => cell.Location.X == Location.X && cell.Location.Y == Location.Y - 1).FirstOrDefault(new Cell());
        
        private Cell Right => allCells.Where(cell => cell.Location.X == Location.X + 1 && cell.Location.Y == Location.Y).FirstOrDefault(new Cell());
        
        private Cell Down => allCells.Where(cell => cell.Location.X == Location.X && cell.Location.Y == Location.Y + 1).FirstOrDefault(new Cell());
        
        private Cell Left => allCells.Where(cell => cell.Location.X == Location.X - 1 && cell.Location.Y == Location.Y).FirstOrDefault(new Cell());
        

        public bool IsBasinOrigin => Height < Up.Height && Height < Right.Height && Height < Down.Height && Height < Left.Height;
        
        public void GetBasin(ref List<Cell> result)
        {
            if(Height < 9)
            {
                UniqAdd(ref result, this);
                if (!result.Contains(this.Up) && this.Up.Height < 9)
                    this.Up.GetBasin(ref result);
                if (!result.Contains(this.Right) && this.Right.Height < 9)
                    this.Right.GetBasin(ref result);
                if (!result.Contains(this.Down) && this.Down.Height < 9)
                    this.Down.GetBasin(ref result);
                if (!result.Contains(this.Left) && this.Left.Height < 9)
                    this.Left.GetBasin(ref result);
            }
        }
        private void UniqAdd(ref List<Cell> result, Cell addCandidate)
        {
            if(!result.Any(cell => cell.Equals(addCandidate)))
                result.Add(addCandidate);
        }

        public Cell(Point location, int height, ref List<Cell> allCells)
        {
            Location = location;
            Height = height;
            this.allCells = allCells;
        }
        public Cell()
        {
            Location = new Point(-10, -10);
            Height = int.MaxValue;
            allCells = new List<Cell>();
        }

    }
}
