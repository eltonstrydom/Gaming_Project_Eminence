using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Inventory inv;
	string id;
	Image image;

	int inventorySlotNum;

	public static GameObject itemBeingDragged;
	Vector3 startPostion;

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;				//Gets the inventory slot that is being dragged
		startPostion = transform.position;			//Gets the start postion of the slot

		image = gameObject.GetComponent<Image>();	//Find the image that is being dragged.
		id = image.sprite.name;						//Gets the potionID of the item being dragged

		string gameobjectName = gameObject.name;

		if (gameobjectName != null || gameobjectName != "")
		{
			switch (gameobjectName) 
			{
			case "ItemImage_0": 
				inventorySlotNum = 0;
				inv.items [0, 4] = 1.ToString ();
				break;
			case "ItemImage_1":
				inventorySlotNum = 1;
				inv.items [1, 4] = 1.ToString ();
				break;
			case "ItemImage_2": 
				inventorySlotNum = 2;
				inv.items [2, 4] = 1.ToString ();
				break;
			case "ItemImage_3":
				inventorySlotNum = 3;
				inv.items [3, 4] = 1.ToString ();
				break;
			case "ItemImage_4": 
				inventorySlotNum = 4;
				inv.items [4, 4] = 1.ToString ();
				break;
			case "ItemImage_5":
				inventorySlotNum = 5;
				inv.items [5, 4] = 1.ToString ();
				break;
			}
		}




	}

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;			
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null;				//No longer has any inventory slot being dragged

		if ( transform.position != startPostion) 
		{
			inv.RemoveItem (id);					//Removes the item from the inventory if it had been dragged off the panel
			transform.position = startPostion;
		}
	}
}
