using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour {

	//Singleton
	public static SFXCtrl instance;
	public SFX sfx;

	void Awake()
	{
		//singleton
		if (instance == null)
			instance = this;
	}

	/// <summary>
	/// Shows the coin sparkle when collecting a coin
	/// </summary>
	public void ShowCoinSparkle(Vector3 pos)
	{
		Instantiate (sfx.sfx_coin_pickup, pos, Quaternion.identity);
	}

	/// <summary>
	/// Shows the powerup sparkle.
	/// </summary>
	/// <param name="pos">Position.</param>
	public void ShowPowerupSparkle(Vector3 pos)
	{
		Instantiate (sfx.sfx_bullet_pickup, pos, Quaternion.identity);
	}

	/// <summary>
	/// Shows the player lands particle effect
	/// </summary>
	/// <param name="pos">Position.</param>
	public void ShowPlayerLands(Vector3 pos)
	{
		Instantiate (sfx.sfx_player_lands, pos, Quaternion.identity);
	}

	/// <summary>
	/// Shows the splash.
	/// </summary>
	/// <param name="pos">Position.</param>
	public void ShowSplash(Vector3 pos)
	{
		Instantiate (sfx.sfx_spash, pos, Quaternion.identity);
	}

	/// <summary>
	/// Handles the box breaking.
	/// </summary>
	public void HandleBoxBreaking(Vector3 pos)
	{
		Vector2 pos1 = pos;
		pos1.x -= 0.3f;

		Vector2 pos2 = pos;
		pos2.x += 0.3f;

		Vector2 pos3 = pos;
		pos3.x -= 0.3f;
		pos3.y -= 0.3f;

		Vector2 pos4 = pos;
		pos3.x += 0.3f;
		pos3.y += 0.3f;

		Instantiate (sfx.sfx_box_fragment1, pos1, Quaternion.identity);
		Instantiate (sfx.sfx_box_fragment2, pos2, Quaternion.identity);
		Instantiate (sfx.sfx_box_fragment2, pos3, Quaternion.identity);
		Instantiate (sfx.sfx_box_fragment1, pos4, Quaternion.identity);
	}
}
