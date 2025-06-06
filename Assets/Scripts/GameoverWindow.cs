using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverWindow : MonoBehaviour
{
    private SoundVolumeManager soundVolumeManager;

    [Header("ゲームオーバー")][SerializeField] private AudioClip gameoverSE;
    void Awake()
    {
        soundVolumeManager = GameObject.Find("SoundVolumeManager").GetComponent<SoundVolumeManager>();
        GetComponent<AudioSource>().PlayOneShot(gameoverSE, soundVolumeManager.GetSEVolume());
    }

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
