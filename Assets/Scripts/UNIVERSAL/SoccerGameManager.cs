using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SoccerGameManager : MonoBehaviour
{
    public bool debug;
    
    //controls when the Players can and can't move
    public bool canPlay;

    //controls time (time increases by 1 every second)
    int time;

    //Player One
    //Score
    //Score Text
    //GameObject
    //Starting position transform
    //script
    private int P1Score;

    GameObject P1Obj;
    public Vector3 P1StartPos;

    PlayerMovement pm;

    //Player Two
    private int P2Score;

    GameObject P2Obj;
    public Vector3 P2StartPos;

    //Ball
    //Game object and position
    public GameObject ballObj;
    public Vector3 P1ballStartPos;
    public Vector3 P2ballStartPos;
    Vector3 ballStartPos;

    private int roundInt;
    
    

    //Countdown 
    //text
    //controls when the Players can play at the start of the game / after scoring
    private int countdownInt;
    private string countdownString;

    // Start is called before the first frame update
    void Start()
    {
        //sets Ball and Spectators to ignore Invisible walls
        Physics.IgnoreLayerCollision(3, 6);
        Physics.IgnoreLayerCollision(7,8);
        
        P1Obj = GameObject.FindGameObjectWithTag("P1");
        
        P2Obj = GameObject.FindGameObjectWithTag("P2");

        pm = P1Obj.GetComponent<PlayerMovement>(); 

        ballObj = GameObject.FindGameObjectWithTag("Ball");

        time = 0;
        P1Score = 0;
        P2Score = 0;

        roundInt = (Random.Range(1, 2));

        StartCoroutine(Countdown());
        
        
    }

    public void ChangeScore(int goal)
    {
        countdownString = "GOAL!!";
        
        switch (goal)
        {
            case 1:
                P1Score++;
                break;

            case 2:
                P2Score++;
                break;
        }

        StartCoroutine(Countdown());
    }
    

    public int GetPlayerScore(int x)
    {
        if (x == 0)
            return P1Score;

        if (x == 1)
            return P2Score;

        else 
            return 0;
    }

    private IEnumerator Countdown()
    {
        roundInt++;
        
        if ( roundInt % 2 == 0)
        {
            ballStartPos = P1ballStartPos;
        }
        else
        {
            ballStartPos = P2ballStartPos;
        }
        
        countdownString = "GET READY!";
        canPlay = false;
        SoccerEventManager.PlayTimeFunction();
        
        

        StopCoroutine(Tick());

        //teleports Players and Ball to start Pos
        P1Obj.transform.position = P1StartPos;
        
        P2Obj.transform.position = P2StartPos;
        
        ballObj.transform.position = ballStartPos;
        
        ballObj.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (!debug)
        {

            yield return new WaitForSeconds(1f);

            countdownInt = 3;
            countdownString = countdownInt.ToString();

            yield return new WaitForSeconds(1f);

            countdownInt--;
            countdownString = countdownInt.ToString();


            yield return new WaitForSeconds(1f);

            countdownInt--;
            countdownString = countdownInt.ToString();

            yield return new WaitForSeconds(1f);
        }

        countdownString = "PLAY!!!";

        yield return new WaitForSeconds(1f);

        canPlay = true;
        
        SoccerEventManager.PlayTimeFunction();
        
        StartCoroutine(Tick());

        countdownString= (" ");
    }

    public string GetCountdown()
    {
        return countdownString;
    }

    private IEnumerator Tick()
    {
        time++;
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(Tick());
    }

    public int GameTime()
    {
        return time;
    }
    
    
    //
    private Collider scoreBox;
    
    
}