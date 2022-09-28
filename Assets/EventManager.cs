using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// I want to ASSOCIATE multiple bits of information together. So we really need a proper concept of a 'team' and everything that goes with it
/// Note that this isn't a MonoBehaviour component. It's just for the GameManager to keep track of thing, but it COULD be.
/// </summary>
[Serializable]
public class Team
{
    public string name;
    public Goal goal;
    public int score;
}

public class EventManager : MonoBehaviour
{
    public Team[] teams;
  
    private void Start()
    {
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
}
