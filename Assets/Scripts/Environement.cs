using UnityEngine;

public class Environement : MonoBehaviour
{
	public GameObject obstaclePrefab;

	public GameObject[] spawnPoints;

	private GameObject[] currentItems;

	public float spawnTime = 0.2f;

	void Start()
	{
		currentItems = new GameObject[spawnPoints.Length];
		InvokeRepeating("SpawnObstacles", spawnTime, spawnTime);
	}

	void SpawnObstacles()
	{
		if (GameBehavior.gameRunning)
		{
			int index = Random.Range(0, 6);

			currentItems[index] = Instantiate(obstaclePrefab, spawnPoints[index].transform.position, new Quaternion(0f, 0f, index > 2 ? 90f : 0f, 1f));
		}
	}
}
