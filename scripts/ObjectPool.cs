using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Make instances editable in the editor for different items to pool
[System.Serializable]
public class ObjectPoolItem {

	public int amountToPool;
	public GameObject objectToPool;
	public bool shouldExpand;
}
//object pool class handling the lists of gameobjects to pool
public class ObjectPool : MonoBehaviour {

	public static ObjectPool SharedInstance;
	public List<ObjectPoolItem> itemsToPool;
	public List<GameObject> pooledObjects;

	void Awake () {
		SharedInstance = this;
	}
	//loads up all instances of objectpoolitem class and craetes
	void Start () {
		pooledObjects = new List<GameObject>();
		foreach (ObjectPoolItem item in itemsToPool) {
			for (int i = 0; i < item.amountToPool; i++) {
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				pooledObjects.Add(obj);
			}
		}
	}
	//this methods is used to find a available object meaning the gameobject must NOT be ACTIVE to use, 
	//if there is no such item the list will automatically add another gameobject to use meaning the list expands
	public GameObject GetPooledObject(string name) {
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy && pooledObjects [i].name == name) {
				return pooledObjects [i];
			}
		}
		//if nothing was found to return this loops checks if the list is allowed to scale if it is another gameobject is created and set to inactive
		foreach (ObjectPoolItem item in itemsToPool) {
			if (item.objectToPool.name == name) {
				if (item.shouldExpand) {
					GameObject obj = (GameObject)Instantiate (item.objectToPool);
					obj.SetActive (false);
					pooledObjects.Add (obj);
					return obj;
				}
			}
		}
		return null;
	}


}
