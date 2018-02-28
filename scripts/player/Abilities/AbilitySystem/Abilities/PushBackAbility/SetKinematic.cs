using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKinematic : MonoBehaviour {
	
	GameObject player;

	float timer;


	void Awake()
	{
		player = GameObject.FindWithTag ("Player");
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 8f);
		int i = 0;
		while (i < hitColliders.Length) {
			if (hitColliders [i].gameObject.tag == "meleeEnemy") {
				hitColliders [i].gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				StartCoroutine (SetKinematicFalse(hitColliders[i].gameObject.GetComponent<Rigidbody>()));
				Debug.Log ("Enemy"+i+"is now kinematic");
			}
			i++;
		}
	}


	void Update () {
		
		transform.position = player.transform.position;

		}


	IEnumerator SetKinematicFalse(Rigidbody rbody)
	{
		
		yield return new WaitForSeconds (3f);
		rbody.isKinematic = true;
		Debug.Log ("enemy kinematic is false");

	}

}
