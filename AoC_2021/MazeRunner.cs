using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;

public class MazeRunner : ChallengeBase {
    private readonly Part part;
    List<Cell> maze;
    long bestFullPathScore;
    List<Cell>? _bestFullPath;
    List<Cell>? BestFullPath {
        get {
            return _bestFullPath;
        }
        set {
            _bestFullPath = value;
            bestFullPathScore = _bestFullPath != null ? _bestFullPath.Sum(c => c.Value) : long.MaxValue;
        }
    }
    Dictionary<Cell, int> deadTails;
    public MazeRunner(ChallengeInput input, Part part) : base(input, part) {
        this.part = part;
        maze = new();
        for (int y = 0; y < input.Inputs.Count(); y++)
            for (int x = 0; x < input.Inputs[y].Length; x++)
                maze.Add(new(x, y, int.Parse(input.Inputs[y][x].ToString())));
        bestFullPathScore = long.MaxValue;
        BestFullPath = null;
        deadTails = new ();
    }

    public override long Answer {
        get {
            Cell origin = maze.Where(c => c.X == 0 && c.Y == 0).First();
            int maxX = maze.Max(c => c.X);
            int maxY = maze.Max(c => c.Y);
            Cell destination = maze.Where(c => c.X == maxX && c.Y == maxY).First();
            List<Cell> path = new() { origin };
            Navigate(origin, destination, path);
            return bestFullPathScore - origin.Value;
        }
    }

    private void Navigate(Cell source, Cell destination, List<Cell> currentPath) {
        Cell? east = maze.Where(c => c.X == source.X + 1 && c.Y == source.Y).FirstOrDefault();
        Cell? south = maze.Where(c => c.X == source.X && c.Y == source.Y + 1).FirstOrDefault();

        if (east == destination) {
            List<Cell> newPath = new() { east };
            newPath.AddRange(currentPath);
            Debug.WriteLine($"CURRENT: {newPath.Sum(c => c.Value)} : {String.Join("<-", newPath.Select(c => $"{c.X},{c.Y}").ToArray())}");
            if (bestFullPathScore > newPath.Sum(c => c.Value))
                BestFullPath = newPath;
            Debug.WriteLine($"BEST: {bestFullPathScore} : {String.Join("<-", BestFullPath.Select(c => $"{c.X},{c.Y}").ToArray())}");
            return;
        }
        if (south == destination) {
            List<Cell> newPath = new() { south };
            newPath.AddRange(currentPath);
            Debug.WriteLine($"CURRENT: {newPath.Sum(c => c.Value)} : {String.Join("<-", newPath.Select(c => $"{c.X},{c.Y}").ToArray())}");
            if (bestFullPathScore > newPath.Sum(c => c.Value))
                BestFullPath = newPath;
            Debug.WriteLine($"BEST   : {bestFullPathScore} : {String.Join("<-", BestFullPath.Select(c => $"{c.X},{c.Y}").ToArray())}");
            return;
        }

        if ((east is not null && deadTails.ContainsKey(east) && deadTails[east] > 1) ||
            (south is not null && deadTails.ContainsKey(south) && deadTails[south] > 1)) return;

        List<Cell> eastPath = null;
        List<Cell> southPath = null;

        long currVal = currentPath.Sum(c => c.Value);
        if (east != null && !currentPath.Contains(east)) {
            if (currVal + east.Value > bestFullPathScore) {
                Debug.WriteLine($"KILL   : {currentPath.Sum(c => c.Value)} : {String.Join("<-", currentPath.Select(c => $"{c.X},{c.Y}").ToArray())}");
                return;
            }

            eastPath = new List<Cell>() { east };
            eastPath.AddRange(currentPath);
            Navigate(east, destination, eastPath);
        }
        if (south != null && !currentPath.Contains(south)) {
            if (currVal + south.Value > bestFullPathScore) {
                Debug.WriteLine($"KILL   : {currentPath.Sum(c => c.Value)} : {String.Join("<-", currentPath.Select(c => $"{c.X},{c.Y}").ToArray())}");
                return;
            }

            southPath = new List<Cell>() { south };
            southPath.AddRange(currentPath);
            Navigate(south, destination, southPath);
        }
    }

    private class Cell {
        public Cell(int x, int y, int value) {
            X = x;
            Y = y;
            Value = value;
        }
        public int X {
            get;
        }
        public int Y {
            get;
        }
        public int Value {
            get;
        }
    }
}

