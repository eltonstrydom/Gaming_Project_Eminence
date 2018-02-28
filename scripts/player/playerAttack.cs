using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class playerAttack : MonoBehaviour {

	public float timeBetweenAttacks,timer;
	float distanceFromTarget;
	public bool isTouchingEnemy = false;
	public double damage;
	public EventSystem eventSystem;
	double playerAttackCost,playerAttackCost2;
	Animator anim;
	GameObject touchingEnemy;
	public GameObject orbPrefab;
	playerHealth pHealth;
	public Transform orbSpawn;
	AudioManager audioManager;
	GetPopupText popupText;


	public AudioClip attackScream,swordSlash;

	void Awake()
	{
		playerAttackCost = 0.5;
		playerAttackCost2 = 3;
		audioManager = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager> ();
		timeBetweenAttacks = 0.6f;

		pHealth = GetComponent<playerHealth> ();
		anim = GetComponent<Animator> ();
		popupText = GetComponent<GetPopupText> ();                
	}
	void Update()
	{
		//timer for attack cooldowns
		timer += Time.deltaTime;

		if (Input.GetButtonDown ("Fire1") && timer >= timeBetweenAttacks && pHealth.getHealth () > 0 && pHealth.getWillPower () >= playerAttackCost) {
			if (eventSystem.IsPointerOverGameObject ()) {
			}
			else {
				Attack ();
				StartCoroutine (WaitBeforeAttack ());
				touchingEnemy = null;
				isTouchingEnemy = false;
			}


		} else if (Input.GetButtonDown ("Fire2") && timer >= timeBetweenAttacks && pHealth.getHealth () > 0 && pHealth.getWillPower () >= playerAttackCost) 
		{
			if (eventSystem.IsPointerOverGameObject ()){

			}
			else
			{
				StartCoroutine (WaitBeforeAttack ());
				Attack2 ();}


		}

	}
	//melee attack with conditions
	public void Attack ()    
	{
		timer = 0f;
		pHealth.ReduceWillPower (playerAttackCost);
		audioManager.PlaySound (swordSlash);
		if (isTouchingEnemy&&touchingEnemy!=null) 
		{
			distanceFromTarget = Vector3.Distance (transform.position,touchingEnemy.transform.position);
			if (distanceFromTarget < 5f) {
				double tempDamage = pHealth.getDamage();
				popupText.GetCombatText (tempDamage);
				touchingEnemy.gameObject.GetComponent<Statistics> ().setHealth(tempDamage);
			}

		}

		anim.SetBool ("Attack",true);
		anim.SetBool ("Run",false);

	}
	//range attack with conditions
	void Attack2()
	{
		timer = 0f;
		double temp = pHealth.getWillPower () - playerAttackCost2; //checks if player has will power
		if (temp > 0) {
			pHealth.ReduceWillPower (playerAttackCost2);
			anim.SetBool ("Attack",true);
			StartCoroutine (RangeAttackDelay ());
		}

	}

	IEnumerator RangeAttackDelay() //delay for range orb to look realistic
	{
		yield return new WaitForSeconds (0.3f);
		//var orb = Instantiate (orbPrefab, orbSpawn.position, orbSpawn.rotation);
		var orb = ObjectPool.SharedInstance.GetPooledObject("WarriorRangeAttack");
		orb.transform.position = orbSpawn.position;
		orb.transform.rotation = orbSpawn.rotation;
		orb.SetActive (true);
		orb.GetComponent<Rigidbody> ().velocity = transform.forward * 30;
		StartCoroutine (DisableOrb(orb));

	}


	IEnumerator WaitBeforeAttack()//just waiting before the next attack to make it look real
	{

		yield  return new WaitForSeconds (0.5f);
		anim.SetBool ("Attack",false);
	}
	public void OnTriggerStay(Collider other)

	{
		if (other.tag == "meleeEnemy"&&other.tag!="IgnorePlayerWeapons") {
			isTouchingEnemy = true;
			touchingEnemy = other.gameObject;
		}

	}
	IEnumerator DisableOrb(GameObject orb)

	{
		yield return new WaitForSeconds (2f);
		orb.SetActive (false);
	}

	public void OnTriggerExit()
	{
		isTouchingEnemy = false;
	}

}
