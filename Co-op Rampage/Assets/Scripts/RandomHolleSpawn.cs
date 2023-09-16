using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomHolleSpawn : MonoBehaviour
{
	private Grid grid;

	public Vector2Int[] start;
	public Vector2Int[] end;

	private Tilemap tilemap;
	public Tile[] tiles = new Tile[2];

	public List<Vector3Int> allTiles;

	public GameObject particle;
	private ParticleSystem ps;

	public GameObject triggerObject;
	public BoxCollider2D bc;

	private void Start()
	{
		grid = GetComponentInParent<Grid>();

		tilemap = GetComponent<Tilemap>();

		for (int i = 0; i < start.Length; i++)
		{
			for (int x = start[i].x; x <= end[i].x; x++)
			{
				for (int y = start[i].y; y >= end[i].y; y--)
				{
					allTiles.Add(new Vector3Int(x, y));
				}
			}
		}
	}
	public IEnumerator CreateHolle()
	{
		yield return new WaitForSeconds(2f);

		Vector3Int position = allTiles[Random.Range(0, allTiles.Count)];

		tilemap.SetTile(position, tiles[Random.Range(0, tiles.Length)]);

		triggerObject = new GameObject("TriggerColliderOfHolle");

		triggerObject.AddComponent<BoxCollider2D>();

		bc = triggerObject.GetComponent<BoxCollider2D>();

		bc.isTrigger = true;
		bc.size = new(1f, 1f);
		bc.offset = Vector2.zero;

		Vector2 newPos = grid.CellToWorld(position);
		newPos += new Vector2(0.5f, 0.5f);
		triggerObject.transform.position = newPos;

		particle = Instantiate(particle, newPos, Quaternion.identity);

		ps = particle.GetComponent<ParticleSystem>();

		ps.Play();

		triggerObject.AddComponent<Holle>();
	}
}
