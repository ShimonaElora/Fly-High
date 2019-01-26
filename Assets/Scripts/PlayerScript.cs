using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static bool shouldMoveLeft;

    public static bool shouldMoveRight;

    public float speed;

    private float width;

    public float padding;

    // Start is called before the first frame update
    void Start()
    {
        shouldMoveLeft = false;
        shouldMoveRight = false;

        width = GetComponent<MeshRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMoveLeft && transform.position.x >= (-2.5 + width / 2 + padding))
        {
            transform.Translate(new Vector3( - speed * 0.1f, 0, 0));
        }

        if (shouldMoveRight && transform.position.x <= (2.5 - width / 2 - padding))
        {
            transform.Translate(new Vector3(speed * 0.1f, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("coin"))
        {
            GameMechsScript.score++;
        }

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            GameMechsScript.isPlaying = false;
        }
    }
}
