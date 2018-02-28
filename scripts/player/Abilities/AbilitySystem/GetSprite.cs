using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	public class GetSprite:IGetSprite
	{
		Sprite abilityIcon;

		public GetSprite()
		{}
		public Sprite FindSprite(Sprite[] icons, string iconName)
		{

			foreach (Sprite icon in icons)
			{
				if (icon.name == iconName)
				{
					abilityIcon = icon;
					break;
				}
			}

			return abilityIcon;
		}
	}


