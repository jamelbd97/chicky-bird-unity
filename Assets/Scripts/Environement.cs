using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Environement : MonoBehaviour
{
	public GameObject obstaclePrefab;

	public GameObject[] spawnPoints;

	private GameObject[] currentItems;

	public float itemsSpeed = 6f;
	public float spawnTime = 0.2f;

	void Start()
	{
		currentItems = new GameObject[spawnPoints.Length];
		InvokeRepeating("SpawnObstacles", spawnTime, spawnTime);
	}

	void Update()
	{
		if (GameBehavior.gameRunning)
		{
			foreach (GameObject currentItem in currentItems)
			{
				if (currentItem != null)
				{
					currentItem.transform.Translate(new Vector3(0, 0, -itemsSpeed) * Time.deltaTime);
				}
			}
		}
	}

	void SpawnObstacles()
	{
		if (GameBehavior.gameRunning)
		{
			int index = Random.Range(0, 6);

			if (currentItems[index] != null)
			{
				Destroy(currentItems[index]);
			}

			currentItems[index] = Instantiate(obstaclePrefab, spawnPoints[index].transform.position, new Quaternion(0f, 0f, index > 2 ? 90f : 0f, 1f));
		}
	}
}
