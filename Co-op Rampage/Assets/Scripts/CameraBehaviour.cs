using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	public GameObject player;

	private Vector3 position;

	void Update()
	{
		position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);

		transform.SetPositionAndRotation(position, Quaternion.identity);
	}
}
