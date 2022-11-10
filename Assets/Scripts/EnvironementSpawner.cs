using UnityEngine;

public class EnvironementSpawner : MonoBehaviour
{
	public GameObject parent;

	public GameObject treePrefab;
	public GameObject treeVariantPrefab;
	public GameObject cloudPrefab;
	public GameObject cloudVariantPrefab;

	public GameObject[] spawnPoints;

	private GameObject[] currentItems;
	
	public float treeSpawnTime = 0.2f;
	public float cloudSpawnTime = 0.2f;

	void Start()
	{
		currentItems = new GameObject[spawnPoints.Length];
		InvokeRepeating("SpawnCloud", cloudSpawnTime, cloudSpawnTime);
		InvokeRepeating("SpawnTree", treeSpawnTime, treeSpawnTime);
	}

	void SpawnCloud()
	{
		if (GameBehavior.gameRunning)
		{
			int index = Random.Range(0, 2);

			GameObject prefab;

			if (index == 0)
			{
				prefab = cloudPrefab;
			}
			else
			{
				prefab = cloudVariantPrefab;
			}

			currentItems[index] = Instantiate(prefab, spawnPoints[index].transform.position, Quaternion.identity, parent.transform);
		}
	}

	void SpawnTree()
	{
		if (GameBehavior.gameRunning)
		{
			int index = Random.Range(2, 4);

			GameObject prefab;

			if (index == 2)
			{
				prefab = treePrefab;
			}
			else
			{
				prefab = treeVariantPrefab;
			}

			currentItems[index] = Instantiate(prefab, spawnPoints[index].transform.position, Quaternion.identity, parent.transform);
		}
	}
}
