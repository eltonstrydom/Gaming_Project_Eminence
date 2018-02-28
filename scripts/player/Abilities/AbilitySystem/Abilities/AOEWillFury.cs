using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEWillFury : AbilityMain {

	private const string name = "Warriors Freedom";
	private const string description = "The player uses his will to force some enemies away in order to escape them";
	private const string iconId = "id10";
	private const int cooldown = 8;
	private const double damage = 150;
	private const double willCost = 10;
	private Sprite spriteIcon;

	public  AOEWillFury():base(name,description,cooldown,iconId,Resources.Load<GameObject> ("prefabs/AbilityPrefabs/EnemyPushBackPrefab"),willCost)
	{

	}


	public override void Activate(GameObject player)
	{
		var orb = GameObject.Instantiate (AbilityPrefab,player.transform.position,player.transform.rotation);
		Debug.Log ("Pushing Enemies");
	}

}
