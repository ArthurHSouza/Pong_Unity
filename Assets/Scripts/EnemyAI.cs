using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject disk;

    private const float velocity = 500f;
    private float padHight;
    private Rigidbody2D body;
    private void Start()
    {
        padHight = GetComponent<Collider2D>().bounds.size.y;
        body = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(this.transform.position.y - disk.transform.position.y) > padHight/2f)
        {
            if (disk.transform.position.y > this.transform.position.y)
            {
                body.velocity = new Vector2(0, 1) * velocity;
            }
            else
            {
                body.velocity = new Vector2(0, -1) * velocity;
            }
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }
}

