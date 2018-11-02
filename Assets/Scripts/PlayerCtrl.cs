using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make the player move, jump, flip the player while turning
/// </summary>
public class PlayerCtrl : MonoBehaviour
{

	Rigidbody2D rigidBody2D;
	SpriteRenderer spriteRenderer;
	Animator animator;

	public bool isGrounded, canDoubleJump;
	public Transform feet;
	public float feetRadius;
	public LayerMask whatIsground;
	public float boxWidth;
	public float boxHeight;
	public float doubleJumpDelay;
	public Transform leftBulletSpawnPos, rightBulletSpawnPos;
	public GameObject leftBullet, rightBullet;
	public bool leftPressed, rightPressed;
	public bool SFXOn;
	public bool canFireBullets;
	public bool isJumping;
	public bool isStuck;

	[Tooltip ("Positive integer which speeds up the player movement")]
	public int speed;

	[Tooltip ("Positive integer which speeds up the player jump")]
	public int jumpSpeed;

	// Use this for initialization
	void Start ()
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		isJumping = false;
	}

	// Update is called once per frame
	void Update ()
	{
		isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth, boxHeight),360.0f, whatIsground);

		float playerSpeed = Input.GetAxisRaw ("Horizontal"); // value will be 1, -1 or 0
		playerSpeed *= speed;

		if (playerSpeed != 0) {
			MoveHorizontal (playerSpeed);
		} else {
			StopMoving ();
		}

		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

		if (Input.GetButtonDown ("Fire1")) {
			FireBullet ();
		}

		ShowFalling ();

		if (leftPressed)
			MoveHorizontal (-speed);

		if (rightPressed)
			MoveHorizontal (speed);
	}

	void MoveHorizontal (float speed)
	{
		rigidBody2D.velocity = new Vector2 (speed, rigidBody2D.velocity.y);

		spriteRenderer.flipX = speed < 0;

		if (!isJumping) {
			SetAnimation (CatAnimationState.Running);
		}
	}

	void StopMoving ()
	{
		rigidBody2D.velocity = new Vector2 (0, rigidBody2D.velocity.y);

		if (!isJumping) {
			SetAnimation (CatAnimationState.Idle);
		}
	}

	void Jump ()
	{
		if (isGrounded) {
			isJumping = true;
			rigidBody2D.AddForce (new Vector2 (0, jumpSpeed));

			SetAnimation (CatAnimationState.Jumping);

			Invoke ("EnableDoubleJump", doubleJumpDelay);
		}

		if(canDoubleJump && !isGrounded){
			isJumping = true;
			rigidBody2D.AddForce (new Vector2 (0, jumpSpeed));

			SetAnimation (CatAnimationState.Jumping);

			canDoubleJump = false;
		}
	}

	void EnableDoubleJump()
	{
		canDoubleJump = true;
	}

	void SetAnimation (CatAnimationState catAnimationState)
	{
		animator.SetInteger ("State", (int)catAnimationState);
	}

	void ShowFalling()
	{
		if (rigidBody2D.velocity.y < 0) {
			SetAnimation (CatAnimationState.Falling);
		}
	}

	void FireBullet()
	{
		if (!canFireBullets)
			return;
		
		if(spriteRenderer.flipX)
			Instantiate (leftBullet, leftBulletSpawnPos.position, Quaternion.identity);
		else
			Instantiate (rightBullet, rightBulletSpawnPos.position, Quaternion.identity);
	}

	void OnDrawGizmos()
	{
		//Gizmos.DrawWireSphere (feet.position, feetRadius);

		Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		switch (other.gameObject.tag) {
		case "Coin":{
				if (SFXOn) {
					SFXCtrl.instance.ShowCoinSparkle (other.gameObject.transform.position);
				}
					
				break;
			}
		case "Water":
			{
				// Water splash effect
				if (SFXOn) {
					SFXCtrl.instance.ShowSplash (other.gameObject.transform.position);
				}

				//Inform Game Ctrl
				GameCtrl.instance.PlayerDrowned(gameObject);
				break;
			}
		case "Powerup_Bullet":{
				canFireBullets = true;
				Vector2 powerUpPosition = other.gameObject.transform.position;
				Destroy (other.gameObject);

				if (SFXOn) {
					SFXCtrl.instance.ShowPowerupSparkle (powerUpPosition);
				}

				break;
			}
		default: {
				break;
			}
		}
	}


	public void MobileMoveLeft ()
	{
		leftPressed = true;
	}

	public void MobileMoveRight()
	{
		rightPressed= true;
	}

	public void MobileMoveStop ()
	{
		leftPressed = false;
		rightPressed = false;

		StopMoving ();
	}

	public void MobileFire()
	{
		FireBullet ();
	}

	public void MobileJump()
	{
		Jump ();
	}
}
