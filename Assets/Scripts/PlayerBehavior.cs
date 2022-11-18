using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	public GameObject cameraPreview;
	public Animator animator;
	public Rigidbody rigidBody;
	public float jumpforce = 10f;
	
	public static bool jump = false, right = false, left = false;
	public static bool jumpVoice = false, rightVoice = false, leftVoice = false;

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
			cameraPreview.SetActive(false);
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
		cameraPreview.SetActive(true);
		rigidBody.useGravity = false;

		float normX = ((FaceDetector.x * 4) / 1000) - 1;
		float normY = ((FaceDetector.y * 4) / 1000) + 0;

		animator.SetBool("Flying", true);
		transform.position = new Vector3(normX, normY, transform.position.z);
		//transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, normX, 0), step);
	}

	private void useVoice()
	{
		if (jumpVoice)
		{
			rigidBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
			jumpVoice = false;
		}

		if (rightVoice)
		{
			rigidBody.AddForce(Vector3.right * jumpforce, ForceMode.Impulse);
			rightVoice = false;
		}

		if (leftVoice)
		{
			rigidBody.AddForce(Vector3.left * jumpforce, ForceMode.Impulse);
			leftVoice = false;
		}
	}
}
