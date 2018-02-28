using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeOrbAbilityPrefab : MonoBehaviour {
	
	Transform player;
	Vector3 position;



	void Awake()
	{
		player= GameObject.FindGameObjectWithTag ("Player").transform;
		Destroy (this.gameObject, 9f);

	}
	void Update () 


	{
		position = new Vector3 (player.position.x,player.position.y+1f,player.position.z);
		transform.position = position;
		transform.Rotate (Vector3.up*Time.deltaTime*300f);
	}



}
