using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearWindow : MonoBehaviour
{
    [SerializeField] private static int STAGE_MAX_NUM = 12;

    [SerializeField] private GameObject nextStage;

    [SerializeField] private int stageUnlock;

    private int maxScore = 9999;
    private BestBeforeDateGauge gauge;
    private int myScore;
    [SerializeField] private TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        /*int*/ stageUnlock = PlayerPrefs.GetInt("StageUnlock", 1);
        if (SceneManager.GetActiveScene().name == "Stage" + stageUnlock.ToString()) // 解放されている最終ステージ
        {
            PlayerPrefs.SetInt("StageUnlock", Mathf.Min(stageUnlock + 1, STAGE_MAX_NUM));
            Debug.Log("Alpha");
        }

        if (SceneManager.GetActiveScene().name == "Stage" + STAGE_MAX_NUM.ToString())
        {
            nextStage.GetComponent<Button>().interactable = false;
        }

        Debug.Log("Beta");

        // ゲージから点数を反映するコードをここに書く
        gauge = GameObject.Find("BestBeforeDateGauge").GetComponent<BestBeforeDateGauge>();
        myScore = gauge.GetScore();
        score.text = myScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage()
    {
        Debug.Log("Next Stage");
        /*int*/ stageUnlock = PlayerPrefs.GetInt("StageUnlock", 1);
        SceneManager.LoadScene("Stage" + stageUnlock);
    }

    public void RetryStage()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoStageSelect()
    {
        Debug.Log("Stage Select");
        SceneManager.LoadScene("StageSelect");
    }
}
