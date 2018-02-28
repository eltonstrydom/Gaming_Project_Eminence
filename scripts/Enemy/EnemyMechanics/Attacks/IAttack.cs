using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack  
{
	void Attack(playerHealth ph,GameObject audiosource,AudioClip attackSound,AnimatorController ac,double damage);
	void RangeAttack (AnimatorController ac, GameObject startPosition);

}
