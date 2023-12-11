using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    public PlayerScoreSystem playerScoreSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && playerScoreSystem != null)
        {
            collision.GetComponent<Renderer>().enabled = false;
            playerScoreSystem.IncressScore();
        }
    }
}
