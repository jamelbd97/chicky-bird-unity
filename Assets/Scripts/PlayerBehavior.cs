using System;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerBehavior : MonoBehaviour
{

	public Animator animator;
	public Rigidbody rigidBody;
	public float jumpforce = 10f;


	// Voice command vars
	private string[] keywords;
	private KeywordRecognizer recognizer;
	private bool voiceActive = false;

	private void Start()
	{
		keywords = new string[3];
		keywords[0] = "Left";
		keywords[1] = "Right";
		keywords[2] = "Jump";
		recognizer = new KeywordRecognizer(keywords);
		recognizer.OnPhraseRecognized += OnKeywordsRecognized;
		recognizer.Start();
	}

	private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
	{
		Debug.Log("Command: " + args.text);

		if (voiceActive)
		{
			if (args.text == keywords[0])
			{
				rigidBody.AddForce(Vector3.left * jumpforce, ForceMode.Impulse);
			}

			if (args.text == keywords[1])
			{
				rigidBody.AddForce(Vector3.right * jumpforce, ForceMode.Impulse);
			}

			if (args.text == keywords[2])
			{
				rigidBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
			}
		}
	}

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
				if (!voiceActive)
				{
					voiceActive = true;
				}
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

	}
}
