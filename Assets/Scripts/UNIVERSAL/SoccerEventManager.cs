using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum myTeam
{
    Red,
    Blue
};

public class SoccerEventManager : MonoBehaviour
{
    private myTeam currentTeam;
    
    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            P1ScoredFunction();
        }
        if (Input.GetKeyUp("2"))
        {
            P2ScoredFunction();
        }
    }
    
    //event for when Players can Play the game

    public delegate void PlayTime();

    public static event PlayTime PlayTimeEvent;

    public static void PlayTimeFunction()
    {
        PlayTimeEvent?.Invoke();
    }

    //event for scoring
    public delegate void Scored(myTeam currentTeam);

    public static event Scored ScoredEvent;

    public static void ScoredFunction()
    {
        if (ScoredEvent != null)
        {

        }
    }
    
    //event for P1 scoring
    public delegate void P1Scored();

    public static event P1Scored P1ScoredEvent;

    public static void P1ScoredFunction()
    {
        if (P1ScoredEvent != null)
        {
            PlayerPrefs.SetString("Score", "Red");
            P1ScoredEvent();
        }
    }
    
    //event for P2 scoring
    public delegate void P2Scored();

    public static event P2Scored P2ScoredEvent;

    public static void P2ScoredFunction()
    {
        if (P2ScoredEvent != null)
        {
            PlayerPrefs.SetString("Score", "Blue");
            P2ScoredEvent();
        }
    }
    
    //event for an Own goal 
    public delegate void OwnGoal ();

    public static event OwnGoal  OwnGoalEvent;

    public static void OwnGoalFunction()
    {
        if (OwnGoalEvent != null)
        {
            OwnGoalEvent();
        }
    }
}