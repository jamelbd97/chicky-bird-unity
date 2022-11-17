using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

	public Animator animator;
	public Rigidbody rigidBody;
	public float jumpforce = 10f;
	
	public static bool jump = false, right = false, left = false;

	void Update()
	{
		if (GameBehavior.gameRunning)
		{
			if (GameBehavior.gameMode == 0)
			{
				useSwipe();
			}
			else if (GameBehavior.gameMode == 1)
			{
				useAccelerometer();
			}
			else if (GameBehavior.gameMode == 2)
			{
				useCamera();
			}
			else if (GameBehavior.gameMode == 3)
			{
				useVoice();
			}
		}
		else
		{
			if (animator.GetBool("Flying"))
			{
				animator.SetBool("Flying", false);
			}
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "obstacle")
		{
			Handheld.Vibrate();
			GameBehavior.stopGame();
		}
		else { }
	}

	private void useSwipe()
	{
		if (jump)
		{
			rigidBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
			animator.SetBool("Flying", true);
			jump = false;
		}

		if (right)
		{
			rigidBody.AddForce(Vector3.right * jumpforce, ForceMode.Impulse);
			right = false;
		}

		if (left)
		{
			rigidBody.AddForce(Vector3.left * jumpforce, ForceMode.Impulse);
			left = false;
		}
	}

	private void useAccelerometer()
	{
		animator.SetBool("Flying", true);
		transform.Translate(Input.acceleration.x * Time.deltaTime * 2, Math.Abs(Input.acceleration.z) * Time.deltaTime * 5, 0);
	}

	private void useCamera()
	{

	}

	private void useVoice()
	{
		if (jump)
		{
			rigidBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
			jump = false;
		}

		if (right)
		{
			rigidBody.AddForce(Vector3.right * jumpforce, ForceMode.Impulse);
			right = false;
		}

		if (left)
		{
			rigidBody.AddForce(Vector3.left * jumpforce, ForceMode.Impulse);
			left = false;
		}
	}
}
