using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Death : MonoBehaviour {

	NavMeshAgent nav;
	CapsuleCollider capCol; 
	AnimatorController ac;
	playerHealth ph;
	Vector3 potionPosition; 
	PotionSpawnHandler psh;
	Statistics stat;
	GameObject player;
	bool didAniPlay;
	void Start()
	{
		didAniPlay = false;
		nav = GetComponent<NavMeshAgent> ();
		potionPosition = new Vector3 (0,1f,0);    
		player = GameObject.FindWithTag ("Player");
		ph = player.GetComponent<playerHealth> ();
		ac = GetComponent<AnimatorController> ();
		capCol = GetComponent<CapsuleCollider>();
		psh = GetComponent<PotionSpawnHandler> ();
		stat = GetComponent<Statistics> ();

	}
	public void Die()
	{
		nav.enabled = false;                                                            //Turns of the nav agent so the enemy can't move

		capCol.enabled = false;                                                         //enables the enemy trigger so the player can move through it
		if (!didAniPlay)                                                                //checks if the enemy death animation has player
		{
			ac.DeadTrigger ();                                                          //calls the death animation
			potionPosition = this.gameObject.transform.position + potionPosition ;      //gives an offset for the potion to spawn from the enemy current transform

			psh.PotionSpawner (potionPosition);                                      //Try to spawn a potion from the potionspawner class



			ph.IncreaseScore (stat.getPointReward());                                      //Upon death the enemy passes their score value to the player to be added
		}
		didAniPlay = true;                                                                 //sets ani played to true so that the animation does not play again
		//Destroy the enemy after a short delay
		StartCoroutine(WaitForDeath());

	}
	IEnumerator WaitForDeath()

	{
		yield return new WaitForSeconds(4f);
		nav.enabled = true;                                                            //Turns of the nav agent so the enemy can't move
		didAniPlay = false;
		capCol.enabled = true;
		gameObject.SetActive(false);
	}

}
