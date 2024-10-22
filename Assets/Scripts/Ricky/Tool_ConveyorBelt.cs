using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public enum Direction
{
    Up=0,
    Left=1,
    Right=2,
    Down=3
}

public class Tool_ConveyorBelt : MonoBehaviour
{
    public Direction direction = Direction.Up;
    public float speed = 5f;
    //private Rigidbody2D rb;

    public void OnTriggerConveyorBelt(Collision2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        Vector2 forceDirection = new Vector2();

        switch (direction)
        {
            case Direction.Up:
                {
                    forceDirection = new Vector2(0f, 1f);
                }
                break;
            case Direction.Left:
                {
                    forceDirection = new Vector2(-1f, 0f);
                }
                break;
            case Direction.Right:
                {
                    forceDirection = new Vector2(1f, 0f);
                }
                break;
            case Direction.Down:
                {
                    forceDirection = new Vector2(0f, -1f);
                }
                break;


        }
        Vector2 rotatedVector = transform.rotation * forceDirection;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(rotatedVector * speed, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = true;

       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        OnTriggerConveyorBelt(collision);
    }
}
