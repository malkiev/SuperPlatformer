using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour {

	PlayerCtrl playerCtrl;
	public bool dustParticleOn;
	public Transform dustParticlePosition;

	GameObject player;

	void Start()
	{
		playerCtrl = gameObject.transform.parent.gameObject.GetComponent<PlayerCtrl> ();
		player = gameObject.transform.parent.gameObject;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Ground"))
		{
			if (dustParticleOn) {
				SFXCtrl.instance.ShowPlayerLands(dustParticlePosition.position);
			}
				
			playerCtrl.isJumping = false;
		}

		if(other.gameObject.CompareTag("Platform"))
		{
			if (dustParticleOn) {
				SFXCtrl.instance.ShowPlayerLands(dustParticlePosition.position);
			}

			playerCtrl.isJumping = false;

			player.transform.parent = other.gameObject.transform;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Platform"))
		{
			player.transform.parent = null;
		}
	}
}
