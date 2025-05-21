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

    //private int maxScore = 9999;
    private BestBeforeDateGauge bbDateGauge;
    private int myScore;
    [SerializeField] private TextMeshProUGUI score;

    private ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //if (this.gameObject.name == "ClearWindow")
        //{
        /*int*/ stageUnlock = PlayerPrefs.GetInt("StageUnlock", 1);
        if (SceneManager.GetActiveScene().name == "Stage" + stageUnlock.ToString()) // 解放されている最終ステージ
        {
            PlayerPrefs.SetInt("StageUnlock", Mathf.Min(stageUnlock + 1, STAGE_MAX_NUM));
            //Debug.Log("Alpha");
        }

        if (SceneManager.GetActiveScene().name == "Stage" + STAGE_MAX_NUM.ToString())
        {
            nextStage.GetComponent<Button>().interactable = false;
        }

        //Debug.Log("Beta");

        // ゲージから点数を反映するコードをここに書く
        bbDateGauge = GameObject.Find("BestBeforeDateGauge").GetComponent<BestBeforeDateGauge>();
        bbDateGauge.SetIsWorking(false);
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        myScore = scoreManager.GetGaugeScore();
        switch (myScore)
        {
            case 0:
                score.text = "これ賞味期限\n大丈夫？";
                break;
            case 1:
                score.text = "お粗末様でした。";
                break;
            case 2:
                score.text = "非常においしく\nいただけました。";
                break;
            default:
                score.text = "ScoreError";
                break;
        }
         
        //score.text = myScore.ToString();
        Time.timeScale = 0;
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage()
    {
        Time.timeScale = 1;
        Debug.Log("Next Stage");
        /*int*/ stageUnlock = PlayerPrefs.GetInt("StageUnlock", 1);
        SceneManager.LoadScene("Stage" + stageUnlock);
    }

    public void RetryStage()
    {
        Time.timeScale = 1;
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToStageSelect()
    {
        Time.timeScale = 1;
        Debug.Log("Stage Select");
        SceneManager.LoadScene("StageSelect");
    }
}
