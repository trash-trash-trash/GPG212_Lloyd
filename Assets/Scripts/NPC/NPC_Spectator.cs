using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spectator : MonoBehaviour
{
    //Script controls the Spectators watching the match
    //Spectators spawn as one of three teams, cheering for P1, P2 or else are a fairweather fan
    //Spectators Jump for glee if their team scores
    
    private Rigidbody rb;
    Renderer rend;

    enum teamColour { Red, Blue, Neutral };
    teamColour myTeam;
    private string colourScore;

    private float jumpForce;

    private float titterForce;

    private float waitTime;

    private string scoreString;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rend = this.GetComponent<Renderer>();

        int myColourInt = Random.Range(0, 100);

        if(myColourInt <= 42)
        {
            rend.material.SetColor("_Color", Color.red);
            myTeam = teamColour.Red;
        }
        else if (myColourInt <= 84 && myColourInt >= 43)
        {
            rend.material.SetColor("_Color", Color.blue);
            myTeam = teamColour.Blue;
        }
        else
        {
            rend.material.SetColor("_Color", new Color(.56f, .1f, .26f, 1f));
            myTeam = teamColour.Neutral;
        }
        StartCoroutine(Titter());
    }
    
    
    void OnEnable()
    {
        SoccerEventManager.P1ScoredEvent += Jump;
        SoccerEventManager.P2ScoredEvent += Jump;
    }

    void OnDisable()
    {
        SoccerEventManager.P1ScoredEvent -= Jump;
        SoccerEventManager.P2ScoredEvent -= Jump;
    }

    void Jump()
    {
        if (myTeam == teamColour.Neutral)
            LoyaltyTest();
        
        colourScore = PlayerPrefs.GetString("Score");

        //hacky way of jumping for joy
        if (((myTeam == teamColour.Red) && (colourScore == "Red")) ||
            (myTeam == teamColour.Blue) && (colourScore == "Blue"))
        {
            StopAllCoroutines();
            jumpForce = Random.Range(7000, 10000);
            rb.AddForce(transform.up * jumpForce);
            StartCoroutine(Titter());
        }
    }

    private void LoyaltyTest()
    {
        float changeTeam;
        float coinFlip;
        colourScore = PlayerPrefs.GetString("Score");
        changeTeam = Random.Range(0, 100);
        
        if (changeTeam > 50)
        {
            coinFlip = Random.Range(0, 100);
            if ((coinFlip > 50) && (colourScore == "Blue"))
            {
                myTeam = teamColour.Blue;
                rend.material.SetColor("_Color", Color.blue);
            }
            if ((coinFlip <= 50) && (colourScore == "Red"))
            {
                myTeam = teamColour.Red;
                rend.material.SetColor("_Color", Color.red);
            }
        }
    }
    
    
    //idle animation
    private IEnumerator Titter()
    {
        waitTime = Random.Range(1f, 3f);
        yield return new WaitForSeconds(waitTime);
        titterForce = Random.Range(2000,5000);
        rb.AddForce(transform.up * titterForce);
        StartCoroutine(Titter());
    }


}
