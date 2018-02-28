using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace interfaceInventory
{
    public class InventoryManager : MonoBehaviour
    {
        List<IUsable> usableItemsList = new List<IUsable>();            //Using the Interface

        public Inventory inv;               //Getting the Inventory Script

		public ChangeKeybinds keys;

        string potionID;

        void Start()
        {
            usableItemsList.Add(new HealthPotion());        //Adding items to interface list
			usableItemsList.Add(new SpeedPotion());
			usableItemsList.Add(new DamagePotion());
			usableItemsList.Add(new CriticalChancePotion());
			usableItemsList.Add(new WillPowerPotion());
        }


        void Update()
        {
			if (Input.GetKeyDown(keys.gameKeys["PotionOne"]))                   //Waiting to see which button the user presses for the inventory
            {
				ActivatePotionSlotOne ();
            }   
			if (Input.GetKeyDown(keys.gameKeys["PotionTwo"]))
            {
				ActivatePotionSlotTwo (); 
            }
			if (Input.GetKeyDown(keys.gameKeys["PotionThree"]))
            {
				ActivatePotionSlotThree ();
            }
			if (Input.GetKeyDown(keys.gameKeys["PotionFour"]))
            {
				ActivatePotionSlotFour ();
            }
			if (Input.GetKeyDown(keys.gameKeys["PotionFive"]))
            {
				ActivatePotionSlotFive ();
            }
			if (Input.GetKeyDown(keys.gameKeys["PotionSix"]))
            {
				ActivatePotionSlotSix ();
            }

        }

		public void ActivatePotionSlotOne ()
		{
			potionID = inv.items[0,0];                    //gets the items id that is occupying that specific slot
			usableItemsList[int.Parse(inv.items[0,1])].UsePotion(potionID); //Goes to the Interface IUsable.
		}

		public void ActivatePotionSlotTwo()
		{
			potionID = inv.items[1,0];
			usableItemsList[int.Parse(inv.items[1,1])].UsePotion(potionID);
		}

		public void ActivatePotionSlotThree()
		{
			potionID = inv.items[2,0];
			usableItemsList[int.Parse(inv.items[2,1])].UsePotion(potionID);
		}

		public void ActivatePotionSlotFour ()
		{
			potionID = inv.items[3,0];
			usableItemsList[int.Parse(inv.items[3,1])].UsePotion(potionID);
		}

		public void ActivatePotionSlotFive()
		{
			potionID = inv.items[4,0];
			usableItemsList[int.Parse(inv.items[4,1])].UsePotion(potionID);
		}

		public void ActivatePotionSlotSix()
		{
			potionID = inv.items[5,0];
			usableItemsList[int.Parse(inv.items[5,1])].UsePotion(potionID);
		}
    }
}
