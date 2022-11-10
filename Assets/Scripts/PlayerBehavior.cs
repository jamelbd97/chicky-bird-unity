using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

	public Animator animator;
	public Rigidbody rigidBody;
	public float jumpforce = 10f;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (GameBehavior.gameRunning)
		{
			if (GameBehavior.gameMode == 2)
			{
				useAccelerometer();
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
		} else { }
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

}
