using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public delegate void GoalSignature(Goal goal);

    public event GoalSignature GoalEvent;   

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallScript>() != null)
        {
            
            GoalEvent?.Invoke(this);
        }
    }


}