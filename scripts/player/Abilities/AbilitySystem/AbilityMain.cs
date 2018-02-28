using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AbilityMain{
	private string name;
	private string description;
	private string iconId;

	private float cooldown;
	private float duration;
	private double damage;
	private double willPowerCost;

	private bool isBuff;

	private GameObject abilityPrefab;
	private AudioClip activateSoundEffect;

	public AbilityMain(string Name,string Description,float Cooldown, string Icon,double Damage,float duration,double willCost,bool isbuff = false )
	{
		this.name = Name;
		this.description=Description;
		this.iconId = Icon;
		this.cooldown = Cooldown;
		this.damage = Damage;
		this.duration = duration;
		this.isBuff = isbuff;
		this.willPowerCost = willCost;
		this.activateSoundEffect = audioClip;



	}
	public AbilityMain(string Name,string Description,float Cooldown, string Icon,double Damage,bool isbuff = false)
	{
		this.name = Name;
		this.description=Description;
		this.iconId = Icon;
		this.cooldown = Cooldown;
		this.damage = Damage;
		this.isBuff = isbuff;
	}
	public AbilityMain(string Name,string Description,float Cooldown, string Icon,double Damage,GameObject abilityPrefab,double willCost)
	{
		this.name = Name;
		this.description=Description;
		this.iconId = Icon;
		this.cooldown = Cooldown;
		this.damage = Damage;
		this.abilityPrefab = abilityPrefab;
		this.willPowerCost = willCost;
	}
	public AbilityMain(string Name,string Description,float Cooldown, string Icon,GameObject abilityPrefab,double willCost)
	{
		this.name = Name;
		this.description=Description;
		this.iconId = Icon;
		this.cooldown = Cooldown;
		this.abilityPrefab = abilityPrefab;
		this.willPowerCost = willCost;
	}

	//getters and setters
	public float Cooldown
	{
		get{ return cooldown; }
	}
	public GameObject AbilityPrefab
	{
		get{return  abilityPrefab; }
	}
	public AudioClip audioClip
	{
		get{ return activateSoundEffect; }
	}
	public string Name
	{
		get{ return name; }
	}
	public string Description
	{
		get{ return description; }
	}


	public string Icon
	{
		get{return iconId;}

	}

	public bool IsBuff
	{
		get { return isBuff; }
	}
	public float Duration
	{
		get{ return duration; }
	}
	public double WillPowerCost
	{
		get{ return willPowerCost; }
	}



	public virtual void Activate()
	{
		Debug.Log ("There is no ability logic here");
	}
	public virtual void Deactivate()
	{

	}
	public virtual void Activate(GameObject player)
	{
		Debug.Log ("There is no ability logic here");
	}

	//if there is enough time i want to create better class structure for abilities and buffs 
	//because of their difference, however since time is of 
	//the essence and we only have 1 buff at the moment this will have to do
	public virtual void Deactivate(GameObject player)
	{
		Debug.Log ("There is no ability logic here");
	}






}
