using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021_01_01;
public class Depth
{
    private Dictionary<int, List<int>> depths;
    public Depth()
    {
        depths = new() { { 0, new() } };

    }
    public void AddSingleDepth(string input)
    {
        int.TryParse(input, out int depthInt);
        depths[0].Add(depthInt);
    }
    public void AddMultiDepth(string input)
    {
        int.TryParse(input, out int depthInt);
        int maxIdx = depths.Keys.Max() + 1;
        depths.Add(maxIdx, new() { depthInt });
        for(int i = maxIdx - 1; i >= 0 && depths[i].Count() < 3; i--)
        {
            depths[i].Add(depthInt);
        }
    }
    public int Increaments
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
