using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitScript : MonoBehaviour {
	public Transform player;
	public Vector3 offsetEffect;
	float timeCounter = 0;


	void Awake()

	{
		offsetEffect = new Vector3(player.position.x + -14, player.position.y + 9.6f, player.position.z + -9f);
		//trying for tut scene
	
		//transform.position = offsetEffect;

	}
	void Update () 


	{



		timeCounter +=  -1f*Time.deltaTime*8f; // multiply all this with some speed variable (* speed);
		float x = Mathf.Cos (timeCounter);
		float z = Mathf.Sin (timeCounter);
		float y = player.position.y+0.5f;

		//offsetEffect = new Vector3 (player.position.x,player.position.y,player.position.z);

		offsetEffect = new Vector3 (player.position.x,0,player.position.z);
		transform.position = new Vector3 (x, y, z)+ offsetEffect;
		//transform.position = new Vector3 (x, y, z)+ offsetEffect;





		//transform.position = new Vector3 (x, y, z);





	}
}
