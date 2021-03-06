using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour {

	public GameObject player;

	PlayerCtrl playerCtrl;

	// Use this for initialization
	void Start () {
		playerCtrl = player.GetComponent<PlayerCtrl>();
	}
	
	public void MobileMoveLeft()
	{
		playerCtrl.MobileMoveLeft ();
	}

	public void MobileMoveRight()
	{
		playerCtrl.MobileMoveRight ();
	}

	public void MobileMoveStop()
	{
		playerCtrl.MobileMoveStop ();
	}

	public void MobileJump()
	{
		playerCtrl.MobileJump ();
	}

	public void MobileFire()
	{
		playerCtrl.MobileFire ();
	}
}
