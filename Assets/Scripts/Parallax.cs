using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides the parallax effect
/// </summary>
public class Parallax : MonoBehaviour {

	public GameObject player;

	public float speed; // Set this to 0.001
	float offsetX;
	Material material;
	PlayerCtrl playerCtrl;

	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer>().material;
		playerCtrl = player.GetComponent<PlayerCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!playerCtrl.isStuck) {
			offsetX += Input.GetAxisRaw ("Horizontal") * speed;

			//handle mobile
			if (playerCtrl.leftPressed) {
				offsetX -= speed;
			} else if (playerCtrl.rightPressed) {
				offsetX += speed;
			}
			material.SetTextureOffset("_MainTex", new Vector2(offsetX, 0));	
		}

	}
}
