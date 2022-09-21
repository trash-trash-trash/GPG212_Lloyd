using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    GameObject gameManager;
    SoccerGameManager gm;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gm = gameManager.GetComponent<SoccerGameManager>();
    }

    void OnTriggerEnter(Collider x)
    {
        if(x.gameObject.tag=="P1Goal")
        {
            gm.ChangeScore(2);
        }
        if(x.gameObject.tag=="P2Goal")
        {
            gm.ChangeScore(1);
        }
    }
}
