using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isLeft;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMechsScript.isPaused)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isLeft)
        {
            PlayerScript.shouldMoveLeft = true;
        }
        else
        {
            PlayerScript.shouldMoveRight = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isLeft)
        {
            PlayerScript.shouldMoveLeft = false;
        }
        else
        {
            PlayerScript.shouldMoveRight = false;
        }
    }

}
