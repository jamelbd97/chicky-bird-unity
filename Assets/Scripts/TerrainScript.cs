using UnityEngine;

public class TerrainScript : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (GameBehavior.gameRunning)
			transform.Rotate(new Vector3(-6f * Time.deltaTime, 0, 0));
	}
}
