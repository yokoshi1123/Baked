using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionWindow : MonoBehaviour
{
    private Animator optionWindow;
    private PlayerController playerController;

    private bool isOpen = false;

    private GameObject howToPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        optionWindow = GetComponent<Animator>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        howToPlay = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerController.SetCanMove(!isOpen);
    }

    public void RetryStage()
    {
        //Time.timeScale = 1;
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToTitle()
    {
        //Time.timeScale = 1;
        Debug.Log("Back to Title");
        SceneManager.LoadScene("Title");
    }

    public void HowToPlay(bool value)
    {
        howToPlay.SetActive(value);
    }

    public void OpenOrCloseTheWindow()
    {
        isOpen = !isOpen;
        optionWindow.SetBool("isOpen", isOpen);
    }
}
