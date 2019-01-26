using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public bool spawnedFromRight;

    // Start is called before the first frame update
    void Start()
    {
        spawnedFromRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
