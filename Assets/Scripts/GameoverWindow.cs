using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverWindow : MonoBehaviour
{
    public void RetryStage()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToStageSelect()
    {
        Debug.Log("Stage Select");
        SceneManager.LoadScene("StageSelect");
    }
}
