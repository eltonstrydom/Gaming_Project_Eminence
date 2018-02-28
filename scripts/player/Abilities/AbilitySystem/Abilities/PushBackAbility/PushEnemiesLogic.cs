using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnemiesLogic : MonoBehaviour {
	public float intervalRate;
	GameObject player;
	bool completedScalingUp;
	float timer;
	AudioManager am;
	AudioClip ac;
	void Awake()
	{
		am = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager>();
		ac = Resources.Load<AudioClip>("Sounds/Rage");
		am.PlaySound (ac);
		player = GameObject.FindWithTag ("Player");
		completedScalingUp = false;
	}


	void Update () {
		transform.position = player.transform.position;
	
		timer += Time.deltaTime;

		if (timer >= intervalRate&&transform.localScale.x<10f&&!completedScalingUp) {
			timer = 0f;
			transform.localScale = transform.localScale + new Vector3 (0.6f,0.6f,0.6f);
		}
		if (transform.localScale.x >= 10f) {
			completedScalingUp = true;
		}
		if (completedScalingUp && timer >=intervalRate&&transform.localScale.x>=0f) {
			timer = 0f;
			transform.localScale =  transform.localScale - new Vector3 (0.6f,0.6f,0.6f);
			if (transform.localScale.x <= 0f) {
				this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
				StartCoroutine (Destroy());
			}

		}
			
		
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}



