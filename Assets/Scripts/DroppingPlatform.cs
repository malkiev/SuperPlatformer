using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour {

	Rigidbody2D rb;
	public float dropDelay;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PlayerFeet")) {
			Debug.Log ("Cat feet touched platform");
			Invoke ("DropPlatform", dropDelay);
		}
	}

	void DropPlatform()
	{
		rb.bodyType = RigidbodyType2D.Dynamic;
	}
}
