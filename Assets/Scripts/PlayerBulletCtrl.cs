﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCtrl : MonoBehaviour {

	Rigidbody2D rigidBody;
	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		rigidBody = this.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		rigidBody.velocity = velocity;
	}
}
