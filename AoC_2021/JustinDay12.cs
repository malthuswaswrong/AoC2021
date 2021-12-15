namespace AdventOfCode2021;
class Day12 {
    static List<(string c1, string c2)> caves;
    public static int D12_1() {
        caves = new();
        IEnumerable<string> data = Questions.LoadData(@"E:\Source\AdventOfCode2021\AdventOfCode2021\Day12.txt");
        foreach (string s in data.Where(x => !String.IsNullOrWhiteSpace(x))) {
            string[] fields = s.Split("-");
            caves.Add((fields[0], fields[1]));
        }
        List<string> routes = Explore("", "start");

        return routes.Count;
    }

    static List<string> Explore(string path, string cave) {
        List<string> routes = new();
        path += ($"-{cave}");
        if (cave == "end") {
            routes.Add(path);
            return routes;  //Found our way to the end
        }
        caves.Where(x => x.c1 == cave).Select(x => x.c2)                            //Get caves where c1 matches this one
            .Union(                                                                 //Union with
            caves.Where(x => x.c2 == cave).Select(x => x.c1))                       //Get caves where c2 matches this one
            .Where(x => !IsVisitedSmallCave2(path, x))                              //remove all visited small caves from list
            .ToList()
            .ForEach(x => routes.AddRange(Explore(path, x)));                       //explore each remaining tunnel

        return routes;
    }

    static bool IsVisitedSmallCave(string path, string cave) => IsSmallCave(cave) && path.Contains(cave);

    static bool IsVisitedSmallCave2(string path, string cave) {
        if (cave == "start") return true;                       //Never revisit start
        if (!IsVisitedSmallCave(path, cave)) return false;      //We've never visited so no problems here
                                                                //Allow second visit if we haven't already hit a small teice
        return path
            .Split("-", StringSplitOptions.RemoveEmptyEntries)  //Split our path into caves
            .Where(x => IsSmallCave(x))                         //remove all non small caves
            .GroupBy(x => x)                                    //group them up by cave name
            .Where(x => x.Count() > 1)                          //Filter to only be ones we've visited twice
            .Any();                                             //If there are any left we have already visited a small 2x
    }
    static bool IsSmallCave(string s) => s == s.ToLower();  //catches start and end too but we don't want to revisit those anyway       
}