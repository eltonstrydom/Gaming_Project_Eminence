using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour 
{
	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	public void AttackTrue()              //sets attack animation on
	{
		anim.SetBool ("Attack",true);
		anim.SetBool ("Run",false);
		anim.SetBool ("Idle",false);
		anim.SetBool ("Rage",false);

	}

	public void RunningTrue()           //sets running animation on

	{
		anim.SetBool ("Attack",false);
		anim.SetBool ("Run", true);
		anim.SetBool("Idle",false);
		anim.SetBool ("Rage",false);
	}
	public void RunningFalse()           //turns off running

	{
		anim.SetBool ("Run",false);

	}

	public void DeadTrigger()             //plays death animation

	{
		anim.SetTrigger ("IsDead"); 
	}

	public void IdleTrue()                //sets idle on

	{
		anim.SetBool ("Idle", true);
		anim.SetBool ("Attack",false);
		anim.SetBool ("Run",false);
		anim.SetBool ("Rage",false);

	}

	public void AttackFalse()
	{
		anim.SetBool ("Attack",false);
		anim.SetBool ("Run",false);
		anim.SetBool ("Idle",false);
		anim.SetBool ("Rage",false);
	}

	public void RageTrue()
	{
		anim.SetBool ("Rage",true);
		anim.SetBool ("Run",false);
		anim.SetBool ("Idle",false);
	}
}
