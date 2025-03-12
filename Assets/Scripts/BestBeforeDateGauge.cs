using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BestBeforeDateGauge : MonoBehaviour
{
    private Slider gauge;
    
    [SerializeField] private float gaugeMaxValue;
    [SerializeField] private float gaugeDicreaseSpeed;

    [SerializeField] private int maxScore = 5000;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        gaugeMaxValue = 180f * 60;
        gaugeDicreaseSpeed = 1f;

        gauge = GetComponent<Slider>();
        gauge.maxValue = gaugeMaxValue;
        gauge.value = gaugeMaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (gauge.value > 0)
        {
            gauge.value -= gaugeDicreaseSpeed;
        }


        if (Input.GetKey(KeyCode.R))
        {
            gauge.maxValue = gaugeMaxValue; 
            gauge.value = gaugeMaxValue;
        }
    }

    public int GetScore()
    {
        return (int)(maxScore * gauge.normalizedValue);
    }
}
