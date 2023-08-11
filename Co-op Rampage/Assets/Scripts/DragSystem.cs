using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Vector2 startPosition;

	public Transform parentAfterDrag;

	private CanvasGroup cg;

	private void Start()
	{
		cg = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		startPosition = transform.position;

		parentAfterDrag = transform.parent;
		transform.SetParent(transform.root);
		transform.SetAsLastSibling();

		cg.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}


	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPosition;

		transform.SetParent(parentAfterDrag);

		cg.blocksRaycasts = true;
	}
}
