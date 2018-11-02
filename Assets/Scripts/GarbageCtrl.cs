using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCtrl : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			//Player falls off screen
			GameCtrl.instance.PlayerDied(other.gameObject);
		} else {
			//Destory anything other than player that falls off screen
			Destroy (other.gameObject);		
		}
		
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
