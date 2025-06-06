using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningWindow : MonoBehaviour
{

    private GameObject howtoPlayWindow;

    // Start is called before the first frame update
    void Start()
    {
        howtoPlayWindow = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HowtoPlay(bool value)
    {
        howtoPlayWindow.SetActive(value);
    }
}
