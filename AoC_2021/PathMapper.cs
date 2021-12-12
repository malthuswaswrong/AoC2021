using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class PathMapper : ChallengeBase {
    private readonly ChallengeInput input;
    private readonly Part part;
    List<string> nodes;
    List<(string p1, string p2)> paths;

    public PathMapper(ChallengeInput input, Part part) : base(input, part) {
        this.input = input;
        this.part = part;
        nodes = new();
        paths = new List<(string p1, string p2)>();

        this.input.Inputs.ForEach(x => {
            var names = x.Split("-");
            if (!nodes.Contains(names[0]))
                nodes.Add(names[0]);
            if (!nodes.Contains(names[1]))
                nodes.Add(names[1]);
            paths.Add((names[0], names[1]));
            paths.Add((names[1], names[0]));
        });
    }
    public override long Answer => Explore("start");
    
    public long Explore(string path) {
        long results = 0;
        string endNode = path.Split("->").Last();
        foreach (var nextNode in paths.Where(x => x.p1 == endNode).Select(x => x.p2)) {
            if (nextNode == "start") continue;
            if (PathWouldBeInvalid(path, nextNode)) continue;
            string newPath = $"{path}->{nextNode}";
            if (nextNode != "end") {
                results += Explore(newPath);
            } else {
                results++;
            }
        }
        return results;
    }
    private bool PathWouldBeInvalid(string path, string newNode) {
        if (IsSmallCavern(newNode)) {
            List<string> caves = path.Split("->").ToList();
            caves.Add(newNode);
            if (part == Part.ONE) {
                return caves.Count(x => x == newNode) > 1;
            } else {
                Dictionary<string, int> oneCanBeTwice = new Dictionary<string, int>();
                foreach (var cavern in caves.Where(x => IsSmallCavern(x))) {
                    if (!oneCanBeTwice.ContainsKey(cavern))
                        oneCanBeTwice.Add(cavern, 0);
                    oneCanBeTwice[cavern]++;
                }
                if (oneCanBeTwice.Any(x => x.Value > 2))
                    return true;
                if (oneCanBeTwice.Count(x => x.Value > 1) > 1)
                    return true;

                return false;
            }
        } else {
            return false;
        }
    }
    bool IsSmallCavern(string name) {
        return char.IsLower(name[0]);
    }
}
