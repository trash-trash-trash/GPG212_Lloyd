using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoccerGameManager : MonoBehaviour
{
    //controls when the Players can and can't move
    public bool canPlay;
    

    //controls time (time increases by 1 every second)
    int time;
    public TMP_Text timeText;

    //Player One
    //Score
    //Score Text
    //GameObject
    //Starting position transform
    //script
    private int P1Score;
    public TMP_Text P1ScoreText;

    GameObject P1Obj;
    public Vector3 P1StartPos;

    P1Movement P1Script;

    //Player Two
    private int P2Score;
    public TMP_Text P2ScoreText;

    GameObject P2Obj;
    public Vector3 P2StartPos;

    P2Movement P2Script;

    //Ball
    //Game object and position
    GameObject ballObj;
    public Vector3 ballStartPos;

    //Countdown 
    //text
    //controls when the Players can play at the start of the game / after scoring
    public TMP_Text countdownText;
    private int countdownInt;

    // Start is called before the first frame update
    void Start()
    {
        P1Obj = GameObject.FindGameObjectWithTag("P1");
        P1Script = P1Obj.GetComponent<P1Movement>();
        P2Obj = GameObject.FindGameObjectWithTag("P2");
        P2Script = P2Obj.GetComponent<P2Movement>();

        ballObj = GameObject.FindGameObjectWithTag("Ball");

        time=0;
        P1Score=0;
        P2Score=0;

        countdownText.text = "GET READY!";

        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = time.ToString();

        P1ScoreText.text = "P1Score: "+P1Score.ToString();
        P2ScoreText.text = "P2Score: "+P2Score.ToString();        
    }

    public void ChangeScore(int goal)
    {
        switch (goal){
            case 1:
            P1Score++;
            break;

            case 2:
            P2Score++;
            break;
        }

        countdownText.text = "GOAL!!";
        countdownText.enabled = true;

        StartCoroutine(Countdown());

    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        countdownText.text = "GET READY!";

        StopCoroutine(Tick());


        //teleports Players and Ball to start Pos
        P1Obj.transform.position = P1StartPos;
        P1Obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        P2Obj.transform.position = P2StartPos;
        P2Obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ballObj.transform.position = ballStartPos;
        ballObj.GetComponent<Rigidbody>().velocity = Vector3.zero;

        canPlay = false;

        

        yield return new WaitForSeconds(1f);
        
        countdownInt = 3;
        countdownText.text = countdownInt.ToString();

        countdownText.enabled = true;


        yield return new WaitForSeconds(1f);

        countdownInt--;
        countdownText.text = countdownInt.ToString();

        yield return new WaitForSeconds(1f);

        countdownInt--;
        countdownText.text = countdownInt.ToString();

        yield return new WaitForSeconds(1f);

        countdownText.text = "PLAY!!";

        yield return new WaitForSeconds(1f);

        canPlay=true;

        countdownText.enabled=false;

        StartCoroutine(Tick());
        

    }

    private IEnumerator Tick()
    {
        time++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Tick());
    }




}
