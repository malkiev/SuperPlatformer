using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCtrl : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Breakable")) {

			//Show box fragmenting
			SFXCtrl.instance.HandleBoxBreaking (other.gameObject.transform.parent.position);

			gameObject.transform.parent.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

			//Destroy the box
			Destroy (other.gameObject.transform.parent.gameObject);
		}
	}
}
