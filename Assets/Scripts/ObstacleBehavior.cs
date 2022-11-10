using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
	public float itemsSpeed = 6f;

	void Update()
	{
		if (GameBehavior.gameRunning)
		{
			transform.Translate(new Vector3(0, 0, -itemsSpeed) * Time.deltaTime);
		}
	}
}
