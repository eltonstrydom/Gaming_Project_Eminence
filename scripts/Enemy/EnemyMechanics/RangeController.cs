using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour {
	public BasicEnemyAI basicEnemyAI;
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {

			basicEnemyAI.IsInRange (true);
			
		}
	}

	void OnTriggerExit()

	{
		
		basicEnemyAI.IsInRange (false);
	}
}
