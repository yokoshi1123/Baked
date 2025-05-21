using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BestBeforeDateGauge : MonoBehaviour
{
    private Slider gauge;
    private PlayerController playerController;
    private GameObject gameoverWindow;
    
    [SerializeField] private float gaugeMaxValue;
    [SerializeField] private float gaugeDicreaseSpeed;

    [SerializeField] private int maxScore = 5000;

    private bool isWorking = true;

    // Start is called before the first frame update
    void Start()
    {
        gameoverWindow = GameObject.Find("GameoverWindow");
        gameoverWindow.SetActive(false);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        Application.targetFrameRate = 60;

        gaugeMaxValue = 180f * 180;
        gaugeDicreaseSpeed = 1f;

        gauge = GetComponent<Slider>();
        gauge.maxValue = gaugeMaxValue;
        gauge.value = gaugeMaxValue;
        isWorking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gauge.value > 0 && isWorking)
        {
            gauge.value -= gaugeDicreaseSpeed;
        }

        if (gauge.value <= 0 && isWorking)
        {
            playerController.SetCanMove(false);
            gameoverWindow.SetActive(true);
        }


        //if (Input.GetKey(KeyCode.R))
        //{
        //    gauge.maxValue = gaugeMaxValue; 
        //    gauge.value = gaugeMaxValue;
        //}
    }

    public int GetScore()
    {
        if(gauge != null)
        {
            return (int)(maxScore * gauge.normalizedValue);
        }
        else
        {
            Debug.Log("‚È‚ñ‚©Null");
            return -1;
        }
    }

    public int GetMaxScore()
    {
        return maxScore;
    }

    public void SwitchIsWorking()
    {
        isWorking = !isWorking;
    }

    public void SetIsWorking(bool value)
    {
        isWorking = value;
    }

    public void DecreaseGauge(float value)
    {
        gauge.value -= gaugeMaxValue * value;
    }
}
