using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGameSFX : MonoBehaviour
{

    public static AudioClip crowdBoo, crowdCheer ;
    static AudioSource audioSrc;

    void Start()
    {
        crowdBoo = Resources.Load<AudioClip>("crowdBoo");
        crowdCheer = Resources.Load<AudioClip>("crowdCheer");
        
        audioSrc = this.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SoccerEventManager.OwnGoalEvent += PlayBoo;
        SoccerEventManager.P1ScoredEvent += PlayCheer;
        SoccerEventManager.P2ScoredEvent += PlayCheer;
    }

    void OnDisable()
    {
        SoccerEventManager.OwnGoalEvent -= PlayBoo;
        SoccerEventManager.P1ScoredEvent -= PlayCheer;
        SoccerEventManager.P2ScoredEvent += PlayCheer;
    }
    
    private void PlayCheer()
    {
        audioSrc.PlayOneShot (crowdCheer);
    }
    
    private void PlayBoo()
    {
        audioSrc.PlayOneShot (crowdBoo);
    }


}
