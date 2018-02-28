using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneGrinder : AbilityMain {

	private const string name = "Bone Grinder";
	private const string description = "The warrior unleashes an incredible amount of force dealing a great amount of damage to surrounding enemies.";
	private const string iconId = "id03";
	private const float cooldown = 3;
	private const double damage = 150;
	private GameObject prefabToSpawn;
	private Sprite spriteIcon;
	private const double willPowerCost = 5;

	public  BoneGrinder():base(name,description,cooldown,iconId,damage,Resources.Load<GameObject> ("prefabs/AbilityPrefabs/BoneGrinder"),willPowerCost)
	{

	}


	public override void Activate(GameObject player)
	{
		var boneGrinder = GameObject.Instantiate (AbilityPrefab,player.transform.position,player.transform.rotation);
		double tempDamage = player.GetComponent<playerHealth> ().getDamage ();
		boneGrinder.GetComponent<BoneGrinderDamage> ().SetDamage (tempDamage);
		Debug.Log ("Grinder spawned"+tempDamage/2);
	}

}
