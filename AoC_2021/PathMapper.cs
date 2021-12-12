namespace AoC2021;
public class PathMapper : ChallengeBase {
    private readonly Part part;
    List<(string p1, string p2)> paths;

    public PathMapper(ChallengeInput input, Part part) : base(input, part) {
        this.part = part;
        paths = new ();

        input.Inputs.ForEach(x => {
            var names = x.Split("-");
            paths.Add((names[0], names[1]));
            paths.Add((names[1], names[0]));
        });
    }
    public override long Answer => Explore("start");

    public long Explore(string path) {
        long results = 0;
        string lastSegment = path.Split("->").Last();
        foreach (var nextNode in paths.Where(x => x.p1 == lastSegment).Select(x => x.p2)) {
            if (nextNode == "start") continue;
            if (PathWouldBeInvalid(path, nextNode)) continue;
            if (nextNode != "end") {
                results += Explore($"{path}->{nextNode}");
            } else {
                results++;
            }
        }
        return results;
    }
    private bool PathWouldBeInvalid(string path, string newNode) {
        if (!IsSmallCavern(newNode)) return false;

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
            if (oneCanBeTwice.Any(x => x.Value > 2)) return true;
            if (oneCanBeTwice.Count(x => x.Value > 1) > 1) return true;

            return false;
        }
    }
    bool IsSmallCavern(string name) {
        return char.IsLower(name[0]);
    }
}
