using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAI : IFollow
{
	public  void BasicFollow (NavMeshAgent nav,Transform player,AnimatorController ac)
	{
		
			ac.RunningTrue ();                                                             //play running animation
			nav.destination = player.position;   

			
	}

	public void RunAwayOnLowHealth(NavMeshAgent nav,Transform healthPool,AnimatorController ac)
	{
		ac.RunningTrue ();
		nav.destination = healthPool.position;
	}

}
