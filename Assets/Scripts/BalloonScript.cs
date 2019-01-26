using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{

    public float timeSwitchDirection;

    public bool shouldStartSwitch;

    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
        if (shouldStartSwitch)
        {
            shouldStartSwitch = false;
            StartCoroutine(WaitToSwitchDirection());
        }
    }

    IEnumerator WaitToSwitchDirection()
    {
        yield return new WaitForSeconds(timeSwitchDirection);

        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * -1f, rigidbody2D.velocity.y);

        Debug.Log(rigidbody2D.velocity);

        shouldStartSwitch = true;
    }
}
