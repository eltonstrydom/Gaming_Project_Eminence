using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeOrbEnter : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//checks if enemy
		if (other.tag == "meleeEnemy")
		{
			other.GetComponent<Statistics> ().setHealth (50);
			gameObject.SetActive (false);
		}

	}
}
