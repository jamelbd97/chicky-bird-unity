using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

	public Animator animator;
	public Rigidbody rigidBody;
	public float jumpforce = 10f;

	void Update()
	{
		if (GameBehavior.gameRunning)
		{
			if (GameBehavior.gameMode == 2)
			{
				useAccelerometer();
			}
			else if (GameBehavior.gameMode == 3)
			{
				useCamera();
			}
			else if (GameBehavior.gameMode == 4)
			{
				useVoice();
			}
			else
			{
				useKeyboard();
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

	private void useKeyboard()
	{
		if (Input.GetKeyDown("up"))
		{
			rigidBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
			animator.SetBool("Flying", true);
		}

		if (Input.GetKeyDown("right"))
		{
			rigidBody.AddForce(Vector3.right * jumpforce, ForceMode.Impulse);
		}

		if (Input.GetKeyDown("left"))
		{
			rigidBody.AddForce(Vector3.left * jumpforce, ForceMode.Impulse);
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

	public static bool jump = false, right = false, left = false;
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
