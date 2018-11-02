using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	public Transform player;
	//float difference;

	// Use this for initialization
	void Start () {
		//difference = transform.position.y - player.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (player.position.x, player.position.y + difference, transform.position.z);
	}
}
