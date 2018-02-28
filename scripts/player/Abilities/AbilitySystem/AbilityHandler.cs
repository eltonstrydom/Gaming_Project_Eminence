using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHandler:MonoBehaviour {
	int abilityActivatedIndex=-1;
	int numberAbilities = 4;

	IGetSprite getSprite;

	Sprite[] icons;
	List<AbilityMain> abilities;  //list of all potential abilities

	List<GameObject> slots = new List<GameObject>();
	public GameObject slotPanel;
	public GameObject abilitySlotPrefab;
	public GameObject player;
	public GameObject audioManager;
	public ChangeKeybinds changeKey;
	playerHealth ph;

	float[] abilitySlotCooldowns;

	//the slots list cooldown array and ability list and keybind dictionary are all in parallel
	void Awake () 
	{
		
		ph = player.GetComponent<playerHealth> ();
		abilitySlotCooldowns = new float[numberAbilities];
		audioManager = GameObject.Find ("AudioManager");
		//loading everything the ability handler class needs
		LoadSprites ();
		LoadAbilities ();
		GenerateAbilityButtons ();
	}

	void Update()
	{
		//input will be checked here
		InputHandler ();
		CooldownHandler ();
	}

	void LoadAbilities()
	{
		abilities = new List<AbilityMain>();
		abilities.Add (new DamageAbility());
		abilities.Add (new AOEOrbAbility());
		abilities.Add (new BoneGrinder());
		abilities.Add (new AOEWillFury());

	}

	void LoadSprites()
	{
		getSprite = new GetSprite ();
		icons = Resources.LoadAll<Sprite>("sprites");
	}

	void GenerateAbilityButtons()
	{
		for (int i = 0; i < numberAbilities;i++) 
		{
			slots.Add (Instantiate (abilitySlotPrefab));
			slots [i].transform.SetParent (slotPanel.transform);
			slots [i].gameObject.GetComponent<Image>().sprite = getSprite.FindSprite (icons,abilities[i].Icon); // this is a dummy icon for empty ability  slots
			int temp = i;
			slots[i].GetComponent<Button>().onClick.AddListener(()=>ActivateAbility(temp));
			Tooltips toolTipTemp = slots [i].gameObject.GetComponent<Tooltips> ();
			toolTipTemp.SetDescription(abilities[i].Description);
			toolTipTemp.SetAbilityImage (getSprite.FindSprite (icons,abilities[i].Icon));
			toolTipTemp.SetCooldown (abilities[i].Cooldown);
			toolTipTemp.SetName (abilities [i].Name);
			toolTipTemp.SetWillpower (abilities [i].WillPowerCost);



		}
	}

	void InputHandler()
	{
		if (Input.GetKeyDown(changeKey.gameKeys["AbilityOne"]))
			abilityActivatedIndex = 0;
		if (Input.GetKeyDown(changeKey.gameKeys["AbilityTwo"]))
			abilityActivatedIndex = 1;
		if (Input.GetKeyDown(changeKey.gameKeys["AbilityThree"]))
			abilityActivatedIndex = 2;
		if (Input.GetKeyDown(changeKey.gameKeys["AbilityFour"]))
			abilityActivatedIndex = 3;
		//if(Time.timeScale=1f)
		ActivateAbility (abilityActivatedIndex);
		abilityActivatedIndex = -1;
		
	}
	void CooldownHandler()
	{
		for (int i = 0; i <numberAbilities; i++) {
			if (abilitySlotCooldowns [i] > 0) {
				abilitySlotCooldowns [i] -= 1f * Time.deltaTime;
				slots [i].gameObject.GetComponentInChildren<Text> ().text = ((int)abilitySlotCooldowns [i]).ToString ();
			}
			else
				slots [i].gameObject.GetComponentInChildren<Text> ().text = "";
		}
	}

	IEnumerator RemoveBuff(GameObject player,List<AbilityMain> abilities,int i)
	{
		yield return new WaitForSeconds (abilities[i].Duration);
		{
			Debug.Log ("Player lost  Buff"+abilities[i].Description);
			abilities [i].Deactivate (player);
		}
	}

	public void ActivateAbility(int abilityActivated)
	{
		//checks if cooldown of ability is over and there is enough will power
		//then deducts will power from player accordingly
		//after that the ability is activated
		//the cooldown is loaded into the cooldown manager in a paraller index
		//checks if the ability was a buff by chance to start buff deactivation process this could be done better but as there wont be any more buffs for the game it will do
		//checks if there are any effects to spawn for the ability and spawns them
		if (abilityActivated >=0&&ph.getWillPower()>=abilities[abilityActivated].WillPowerCost) {
			if (abilitySlotCooldowns [abilityActivated] <= 0) {
				ph.ReduceWillPower(abilities[abilityActivated].WillPowerCost);
				abilities [abilityActivated].Activate (player);
				abilitySlotCooldowns [abilityActivated] = abilities [abilityActivated].Cooldown;

				if (abilities [abilityActivated].IsBuff) {
					StartCoroutine (RemoveBuff (player, abilities, abilityActivated));
				}
			}
		}
	}

}
