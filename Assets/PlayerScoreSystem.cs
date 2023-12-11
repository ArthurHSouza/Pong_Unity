using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.SearchService;

public class PlayerScoreSystem : MonoBehaviour
{
    private float score = 0;

    private PlayerScoreSystem[] players;
    private Vector2 [] playersOriginalPosition;
    
    private DiscMovement disc;
    private Vector2 discPosition;

    private bool isRestaringTime = false;
    private const float restartingTime = 2f;
    private float reamaningTime;

    public TextMeshProUGUI text;

    private void Start()
    {
        reamaningTime = restartingTime;

        players = (PlayerScoreSystem[])FindObjectsOfType(typeof(PlayerScoreSystem));
        playersOriginalPosition = new Vector2[players.Length];
        
        for(int i = 0; i < players.Length; i++)
        {
            playersOriginalPosition[i] = players[i].GetComponent<Transform>().position;
        }

        disc = (DiscMovement)FindObjectsOfType(typeof(DiscMovement))[0];
        discPosition = disc.GetComponent<Transform>().position;
    }
    public void IncressScore()
    {
        score++;
        text.text = score.ToString();
        isRestaringTime = true;
    }

    public void Update()
    {
        if (isRestaringTime)
        {
            reamaningTime -= Time.deltaTime;
            if(reamaningTime <= 0 )
            {
                if(score >= 3)
                {
                    ResetGame(true);
                    return;
                }
                ResetGame(false);
            }
        }
    }

    private void ResetGame(bool resetAll)
    {
        if(!resetAll)
        {
            Rigidbody2D discRigiBody = disc.GetComponent<Rigidbody2D>();
            isRestaringTime = false;
            reamaningTime = restartingTime;

            disc.GetComponent<Transform>().position = discPosition;
            disc.GetComponent<Renderer>().enabled = true;
            
            if(discRigiBody.velocity.x > 0) { 
                discRigiBody.velocity = new Vector2(0,0);
                discRigiBody.AddForce(-disc.direction);
            }
            else
            {
                discRigiBody.velocity = new Vector2(0, 0);
                discRigiBody.AddForce(disc.direction);
            }

            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<Transform>().position = playersOriginalPosition[i];
            }
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
