using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int coinScore = 0;
    private int gaugeScore = 0;

    private int maxGaugeScore = 0;

    private float gaugeRaito1 = 0.3f;
    private float gaugeRaito2 = 0.6f;

    private BestBeforeDateGauge bbDateGauge;

    // Start is called before the first frame update
    void Start()
    {
        bbDateGauge = GameObject.Find("BestBeforeDateGauge").GetComponent<BestBeforeDateGauge>();
        maxGaugeScore = bbDateGauge.GetMaxScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (bbDateGauge.GetScore() <= gaugeRaito1 * maxGaugeScore)
        {
            gaugeScore = 0;
        }
        else if (bbDateGauge.GetScore() <= gaugeRaito2 * maxGaugeScore)
        {
            gaugeScore = 1;
        }
        else
        {
            gaugeScore = 2;
        }

    }

    public int GetCoinScore()
    {
        return coinScore;
    }

    public void SetCoinScore(int num)
    {
        coinScore = num;
    }

    public int GetGaugeScore()
    {
        return gaugeScore;
    }

    public void SetGaugeScore(int num)
    {
        gaugeScore = num;
    }
}
