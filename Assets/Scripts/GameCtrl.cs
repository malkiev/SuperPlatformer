using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {

	public static GameCtrl instance;
	public float restartLevelDelay;

	void Awake()
	{
		if(instance == null)
			instance = this;
	}

	void Start()
	{

	}

	void Update()
	{

	}

	/// <summary>
	/// Restarts level when player dies
	/// </summary>
	public void PlayerDied(GameObject player)
	{
		player.SetActive (false);

		Invoke ("RestartLevel", restartLevelDelay);
	}

	/// <summary>
	/// Players the drowned.
	/// </summary>
	/// <param name="player">Player.</param>
	public void PlayerDrowned(GameObject player)
	{
		Invoke ("RestartLevel", restartLevelDelay);
	}

	void RestartLevel()
	{
		SceneManager.LoadScene ("Gameplay");		
	}
}
