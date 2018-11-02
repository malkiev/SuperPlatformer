using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Transform pos1, pos2;
	public Transform startPos;
	public float speed;
	Vector2 nextPosition;

	// Use this for initialization
	void Start () {
		nextPosition = startPos.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position == pos1.position) {
			nextPosition = pos2.position;
		}

		if (transform.position == pos2.position) {
			nextPosition = pos1.position;
		}

		transform.position = Vector2.MoveTowards (transform.position, nextPosition, speed * Time.deltaTime);
	}
		
	void OnDrawGizmos()
	{
		Gizmos.DrawLine (pos1.position, pos2.position);
	}
}
