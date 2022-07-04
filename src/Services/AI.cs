using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class AI
{
    public void MakeStep(GameDto gameDto)
    {
        Dictionary<string, int> counter;

        foreach (var cell in gameDto.Cells)
        {
            
        }
    }
}

public class DSU
{
	private Dictionary<VectorDto, int> depth;
	private Dictionary<VectorDto, int> parents;
	private int groups;
	//private GameDto _gameDto;
	
	/*public DSU(GameDto gameDto)
	{
		_gameDto = gameDto;
	}*/
	/*
	 struct DSUun{
	ll depth[1000005];
	int parents[1000005];
	int groups;
 
	void make_set(int x)
	{
		depth[x] = 1;
		parents[x] = x;
		groups++;
	}
 
	int find_set(int x)
	{
		if (x == parents[x])
			return x;
		return parents[x] = find_set(parents[x]);
	}
 
	void union_sets(int a, int b)
	{
		int root1 = find_set(a);
		int root2 = find_set(b);
		if (root1 == root2)
			return;
		groups--;
		if (depth[root1] >= depth[root2])
		{
			parents[root2] = root1;
			depth[root1] += depth[root2];
		}
		else
		{
			parents[root1] = root2;
			depth[root2] += depth[root1];
		}
	}
};
/// DSU_ends
DSUun dsu;
	 */
}