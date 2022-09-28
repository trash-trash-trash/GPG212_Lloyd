using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoccerGameUI : MonoBehaviour
{
    private SoccerGameManager gm;
    
    private int time;
    public TMP_Text timeText;
    
    public TMP_Text P1ScoreText;
    private int P1Score;

    public TMP_Text P2ScoreText;
    private int P2Score;

    public TMP_Text cntdwnText;
    private string countDown;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = this.GetComponent<SoccerGameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time = gm.GameTime();
        timeText.text = time.ToString();

        P1Score = gm.GetPlayerScore(0);
        P1ScoreText.text = P1Score.ToString();
        
        P2Score = gm.GetPlayerScore(1);
        P2ScoreText.text = P2Score.ToString();
        
        countDown = gm.GetCountdown();
        cntdwnText.text = countDown;
    }

}
