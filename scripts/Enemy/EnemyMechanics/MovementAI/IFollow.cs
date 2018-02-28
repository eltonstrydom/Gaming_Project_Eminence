using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IFollow {

	void BasicFollow (NavMeshAgent nav,Transform player,AnimatorController ac);
	 void RunAwayOnLowHealth (NavMeshAgent nav, Transform healthPool, AnimatorController ac);

}
