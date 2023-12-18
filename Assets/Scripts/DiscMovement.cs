using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private const float maxVelocity = 1100f;
    
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Player") && collision.gameObject.name.Contains("Pad"))
        {
            Vector2 newVelocity;

            Vector2 padPosition = collision.gameObject.transform.position;
            float padHeight = collision.collider.bounds.size.y;

            float addedHight = (transform.position.y - padPosition.y) / padHeight;
            addedHight *= 2f;

            newVelocity = (new Vector2(1.4f, addedHight) * body.velocity.x);
            if (Mathf.Abs(newVelocity.x) >= maxVelocity)
            {
                body.totalForce = new Vector2(0, 0);
                body.velocity = new Vector2(maxVelocity * body.velocity.normalized.x, body.velocity.y);
                return;
            }

            body.velocity = newVelocity;
        }
    }

}
