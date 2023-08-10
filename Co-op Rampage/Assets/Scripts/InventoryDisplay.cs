using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
	private Inventory iv;

	public GameObject slot1W;
	public GameObject slot2W;
	private Animator an1W;
	private Animator an2W;

	public GameObject imageSlot1W;
	public GameObject imageSlot2W;
	private Image im1W;
	private Image im2W;

	public GameObject slot1I;
	public GameObject slot2I;
	private Animator an1I;
	private Animator an2I;

	public GameObject imageSlot1I;
	public GameObject imageSlot2I;
	private Image im1I;
	private Image im2I;

	private void Start()
	{
		iv = FindObjectOfType<Inventory>().GetComponent<Inventory>();

		an1W = slot1W.GetComponent<Animator>();
		an2W = slot2W.GetComponent<Animator>();

		im1W = imageSlot1W.GetComponent<Image>();
		im2W = imageSlot2W.GetComponent<Image>();

		imageSlot1W.SetActive(false);
		imageSlot2W.SetActive(false);

		an1I = slot1I.GetComponent<Animator>();
		an2I = slot2I.GetComponent<Animator>();

		im1I = imageSlot1I.GetComponent<Image>();
		im2I = imageSlot2I.GetComponent<Image>();

		imageSlot1I.SetActive(false);
		imageSlot2I.SetActive(false);
	}

	private void Update()
	{
		an1W.SetInteger("Active Slot", iv.activeWeaponSlot);
		an2W.SetInteger("Active Slot", iv.activeWeaponSlot);

		if (iv.weaponInventory.Count > 0)
		{
			if (iv.weaponInventory[0] != null)
			{
				imageSlot1W.SetActive(true);
				im1W.sprite = iv.weaponInventory[0].sprite;
			}
			else
			{
				imageSlot1W.SetActive(false);
			}

			if (iv.weaponInventory[1] != null)
			{
				imageSlot2W.SetActive(true);
				im2W.sprite = iv.weaponInventory[1].sprite;
			}
			else
			{
				imageSlot2W.SetActive(false);
			} 
		}

		an1I.SetInteger("Active Slot Item", iv.activeItemSlot);
		an2I.SetInteger("Active Slot Item", iv.activeItemSlot);

		if (iv.itemInventory.Count > 0)
		{
			if (iv.itemInventory[0] != null)
			{
				imageSlot1I.SetActive(true);
				im1I.sprite = iv.itemInventory[0].sprite;
			}
			else
			{
				imageSlot1I.SetActive(false);
			}

			if (iv.itemInventory[1] != null)
			{
				imageSlot2I.SetActive(true);
				im2I.sprite = iv.itemInventory[1].sprite;
			}
			else
			{
				imageSlot2I.SetActive(false);
			}
		}
	}
}
