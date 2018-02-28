using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneGrinderLogic : MonoBehaviour {

	public float intervalRate;
	GameObject player;
	bool completedScalingUp;
	float timer;
	Vector3 yOffset;
//	AudioManager am;
//	public AudioClip ac;
	void Awake()
	{
		//am = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager>();
		//am.PlaySound (ac);
		player = GameObject.FindWithTag ("Player");
		yOffset = new Vector3 (0f, 1.2f, 0f);
		completedScalingUp = false;
	}


	void Update () {
		transform.position = player.transform.position + yOffset;
		transform.Rotate (Vector3.up*Time.deltaTime*1000f);

		timer += Time.deltaTime;

		if (timer >= intervalRate&&transform.localScale.x<10f&&!completedScalingUp) {
			timer = 0f;
			transform.localScale = transform.localScale + new Vector3 (0.6f,0f,0.6f);
		}
		if (transform.localScale.x >= 10f) {
			completedScalingUp = true;
		}
		if (completedScalingUp && timer >=intervalRate&&transform.localScale.x>=0f) {
			timer = 0f;
			transform.localScale =  transform.localScale - new Vector3 (0.6f,0f,0.6f);
			if (transform.localScale.x <= 0f) {
				Destroy(this.gameObject);
			}

		}


	}


}
