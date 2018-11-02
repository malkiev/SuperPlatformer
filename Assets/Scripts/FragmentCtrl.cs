using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCtrl : MonoBehaviour {

	public Vector2 jumpForce;
	public float destroyDelay;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();	
		rb.AddForce (jumpForce);

		//Destroys the fragment
		Destroy (gameObject, destroyDelay);
	}
	
}
