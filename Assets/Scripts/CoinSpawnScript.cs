using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{

    public GameObject coin;

    public GameObject[] formations;

    public float[] widthOfFormations;

    public float[] timeWaitAfterFormation;

    public float[] rangeTimeWait;

    public float speed;

    public float maxSpeed;

    private float speedVar;

    private float[] rangeTimeSpeedChange;

    private bool shouldSpawn;

    // Start is called before the first frame update
    void Start()
    {
        shouldSpawn = true;
        speedVar = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn)
        {
            shouldSpawn = false;
            StartCoroutine(WaitForCoinSpawn());
        }

    }

    IEnumerator WaitForCoinSpawn()
    {
        yield return new WaitForSeconds(Random.Range(rangeTimeWait[0], rangeTimeWait[1]));

        int random = Random.Range(0, 5);

        if (random == 0)
        {
            int index = Random.Range(0, formations.Length);
            GameObject formation = Instantiate(
                formations[index], 
                new Vector3(Random.Range(-2.5f + widthOfFormations[index] / 2, 2.5f - widthOfFormations[index] / 2), 8, 0), 
                Quaternion.identity
            );

            formation.transform.parent = transform;

            Rigidbody2D[] rigidbody2Ds = formation.transform.GetComponentsInChildren<Rigidbody2D>();
            for (int i = 0; i < rigidbody2Ds.Length; i++)
            {
                rigidbody2Ds[i].velocity = new Vector2(0, -speedVar);
            }

            //yield return new WaitForSeconds(timeWaitAfterFormation[index]);
        }
        else
        {
            GameObject coinClone = Instantiate(coin, new Vector3(Random.Range(-2.2f, 2.2f), 8, 0), Quaternion.identity);

            coinClone.transform.parent = transform;

            Rigidbody2D rigidbody2D = coinClone.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(0, -speedVar);
        }

        shouldSpawn = true;

    }
}
