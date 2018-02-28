using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealingPool : MonoBehaviour {

	public double amountToHeal;
	public double rate;
	double actualHealAmount;
	double actualDamageToPlayer;
	public Text HealingText;

	void Awake()
	{
		
	}
	void OnTriggerStay(Collider other)
	{
		//Debug.Log (other.name);

		if (other.tag == "meleeEnemy") 
		{
			actualHealAmount = amountToHeal/(rate/0.02);
			other.GetComponent<Statistics> ().Heal (actualHealAmount);
			//Debug.Log ("Enemy  "+other.name+"    healed for 15");
		}

		if (other.tag == "Player") 
		{
			HealingText.text = "PLAYER IS LOSING HEALTH!"; //player text
			actualDamageToPlayer = (amountToHeal/2)/(rate/0.02);
			other.GetComponent<playerHealth>().TakeDirectDamage (actualDamageToPlayer);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		HealingText.text = "ENEMIES ARE HEALING UP!";
		StartCoroutine (RemoveText());
	}

	public void OnTriggerExit(Collider other)
	{
		HealingText.text = ""; //enemy text

		if (other.tag != "Player") 
		{
			HealingText.text = "";  //player text
		}
	}
	IEnumerator RemoveText()
	{
		yield return new WaitForSeconds (3f);
		HealingText.text = "";
	}





}
