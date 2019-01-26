using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechsScript : MonoBehaviour
{

    public static bool isPaused;

    public static bool isPlaying;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        isPaused = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
