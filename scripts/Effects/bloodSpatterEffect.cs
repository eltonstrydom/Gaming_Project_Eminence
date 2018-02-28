using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodSpatterEffect : MonoBehaviour {

	public ParticleSystem blood;
	public Transform startPos;





	public void PlayBloodSpatter()

	{
		Debug.Log ("Blood Spatter");
		//this.blood.transform.position = new Vector3 (startPos.position.x, startPos.position.y, startPos.position.z);
		blood.Play ();

	}
}
