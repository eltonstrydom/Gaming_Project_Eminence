using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneGrinderDamage : MonoBehaviour {

	public Statistics enemyStat;
	public GameObject enemy;
	double damagePerHit;

	void DealDamage()
	{
		if (enemy!=null) 
		{
			enemy.gameObject.GetComponent<Statistics> ().setHealth(damagePerHit);
			enemy = null;
			Debug.Log ("Enemy Recieved damage");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="meleeEnemy"&&other.gameObject.GetComponent<Statistics> ().getHealth()>0){
			//audioSource.GetComponent<AudioManager> ().PlaySound (collisionSound);
			//play sound and particle effect	
			enemy = other.gameObject;
			DealDamage ();
			//gets target info
			//if enemy applies damage
			//play sound and effect
		}

	}
		
	public void SetDamage(double damage)
	{
		this.damagePerHit = damage;
	}
}
