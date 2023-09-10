using UnityEngine;

public class PositionChildrenAtZero : MonoBehaviour
{
	void Update()
	{
		int childCount = transform.childCount;

		for (int i = 0; i < childCount; i++)
		{
			Transform childTransform = transform.GetChild(i);
			childTransform.localPosition = Vector3.zero;
		}
	}
}
