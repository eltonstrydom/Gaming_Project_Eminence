/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRangeAttack : MonoBehaviour {

	playerAttack pa;
	void Awake ()

	{
		pa = GameObject.FindWithTag ("Player").GetComponentInChildren<playerAttack>(); 

	}
	public void OnTriggerEnter(Collider other)

	{

		if (other.tag == "meleeEnemy")
		{

			other.gameObject.GetComponentInChildren<MeleeEnemy> ().setHealth(90);
			Debug.Log ("the melee enemy took damage");

			if(other.gameObject.GetComponentInChildren<MeleeEnemy> ().getHealth()<=0)
				pa.playerPointsEarned+= other.gameObject.GetComponentInChildren<MeleeEnemy> ().getPointReward();


		}

		if (other.tag == "rangeEnemy")
		{

			other.gameObject.GetComponentInChildren<RangeEnemy> ().setHealth(50);
			Debug.Log ("the range enemy took damage");

			if(other.gameObject.GetComponentInChildren<RangeEnemy> ().getHealth()<=0)
				pa.playerPointsEarned+= other.gameObject.GetComponentInChildren<RangeEnemy> ().getPointReward();


		}


	}
}
*/
