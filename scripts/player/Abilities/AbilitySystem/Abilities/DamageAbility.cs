using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbility : AbilityMain 
{
	
	private const string name = "Overpower";
	private const string description = "The warrior uses his will power to unleash a great amount of damage";
	private const string iconId = "id01";

	private const float cooldown = 20;

	private const double damage = 150;
	private const double willPowerCost = 15;
	private const float duration = 8;


	private const bool isBuff = true;
	private GameObject prefabToSpawn;
	private Sprite spriteIcon;

	public  DamageAbility():base(name,description,cooldown,iconId,damage,duration,willPowerCost,isBuff)
	{
		
	}


	public override void Activate(GameObject player)
	{
		
		playerHealth ph = player.GetComponent<playerHealth> ();
        ph.IncreaseCurrentDamage (damage);


	}

	public override void Deactivate(GameObject player)
	{
		playerHealth ph = player.GetComponent<playerHealth> ();
		ph.DecreaseCurrentDamage (damage);
		Debug.Log ("Players damage has decreased by " + damage);
	}









}
