using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
	private Inventory iv;

	public GameObject slot1;
	public GameObject slot2;

	private Animator an1;
	private Animator an2;

	public GameObject imageSlot1;
	public GameObject imageSlot2;

	private Image im1;
	private Image im2;

	private void Start()
	{
		iv = FindObjectOfType<Inventory>().GetComponent<Inventory>();

		an1 = slot1.GetComponent<Animator>();
		an2 = slot2.GetComponent<Animator>();

		im1 = imageSlot1.GetComponent<Image>();
		im2 = imageSlot2.GetComponent<Image>();

		imageSlot1.SetActive(false);
		imageSlot2.SetActive(false);
	}

	private void Update()
	{
		an1.SetInteger("Active Slot", iv.activeWeaponSlot);
		an2.SetInteger("Active Slot", iv.activeWeaponSlot);

		if (iv.weaponInventory.Count > 0)
		{
			if (iv.weaponInventory[0] != null)
			{
				imageSlot1.SetActive(true);
				im1.sprite = iv.weaponInventory[0].sprite;
			}
			else
			{
				imageSlot1.SetActive(false);
			}

			if (iv.weaponInventory[1] != null)
			{
				imageSlot2.SetActive(true);
				im2.sprite = iv.weaponInventory[1].sprite;
			}
			else
			{
				imageSlot2.SetActive(false);
			} 
		}
	}
}
