using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021_01_01;
public class Depth
{
    private List<int> depths;
    public Depth()
    {
        depths = new();
    }
    public void AddDepth(string depth)
    {
        if(int.TryParse(depth, out int depthInt))
            depths.Add(depthInt);
    }
    public int Increaments
    {
        get
        {
            int? lastDepth = null;
            int result = 0;
            foreach (int depth in depths)
            {
                if (lastDepth is not null && lastDepth < depth) result++;
                lastDepth = depth;
            }
            return result;
        }
        
    }
}
