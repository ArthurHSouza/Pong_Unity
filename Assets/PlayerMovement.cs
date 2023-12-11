using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 direction;
    public float speed;
    public float slideValue;
    public KeyCode keyUp;
    public KeyCode keyDown;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
