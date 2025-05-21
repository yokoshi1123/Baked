using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    private int gotCoinNum = 0;//�l�������R�C���̐�
    private GameObject goal;
    private GameObject goal_imagawa;

    private ScoreManager scoreManager;
    private GameObject coinResult;//�R�C���̍ŏI���ʕ\���p
    private GameObject coinResult_imagawa;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        goal = GameObject.Find("Goal");
        coinResult = GameObject.Find("CoinResult");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotCoinNumInc()
    {
        gotCoinNum++;
        goal_imagawa = goal.transform.GetChild(gotCoinNum).gameObject;
        goal_imagawa.SetActive(true);//�S�[���̍���Ă����₷
        scoreManager.SetCoinScore(gotCoinNum);//ScoreManager��CoinScore�X�V
        coinResult_imagawa = coinResult.transform.GetChild(gotCoinNum + 1).gameObject;
        coinResult_imagawa.SetActive(true);
    }

    public int GetCoinNum()
    {
        return gotCoinNum;
    }
}
