using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackPrefab : MonoBehaviour {
	double damage;
	public ParticleSystem onTriggerEffect;
	void Awake()
	{
		damage = 5;
		StartCoroutine (DisableObject());
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Orb hit player");

		if (other.tag == "Player") {

			onTriggerEffect.Play ();
			other.GetComponent<playerHealth> ().reduceHealth (damage);
			gameObject.SetActive (false);
		}

	}

	IEnumerator DisableObject()
	{
		yield return new WaitForSeconds (2f);
		gameObject.SetActive (false);
	}
}
