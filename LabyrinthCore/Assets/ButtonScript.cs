using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float returnSpeed = 0.5f;
    public float maxDistance = 5.0f;
    public Transform movingObject;

    private Vector2 originalPosition;
    private bool isTouching = false;

    void Start()
    {
        originalPosition = movingObject.position;
    }

    void Update()
    {
        if (isTouching)
        {
            float moveAmount = moveSpeed * Time.deltaTime;
            float newX = movingObject.position.x + moveAmount;

            if (newX - originalPosition.x <= maxDistance)
            {
                movingObject.position = new Vector2(newX, movingObject.position.y);
            }
        }
        else
        {
            movingObject.position = Vector2.Lerp(movingObject.position, originalPosition, returnSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouching = false;
        }
    }
}
