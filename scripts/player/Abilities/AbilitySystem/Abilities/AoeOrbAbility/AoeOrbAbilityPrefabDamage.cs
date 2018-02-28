using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeOrbAbilityPrefabDamage : MonoBehaviour {
	public Statistics enemyStat;
	public GameObject enemy;
	public ParticleSystem triggerParticles;
	private AudioClip collisionSound;
	GameObject audioSource;
	double damagePerHit;
	float timer;
	float timeBetweenDamage;
	void Awake()
	{
		collisionSound = Resources.Load<AudioClip> ("Sounds/orbHitting");
		timeBetweenDamage = 0.5f;
		audioSource = GameObject.Find ("AudioManager");
	}
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeBetweenDamage)
			DealDamage ();
	}
	void DealDamage()
	{
		timer = 0f;
		if (enemy!=null) 
		{
			enemy.gameObject.GetComponent<Statistics> ().setHealth(damagePerHit/2);
			enemy = null;
			Debug.Log ("Enemy Recieved damage");
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="meleeEnemy"&&other.gameObject.GetComponent<Statistics> ().getHealth()>0){
			triggerParticles.Play ();
			audioSource.GetComponent<AudioManager> ().PlaySound (collisionSound);
		//play sound and particle effect	
		enemy = other.gameObject;
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
