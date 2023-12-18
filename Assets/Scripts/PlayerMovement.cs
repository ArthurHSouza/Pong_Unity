using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 direction;
    private const float speed = 450f;
    public float slideValue;
    public KeyCode keyUp;
    public KeyCode keyDown;
    
    void Start()
    {
        direction = new Vector2();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(keyUp))
        {
            direction.y = speed;
            body.velocity = direction;
            
        }
        else if (Input.GetKey(keyDown))
        {
            direction.y = -speed;
            body.velocity = direction;
        }
        else
        {
            body.velocity = body.velocity * slideValue;
        }
    }
}
