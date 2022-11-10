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
		if (GameBehavior.gameMode == 2)
		{
			useAccelerometer();
		}
		else
		{
			useKeyboard();
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "obstacle")
		{
			GameBehavior.stopGame();
		}
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
			transform.position += Vector3.right;
		}

		if (Input.GetKeyDown("left"))
		{
			transform.position += Vector3.left;
		}
	}

	private void useAccelerometer()
	{
		if (Input.GetKeyDown("up"))
		{
			rigidBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
			animator.SetBool("Flying", true);
		}

		transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
	}

}
