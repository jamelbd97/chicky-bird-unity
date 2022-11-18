using UnityEngine;

public class Environement : MonoBehaviour
{
	public GameObject obstaclePrefab;

	public GameObject[] spawnPoints;

	public float spawnTime = 0.2f;

	void Start()
	{
		InvokeRepeating("SpawnObstacles", spawnTime, spawnTime);
	}

	void SpawnObstacles()
	{
		if (GameBehavior.gameRunning)
		{
			int index = Random.Range(0, 6);
			int rngHARD = Random.Range(0, 10);

			if (rngHARD == 1)
			{
				Instantiate(obstaclePrefab, spawnPoints[0].transform.position, new Quaternion(0f, 0f, 0f, 1f));
				Instantiate(obstaclePrefab, spawnPoints[1].transform.position, new Quaternion(0f, 0f, 0f, 1f));
				Instantiate(obstaclePrefab, spawnPoints[2].transform.position, new Quaternion(0f, 0f, 0f, 1f));
			}
			else if (rngHARD == 2)
			{
				Instantiate(obstaclePrefab, spawnPoints[3].transform.position, new Quaternion(0f, 0f, 90f, 1f));
				Instantiate(obstaclePrefab, spawnPoints[4].transform.position, new Quaternion(0f, 0f, 90f, 1f));
				Instantiate(obstaclePrefab, spawnPoints[5].transform.position, new Quaternion(0f, 0f, 90f, 1f));
			}
			else
			{
				Instantiate(obstaclePrefab, spawnPoints[index].transform.position, new Quaternion(0f, 0f, index > 2 ? 90f : 0f, 1f));
			}
		}
	}
}
