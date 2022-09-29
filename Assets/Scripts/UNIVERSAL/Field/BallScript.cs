using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    GameObject gameManager;
    SoccerGameManager gm;
    
    float thrust = 3000f;

    private bool canPlay = true;

    private Rigidbody rb;

    public enum myTeam
    {
        Neutral,
        Red,
        Blue
    };

    private myTeam currentTeam;
    int currentTeamInt;
    
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gm = gameManager.GetComponent<SoccerGameManager>();

        rb = this.GetComponent<Rigidbody>();

        currentTeam = myTeam.Neutral;
        currentTeamInt = (int)currentTeam;
    }

    void Update()
    {
        if(!canPlay)
            rb.velocity = Vector3.zero;
    }
    

    void OnTriggerEnter(Collider x)
    {
        if(x.gameObject.tag=="P1Goal")
        { 
            if (currentTeam == myTeam.Blue)
                     {
                         SoccerEventManager.OwnGoalFunction();
                     }
            SoccerEventManager.P1ScoredFunction();
            gm.ChangeScore(1);
        }
        if(x.gameObject.tag=="P2Goal")
        {
            if (currentTeam == myTeam.Red)
                     {
                         SoccerEventManager.OwnGoalFunction();
                     }
            SoccerEventManager.P2ScoredFunction();
            gm.ChangeScore(2);
        }

        if (x.gameObject.tag == "P1")
        {
            rb.AddRelativeForce(Vector3.up * thrust);
            currentTeam = myTeam.Red;
        }

        if (x.gameObject.tag == "P2")
        {
            rb.AddForce(Vector3.up * thrust);
            currentTeam = myTeam.Blue;
        }
        
       
    }

    private void OnCollisionEnter(Collision x)
    {
        if (x.gameObject.tag == "P1")
        {
            Vector3 dir = x.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * thrust);
        }
        if (x.gameObject.tag == "P2")
        {
            Vector3 dir = x.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * thrust);
        }
        
         if (x.gameObject.tag == "InvisibleWall")
                {
                    Vector3 dir = x.contacts[0].point - transform.position;
                    dir = -dir.normalized;
                    rb.AddForce(dir * thrust);
                }
    }

    void OnEnable()
    {
        SoccerEventManager.PlayTimeEvent += SwitchPlay;
    }
    

    public void SwitchPlay()
    {
        canPlay = !canPlay;
    }

    public int BallTeam()
    {
        return currentTeamInt;
    }
}
