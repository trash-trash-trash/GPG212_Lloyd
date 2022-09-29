using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Team
{
    public string name;
    public Goal goal;
    public int teamInt;
    public int score;
}

public class SoccerEventManager : MonoBehaviour
{
        public Team[] teams;

        public GameObject ballObj;
        private BallScript ballScript;
  
        private void Start()
        {
            ballScript = ballObj.GetComponent<BallScript>();
            
            // Subscribe to ALL goals
            for (var index = 0; index < teams.Length; index++)
            {
                var item = teams[index];
                item.goal.GoalEvent += GotGoalEvent;
            }
        }
        private void GotGoalEvent(Goal newGoal)
        {
            // Find the team entry when a goal happens
            foreach (Team team in teams)
            {
                if (team.goal == newGoal)
                {
                    team.score++;
                    Debug.Log("Got goal! "+team.name + " : Score = "+team.score);
                }
            }
        }

        private void Update()
        {
            ballScript.BallTeam();
        }


        //event for when Players can Play the game

    public delegate void PlayTime();

    public static event PlayTime PlayTimeEvent;

    public static void PlayTimeFunction()
    {
        PlayTimeEvent?.Invoke();
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