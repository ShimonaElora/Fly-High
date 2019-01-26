using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject bird;

    public GameObject balloon;

    public float[] rangeTimeBirdSpawn;

    public float[] rangeTimeBalloonSpawn;

    public float speedXBird;

    public float[] rangeSpeedXBalloon;

    public float speedYBalloon;

    public float[] rangeTimeBalloonChangeDirection;

    private bool shouldSpawnBird;

    private bool shouldSpawnBalloon;

    // Start is called before the first frame update
    void Start()
    {
        shouldSpawnBird = true;
        shouldSpawnBalloon = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawnBird)
        {
            shouldSpawnBird = false;
            StartCoroutine(WaitForBirdSpawn());
        }

        if (shouldSpawnBalloon)
        {
            shouldSpawnBalloon = false;
            StartCoroutine(WaitForBalloonSpawn());
        }
    }

    IEnumerator WaitForBirdSpawn()
    {
        yield return new WaitForSeconds(Random.Range(rangeTimeBirdSpawn[0], rangeTimeBirdSpawn[1]));

        SpawnBird();
    }

    IEnumerator WaitForBalloonSpawn()
    {
        yield return new WaitForSeconds(Random.Range(rangeTimeBalloonSpawn[0], rangeTimeBalloonSpawn[1]));

        SpawnBalloon();
    }

    void SpawnBird()
    {
        if (Random.Range(0, 2) == 0)
        {
            GameObject birdClone = Instantiate(bird, new Vector3(3.5f, Random.Range(-2, 4), 0), Quaternion.identity);

            birdClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-speedXBird, speedXBird * -6f / 5f);
        }
        else
        {
            GameObject birdClone = Instantiate(bird, new Vector3(-3.5f, Random.Range(-2, 4), 0), Quaternion.identity);

            birdClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speedXBird, speedXBird * -6f / 5f);
        }

        shouldSpawnBird = true;
    }

    void SpawnBalloon()
    {
        float timeSwitchDirection = Random.Range(rangeTimeBalloonChangeDirection[0], rangeTimeBalloonChangeDirection[1]);

        float speedX = Random.Range(rangeSpeedXBalloon[0], rangeSpeedXBalloon[1]);

        float dis = timeSwitchDirection * speedX;

        GameObject balloonClone = Instantiate(balloon, new Vector2(Random.Range(-2.5f + dis / 2, 2.5f - dis / 2), 7), Quaternion.identity);
        balloonClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, -speedYBalloon);
       
        balloonClone.GetComponent<BalloonScript>().timeSwitchDirection = timeSwitchDirection;
        balloonClone.GetComponent<BalloonScript>().shouldStartSwitch = true;

        shouldSpawnBalloon = true;

    }
}
