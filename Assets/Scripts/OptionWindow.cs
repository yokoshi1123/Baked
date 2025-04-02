using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionWindow : MonoBehaviour
{
    private Animator optionWindow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void HowToPlay()
    {

    }

    public void CloseWindow()
    {

    }
}
