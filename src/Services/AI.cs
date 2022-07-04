using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class AI
{
    public void MakeStep(GameDto gameDto)
    {
        Dictionary<string, int> counter;
        DSU dsu = new DSU();
        CellDto startPos = null;
        foreach (var cell in gameDto.Cells)
        {
            dsu.make_set(cell);
            if (cell.Pos.X == 0 && cell.Pos.Y == 0)
            {
	            startPos = cell;
            }
        }
        
    }
}

public class DSU
{
	private Dictionary<CellDto, int> depth;
	private Dictionary<CellDto, CellDto> parents;

	public DSU()
	{
		depth = new Dictionary<CellDto, int>();
		parents = new Dictionary<CellDto, CellDto>();
	}

	public void make_set(CellDto x)
	{
		depth[x] = 1;
		parents[x] = x;
	}
	
	public CellDto find_set(CellDto x)
	{
		if (x == parents[x])
			return x;
		return parents[x] = find_set(parents[x]);
	}
	
	void union_sets(CellDto a, CellDto b)
	{
		CellDto root1 = find_set(a);
		CellDto root2 = find_set(b);
		if (root1 == root2)
			return;
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
}