using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(direction);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
}
