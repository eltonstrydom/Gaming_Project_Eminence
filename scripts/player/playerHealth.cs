using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour 

{
    public GameObject EndGameCanvas;   
	UpdatePlayerScore ups;
	GameObject uiManager;
	AudioManager audioManager;
	AudioClip grunt;
	bool readyForGrunt;
	                                               //player attributes
	//*************************************************************
	public Image healthBar;
	public Text playerHealthText;
	private double playerhealth = 350;
	public double currentPlayerHealth;
	//*************************************************************
	public Text playerDamageText;
	int damageTextTemp;
	private double playerDamage=50;
	public double currentPlayerDamage;
	//*************************************************************
	public Text playerCritText;
	private double playerCritChance =25;//25% chance to crit
	//*************************************************************
	public Image armorBar;                          //player armor
	public Text playerArmorText;
	private double playerArmor = 50;              
	public double currentPlayerArmor;             
	private double armorRegenAmount = 0.15;
	private float armorRegenRate = 0.01f;
	private float armorTime;
	//*************************************************************     
	public Image willBar;                         //player willPower
	public Text playerWillText;
	private double playerWillPower = 50;              
	public double currentPlayerWillPower;             
	private double willRegenAmount = 0.15;
	private float willRegenRate = 0.09f;
	private float willTime;
	//*************************************************************
	float particleTime = 1f;
	bool particleActive = false;
	bool healthParticleActive = false;
	bool willPowerActive = false;
	bool criticalActive = false;
	public GameObject HealthActive;
	public GameObject CriticalActive;
	public GameObject WillPowerActive;
	//*************************************************************

	public double playerScore = 0;

    bool done;
	GetPopupText popupText;

    void Awake()

	{
		grunt = Resources.Load<AudioClip> ("Sounds/Grunt");
		readyForGrunt = true;
		audioManager = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager> ();
		playerScore = 0;


		this.currentPlayerHealth = this.playerhealth;             //loads playerHealth
		this.currentPlayerArmor = this.playerArmor;               //loads playerArmor
	    this.currentPlayerWillPower = this.playerWillPower;       //loads player will power
		this.currentPlayerDamage = this.playerDamage;             //loads player damage


		playerDamageText.text = this.currentPlayerDamage.ToString ();
		playerCritText.text = this.playerCritChance.ToString () + "%";
		playerWillText.text = this.currentPlayerWillPower.ToString ();
		playerHealthText.text = this.currentPlayerHealth.ToString ();
		playerArmorText.text = this.currentPlayerArmor.ToString ();

		HealthActive.SetActive (false);
		CriticalActive.SetActive (false);
		WillPowerActive.SetActive (false);

		uiManager = GameObject.Find ("scorePanel");
		ups = uiManager.GetComponent<UpdatePlayerScore> ();
		popupText = GetComponent<GetPopupText> ();
	
    }


   
    void Update()
    {
		
	
		armorTime += Time.deltaTime;
		willTime += Time.deltaTime;

	
		if (willTime >= willRegenRate)
		    WillRegen ();
		

		if (armorTime >= armorRegenRate)
			ArmorRegen ();


		playerDamageText.text = currentPlayerDamage.ToString ();

		//************************************************************************
		if (particleActive) 
		{
			particleTime -= Time.deltaTime;

			if (particleTime >= 0) 
			{
				if (healthParticleActive) 
				{
					HealthActive.SetActive (true);
				}
				if (willPowerActive) 
				{
					WillPowerActive.SetActive (true);
				} 
				if (criticalActive) 
				{
					CriticalActive.SetActive (true);
				}
			} 
			else 
			{
				HealthActive.SetActive (false);
				WillPowerActive.SetActive (false);
				CriticalActive.SetActive (false);
				healthParticleActive = false;
				willPowerActive = false;
				criticalActive = false;
				particleActive = false;
				particleTime = 1;
			}
		}
		//************************************************************************

	}

	//armor regen with conversion for fill amounts
	public void ArmorRegen()
	{
		armorTime = 0;
		if (currentPlayerHealth > 0) {
			if (currentPlayerArmor < playerArmor) {
				currentPlayerArmor += armorRegenAmount;
			} else
				currentPlayerArmor = playerArmor;

			float tempArmor = (float)this.currentPlayerArmor / (float)this.playerArmor;
			int armorTempText = Mathf.RoundToInt((float)currentPlayerArmor);

			if (armorTempText >= 0)                           //Updating the armor text
				playerArmorText.text = armorTempText.ToString ();
			else
				playerArmorText.text = "0";


			armorBar.fillAmount = (float)tempArmor;
		}
	}
	//will regen with conversion for fill amounts
	public void WillRegen()
	{
		willTime = 0;
		if (this.currentPlayerHealth > 0) {
			if (this.currentPlayerWillPower < this.playerWillPower) {
				this.currentPlayerWillPower += this.willRegenAmount;
			} else
				this.currentPlayerWillPower = this.playerWillPower;
			float calcWill = (float)this.currentPlayerWillPower / (float)this.playerWillPower;
			willBar.fillAmount = calcWill;

			int willTempText = Mathf.RoundToInt((float)currentPlayerWillPower);
			if (willTempText >= 0)                                              //Updating the will pwoer text
				playerWillText.text = willTempText.ToString ();
			else
				playerWillText.text = "0";
		}

	}
	//set will power to max
	public void RefillWillPower()
	{
		this.currentPlayerWillPower = this.playerWillPower;
		particleActive = true;
		willPowerActive = true;
	}

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(3);
		EndGameCanvas.SetActive(true);
       

    }



	public double getHealth()                                                 //giving player health information to another script
	{
		return this.currentPlayerHealth;
	}

	public void IncreaseHealth(double amount)
	{
		double tempHealth =  this.currentPlayerHealth += amount;

		if (tempHealth > playerhealth)
			this.currentPlayerHealth = playerhealth;
		else
			this.currentPlayerHealth = tempHealth;

		particleActive = true;
		healthParticleActive = true;

		UpdateHealth ();
	}


	public double getWillPower()                                                //getting the players will power
	{
		return this.currentPlayerWillPower;
	}

    public double getArmor()
	{
		return this.currentPlayerArmor;
	}

	public void ReduceArmor(double damageRecieved)
	{
		
			this.currentPlayerArmor -= damageRecieved;
		if (this.currentPlayerArmor > 1)
			popupText.LoseArmourText (damageRecieved);

	}
	public  void ReduceWillPower(double amount)                             //reducing players will power
	{ 
		
		double temp = this.currentPlayerWillPower - amount;
		if (temp < 0)
			this.currentPlayerWillPower = 0;
		else
			this.currentPlayerWillPower -= amount;

		popupText.LoseWillPowerText (amount);

	}



	public void reduceHealth (double damageRecieved)                         //player takes damage
	{

		if (damageRecieved > getArmor ()) 
		{
			double temp = damageRecieved - this.currentPlayerArmor;
			popupText.LoseHealthText (damageRecieved);
			currentPlayerHealth = currentPlayerHealth - temp;	
			if (currentPlayerHealth < playerhealth / 2 && readyForGrunt) {
				readyForGrunt = false;
				StartCoroutine (ReadyGrunt());
				audioManager.PlaySound (grunt);
			}
				
		    ReduceArmor (damageRecieved - temp);
		} 
		else
			ReduceArmor (damageRecieved);


		if (currentPlayerHealth <= 0)

		{

			StartCoroutine(WaitForDeath());
		}


		UpdateHealth ();

	}

	public void TakeDirectDamage(double damageAmount)
	{
		currentPlayerHealth = currentPlayerHealth - damageAmount;
		if (currentPlayerHealth <= 0)

		{

			StartCoroutine(WaitForDeath());
		}

		UpdateHealth ();
	}




	void UpdateHealth()

	{
		
		float calcHealth = (float)currentPlayerHealth / (float)playerhealth;
		int healthRound = (int)this.currentPlayerHealth;
		healthBar.fillAmount = (float)calcHealth;
		if(healthRound<0)
			playerHealthText.text = "0";
		else
			
		playerHealthText.text =  healthRound.ToString ();
	

	}

	public double getDamage()                                                // returns player damage
	{
		return CalculateCrit ();
	//	return this.currentPlayerDamage;
	
	}

	private double CalculateCrit()
	{
		double temp = 0;
		for(int i = 0;i<5;i++)
		{
			 temp = Random.Range (0, 101);
		}
		if (temp <= playerCritChance)
			temp = currentPlayerDamage * 2;
		else
			temp = currentPlayerDamage;
		return temp;
	}

	public void IncreaseCritChance(int amount)
	{
		playerCritChance += amount;
		playerCritText.text = this.playerCritChance.ToString () + "%";
		particleActive = true;
		criticalActive = true;
	}

	public void IncreaseScore(double amount)
	{
		playerScore += amount;
		try
		{
			ups.UpdateScoreText (playerScore.ToString());
		}
		catch
		{
			
		}
		popupText.GetScoreText(amount);
        PlayerPrefs.SetString("PlayerScore", this.playerScore.ToString());
    }

	public void IncreaseCurrentDamage(double amount)
	{
		this.currentPlayerDamage += amount;
	}
	public void DecreaseCurrentDamage(double amount)
	{
		this.currentPlayerDamage -= amount;
	}


    public double getScore()                                                 //giving player health information to another script
    {
        return this.playerScore;
    }

	IEnumerator ReadyGrunt()
	{
		yield return  new WaitForSeconds (0.5f);
		readyForGrunt = true;
	}


}
