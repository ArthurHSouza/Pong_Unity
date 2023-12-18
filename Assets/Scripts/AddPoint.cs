using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    public PlayerScoreSystem playerScoreSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && playerScoreSystem != null)
        {
            collision.GetComponent<Renderer>().enabled = false;
            playerScoreSystem.IncressScore();
        }
    }
}
