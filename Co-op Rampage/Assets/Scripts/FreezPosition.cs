using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezPosition : MonoBehaviour
{
	private void Update()
	{
		gameObject.transform.position = new Vector3(0f, 0f, 0f);
	}
}
