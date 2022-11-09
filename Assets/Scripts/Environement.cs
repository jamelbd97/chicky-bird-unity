using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Environement : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public GameObject leftSpawnPoint;
    public GameObject middleSpawnPoint;
    public GameObject rightSpawnPoint;

    private GameObject currentLeftItem;
    private GameObject currentMiddleItem;
    private GameObject currentRightItem;

    public float itemsSpeed = 6f;
    public float spawnTime = 0.2f;

    void Start()
    {
        InvokeRepeating ("SpawnObstacles", spawnTime, spawnTime);
    }

    void Update()
    {
        if (currentLeftItem != null){
            currentLeftItem.transform.Translate(new Vector3(0, 0, -itemsSpeed) * Time.deltaTime);
        }

        if (currentMiddleItem != null){
            currentMiddleItem.transform.Translate(new Vector3(0, 0, -itemsSpeed) * Time.deltaTime);
        }

        if (currentRightItem != null){
            currentRightItem.transform.Translate(new Vector3(0, 0, -itemsSpeed) * Time.deltaTime);
        }
    }

    void SpawnObstacles()
    {
        int x = Random.Range(0,3);

        if (x == 0) {
            if (currentLeftItem != null){
                Destroy(currentLeftItem);
            }
            currentLeftItem = Instantiate(obstaclePrefab, leftSpawnPoint.transform.position, Quaternion.identity);
        } else if (x == 1){
            if (currentMiddleItem != null){
                Destroy(currentMiddleItem);
            }
            currentMiddleItem = Instantiate(obstaclePrefab, middleSpawnPoint.transform.position, Quaternion.identity);
        } else if (x == 2){
            if (currentRightItem != null){
                Destroy(currentRightItem);
            }
            currentRightItem = Instantiate(obstaclePrefab, rightSpawnPoint.transform.position, Quaternion.identity);
        }
                        
    }
}
