using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public Camera cam;
	public float rotationSpeed = 8;  
	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float rotateVel = 100;
	public Text speedText;
	float timeLeft = 5;
	bool active = false;
	float tempSpeed;

	Animator anim;
	Quaternion targetRotation;
	Rigidbody rBody;

	float forwardInput,turnInput;
	playerHealth pH;
	public GameObject speedActiveParticle;

	bool didDeathAniPlay;
	public int mouseXSpeedMod = 5;
	public int mouseYSpeedMod = 5;

	float x,y;


	public Quaternion TargetRotation

	{
		get {return targetRotation;}
	}

	void Start()

	{
		didDeathAniPlay = false;
		anim = GetComponent<Animator> ();
		pH = GetComponent<playerHealth> ();

		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ())
			rBody = GetComponent<Rigidbody> ();

		forwardInput = turnInput = 0;

	}

	void GetInput()

	{
		
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal"); 
	 if (Input.GetButton ("Vertical") != false) {
			
			anim.SetBool ("Run", true);
			anim.SetBool ("Idle", false);
			anim.SetBool ("Jump",false);
			//anim.SetBool ("Attack",false);
		}

		else {
			
			anim.SetBool ("Jump",false);
			anim.SetBool ("Run", false);
			anim.SetBool ("Idle", true);
		}

	}

	void Update()
	{
		if (pH.getHealth () > 0) 
		{
			GetInput ();
		
			Turn ();
			
		}

		if (active) 				               //Bool to see if the potion has been activated
		{
			timeLeft -= Time.deltaTime;				//Starts the timer
			if (timeLeft <= 0) 						//If timer reaches 0
			{
				active = false;						//Deactivates the potion effect
				timeLeft = 5;
				this.forwardVel = tempSpeed;		//Speed goes back to normal
				speedActiveParticle.SetActive(false);
			}
		}
		speedText.text = forwardVel.ToString ();

	}

	void FixedUpdate()

	{
		if (pH.getHealth () > 0) 
		{
			Run ();
		} 

		else if(pH.getHealth()<=0&&didDeathAniPlay==false)
		{
			didDeathAniPlay = true;
			anim.SetTrigger ("IsDead");
		}
	
		
	}

	void Run()

	{
		if (Mathf.Abs (forwardInput) > inputDelay) 
		{
			bool isAttacking = anim.GetBool ("Attack");

			//rBody.AddForce (transform.forward*forwardVel);
			rBody.velocity = transform.forward * forwardInput * forwardVel;
		

		} 
	

	}
	void Turn()

	{
		


	
		if (Mathf.Abs (turnInput) > inputDelay)
		{
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;

	}


	public void IncreaseSpeed (int amount)
	{
		if(!active)
		{
			gameObject.layer = 9;
			StartCoroutine (RemoveSpeedBuff());
			tempSpeed = this.forwardVel;			//Saves the normal speed
			this.forwardVel += amount;					//Increases speed by 5
			active = true;							//Tell us the potion is active now and the timer starts
			speedActiveParticle.SetActive(true);
		}
	}

	IEnumerator RemoveSpeedBuff()
	{
		yield return new WaitForSeconds (3f);
		gameObject.layer = 0;
	}










	}





























