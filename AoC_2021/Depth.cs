namespace AoC2021;
public class Depth : ChallengeBase
{
    private Dictionary<int, List<int>> depths;
    public Depth(ChallengeInput input, Part part) : base(input, part)
    {
        depths = new() { { 0, new() } };
        if(part == Part.ONE)
        {
            input.Inputs.ForEach(x => AddSingleDepth(x));
        }
        else
        {
            input.Inputs.ForEach(x => AddMultiDepth(x));
        }
    }
    private void AddSingleDepth(string input)
    {
        depths[0].Add(int.Parse(input));
    }
    private void AddMultiDepth(string input)
    {
        int.TryParse(input, out int depthInt);
        int maxIdx = depths.Keys.Max() + 1;
        depths.Add(maxIdx, new() { depthInt });
        for (int i = maxIdx - 1; i >= 0 && depths[i].Count() < 3; i--)
            depths[i].Add(depthInt);
    }
    public override int Answer
    {
        get 
        {
            int result = 0;
            int? lastDepth = null;
            if (depths.Count == 1)
            {
                foreach (int depth in depths[0])
                {
                    if (lastDepth is not null && lastDepth < depth) result++;
                    lastDepth = depth;
                }
            }
            else
            {
                foreach (var g in depths.Keys)
                {
                    int depth = depths[g].Sum();
                    if (lastDepth is not null && lastDepth < depth) result++;
                    lastDepth = depth;
                }
            }
            return result;
        }
    }
}
