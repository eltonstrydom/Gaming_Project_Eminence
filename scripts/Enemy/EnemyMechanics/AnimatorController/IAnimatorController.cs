using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimatorController  
{
	void AttackTrue (Animator anim) ;             //sets attack animation on
	void RunningTrue(Animator anim) ;          //sets running animation on
	void RunningFalse(Animator anim) ;          //turns off running
	void DeadTrigger (Animator anim)  ;           //plays death animation
	void IdleTrue (Animator anim);                //sets idle on
	void AttackFalse (Animator anim);
}
