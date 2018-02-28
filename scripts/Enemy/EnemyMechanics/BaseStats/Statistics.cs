using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour {

	public double health;
	public double healthModifier;
    double maxHealth;
	public double damage;
	public double pointReward;
	public spawning spawner;
	Death dead;
	public ParticleSystem bloodSpatter;
	GameObject audioManager;
	private AudioClip bloodSplatterSound;

	void OnEnable()
	{
		spawner = GameObject.FindGameObjectWithTag ("spawner").GetComponent<spawning>();
		maxHealth = (spawner.CurrentWave () * healthModifier) / 2;
		health = maxHealth;
	}
	void Awake()

	{
		
		bloodSplatterSound = Resources.Load<AudioClip> ("Sounds/bloodSplatter");
		audioManager = GameObject.Find ("AudioManager");
		try
		{
			dead = GetComponent<Death> ();
		}
		catch
		{}

	}

	public double getHealth()                         //giving enemy health information to another script
	{
		return this.health;
	}
	public double GetMaxHealth()
	{
		return this.maxHealth;
	}
	public double getPointReward()                   //giving enemy point reward information to another script
	{
		return this.pointReward;
	}

	public double GetDamage()                        //giving the enemy damage amount to another script
	{
		return this.damage;
	}


	public void setHealth(double damageRecieved)     //this is how the enemy takes damage
	{
		

		this.health = health - damageRecieved;
		audioManager.GetComponent<AudioManager> ().PlaySound (bloodSplatterSound);
		bloodSpatter.Play ();
		if (this.health <= 0) {
			
			dead.Die ();
		}
	}
	public void Heal(double amountToHeal)     //this is how the enemy takes damage
	{

		if(health<maxHealth&&health>0)
		this.health = health + amountToHeal;

	}
}
