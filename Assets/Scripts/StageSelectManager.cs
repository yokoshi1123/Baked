using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] stageButtons;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Reloaded");
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock", 1);

        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (i < stageUnlock)
            {
                stageButtons[i].interactable = true;
                stageButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                stageButtons[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                stageButtons[i].interactable = false;
                stageButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                stageButtons[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("StageUnlock", 1);
            SceneManager.LoadScene("StageSelect");
        }
        //if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    PlayerPrefs.SetInt("StageUnlock", 2);
        //    SceneManager.LoadScene("StageSelect");
        //}
        //if (Input.GetKey(KeyCode.Alpha9))
        //{
        //    PlayerPrefs.SetInt("StageUnlock", 9);
        //    SceneManager.LoadScene("StageSelect");
        //}
    }

    public void StageSelect(int stageNum)
    {
        SceneManager.LoadScene("Stage" + stageNum);
    }
}
