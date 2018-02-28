using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BasicEnemyAI : MonoBehaviour {
	IAttack attacks;
	IFollow followAI;

	public State state;
	public bool isMelee;
	public Transform healingPool;
	GameObject player;
	GameObject audioManager;
	playerHealth ph;
	public AudioClip attackSound;
	public bool isInRange;
	Transform playerObject;
	AnimatorController ac;
	Statistics stat;
	NavMeshAgent nav;

	public float timeBetweenAttacks,timer,timeBetweenRangeAttacks;
	float enemyNavSpeed;
	float distanceFromPool;
	float distanceFromPlayer;

	//state types
	public enum State{
		Chasing,Attacking,Retreating,Idle,Dead,Rage,
	}
	void Start () 
	{
		
		audioManager = GameObject.Find ("AudioManager");
		healingPool = GameObject.Find ("HealingPool").transform;
		attacks = new Attacks ();
		followAI = new FollowAI ();
		isInRange = false;
		timeBetweenAttacks = 1f; 
		timeBetweenRangeAttacks = 1.5f;
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindWithTag ("Player");
		playerObject = player.transform;
		ph = player.GetComponent<playerHealth> ();
		ac = GetComponent<AnimatorController> ();
		stat = GetComponent<Statistics> ();
		for(int i =0;i<5;i++)
		{
			enemyNavSpeed = Random.Range (3f,10f);
		}
		nav.speed = enemyNavSpeed;
	}
	

	void Update () 
	{
		 timer += Time.deltaTime;
		//checks enemy state
		CheckState ();
		//taking actions based on current state
		switch (state)
		{
		case State.Retreating:
			nav.enabled = true;
			followAI.RunAwayOnLowHealth(nav,healingPool,ac);

			break;
		case State.Attacking:

			if (isMelee && timer >= timeBetweenAttacks) 
			{
				timer = 0f;
				nav.enabled = false;                                                                       //turns of nav agent so the enemy cant move and calls the attack method
				double damage = stat.GetDamage();
				attacks.Attack (ph,audioManager,attackSound,ac,damage);   
			}
			else if(!isMelee &&timer>=timeBetweenRangeAttacks)
			{
				timer = 0f;
				nav.enabled = false;
				attacks.RangeAttack (ac,gameObject);
			}




		break;
		case State.Chasing:
			nav.enabled = true;
			followAI.BasicFollow (nav,playerObject,ac);
			break;
		case State.Idle:
			ac.IdleTrue ();
			nav.enabled = false;
            break;
		case State.Dead:
			break;
		case State.Rage:

			break;
		
		}

		
	}


	public State CheckState()
	{
		distanceFromPool = Vector3.Distance (transform.position, healingPool.transform.position);
		distanceFromPlayer = Vector3.Distance (transform.position, player.transform.position);


		if (ph.getHealth () > 0) {//first checks if the player is alive
			if (stat.getHealth() > 0) { //checks enemy health
				if (stat.getHealth () <= (stat.GetMaxHealth () / 4)) {//if the enemy health is at 25% or less
					if (distanceFromPool > 12f) //if the enemy is away from the healing pool
						state = State.Retreating; //retreats to pool
					else if (distanceFromPool < 12f) { //checks if the enemy is in the pool at its current state
						if (isInRange)//if the player is in range and the enemy is safely in the pool, attacks player
							state = State.Attacking;
						else
							state = State.Idle;
					}
				} else if (!isInRange)//else if the enemy is high health and player is not in range starts chasing
					state = State.Chasing;
				else if (isInRange)//if the player is in range and the enemy health is above 25% attacks player
					state = State.Attacking;
				else
					state = State.Idle;//if none is true goes to idle state
					} else
				state = State.Dead;//if nothing else the enemy is dead
		} else
			state = State.Idle;//if the player is dead enemies idles

		return state;
	}

	public void IsInRange(bool rangeChecker)
	{
		isInRange = rangeChecker;
	}

  
}
