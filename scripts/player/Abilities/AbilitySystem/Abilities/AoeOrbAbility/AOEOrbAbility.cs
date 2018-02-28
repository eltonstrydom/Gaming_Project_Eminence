using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEOrbAbility : AbilityMain {

	private const string name = "Aura of Will";
	private const string description = "Orbs surround the player dealing damage to enemies touching it";
	private const string iconId = "id02";
	private const int cooldown = 3;
	private const double damage = 150;
	private const double willPowerCost = 15;



	public  AOEOrbAbility():base(name,description,cooldown,iconId,damage,Resources.Load<GameObject> ("prefabs/AbilityPrefabs/OrbRotateHandler"),willPowerCost)
	{

	}

	public override void Activate(GameObject player)
	{
		var orb = GameObject.Instantiate (AbilityPrefab,player.transform.position,player.transform.rotation);
		double tempDamage = player.GetComponent<playerHealth> ().getDamage ();
		orb.GetComponentInChildren<AoeOrbAbilityPrefabDamage> ().SetDamage (tempDamage/2);
		Debug.Log ("Orb spawned"+tempDamage/2);
	}





}
