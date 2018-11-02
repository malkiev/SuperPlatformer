using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour {

	GameObject player;
	PlayerCtrl playerCtrl;

	// Use this for initialization
	void Start () {
		player = transform.parent.gameObject;
		playerCtrl = player.GetComponent<PlayerCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		playerCtrl.isStuck = true;
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		playerCtrl.isStuck = false;
	}
}
