using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsSpawn : MonoBehaviour
{
	public Grid grid;

    public GameObject[] chests = new GameObject[3];

	public Vector3Int[] positions;

	public void Start()
	{
		CreateChesses();
	}

	public void CreateChesses()
	{

		foreach (var position in positions)
		{
			Vector2 newPos = grid.CellToWorld(position);
			newPos += new Vector2(0.5f, 0.6f);
			Instantiate(chests[Random.Range(0, chests.Length)], newPos, Quaternion.identity);
		}
	}
}
