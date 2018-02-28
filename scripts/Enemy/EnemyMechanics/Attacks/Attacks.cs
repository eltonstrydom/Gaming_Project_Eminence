using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : IAttack
{
	int temp;
	Vector3 tempYOffset;
	public  void Attack(playerHealth ph,GameObject audiosource,AudioClip attackSound,AnimatorController ac,double damage)
	{
		for (int i = 0; i < 5; i++) {
			temp = Random.Range (0,20);  
		}

		if (ph.getHealth () > 0)
		{                                                                                   //Before the attack goes through checks if the player is actually still alive
			//if (!audiosource.isPlaying)                                                     //checks if the attack sound is playing and plays it if needed
			//	audiosource.Play ();
			if(temp<=1)
				audiosource.GetComponent<AudioManager>().PlaySound(attackSound);
			ac.AttackTrue ();                                                               //plays attack animation
			ph.reduceHealth (damage);                                                       //reduced players health
		}
	}

	public void RangeAttack(AnimatorController ac,GameObject startPosition)
	{
		ac.RageTrue ();

		tempYOffset = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y + 1.5f,startPosition.transform.position.z);

		//var orb = GameObject.Instantiate (prefab, tempYOffset, startPosition.transform.rotation);
		var orb = ObjectPool.SharedInstance.GetPooledObject("RangeAttackOrb");
		orb.transform.position = tempYOffset;
		orb.transform.rotation = startPosition.transform.rotation;
		orb.SetActive (true);
		orb.GetComponent<Rigidbody> ().velocity = orb.transform.forward * 30;
	}
}
