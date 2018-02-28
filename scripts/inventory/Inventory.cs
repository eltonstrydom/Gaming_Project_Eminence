using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public string[,] items = new string[6, 6];

	GameObject go;
	Image image;

    int startVal = 1;

	public void AddItem(string itemID, int itemNum, string itemName, string itemDesc, string iconId)
    {
		bool found = false;

        for (int r = 0; r < items.GetLength(0); r++)
        {
            if (items[r, 0] == itemID)
            {
				found = true;

				int value = int.Parse(items [r, 4]);
				value = value + 1;
				items[r, 4] = value.ToString();

				go = GameObject.Find ("ItemText_" + r);
				go.GetComponent<Text> ().text = items [r, 4];
            }
        }

		if (!found) 
		{
			for (int r = 0; r < items.GetLength (0); r++) 
			{
				if (items [r, 0] == null) 
				{
					items [r, 0] = itemID;

					for (int c = 1; c < items.GetLength (1); c++) 
					{
						items [r, 1] = itemNum.ToString ();
						items [r, 2] = itemName;
						items [r, 3] = itemDesc;
						items [r, 4] = startVal.ToString ();
						items [r, 5] = iconId;
					}

					go = GameObject.Find ("ItemImage_" + r);
					go.GetComponent<Image> ().sprite	= Resources.Load<Sprite> ("ItemIcons/" + iconId);
					image = go.GetComponent<Image> ();
					image.enabled = true;

					go = GameObject.Find ("ItemText_" + r);
					go.GetComponent<Text> ().text = items [r, 4];

					return;
				}
			}
		}

	}

	public void RemoveItem(string itemID)
    {
		for (int r = 0; r < items.GetLength (0); r++) 
		{
			if (items [r, 0] == itemID) 
			{
				int value = int.Parse(items [r, 4]);

				if (value > 1) 
				{
					value = value - 1;
					items [r, 4] = value.ToString ();

					go = GameObject.Find ("ItemText_" + r);
					go.GetComponent<Text> ().text = items [r, 4];
				} 
				else 
				{
					for (int c = 0; c < items.GetLength (1); c++) 
					{
						items [r, c] = null;
					}

					go = GameObject.Find ("ItemImage_" + r);
					image = go.GetComponent<Image> ();
					image.enabled = false;

					go = GameObject.Find ("ItemText_" + r);
					go.GetComponent<Text> ().text = " ";
				}
				return;
			}
		}
    }
}
