using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.position += Vector3.up;
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
}
