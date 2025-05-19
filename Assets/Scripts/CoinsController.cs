using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    private int gotCoinNum = 0;
    private GameObject goal;
    private GameObject goal_imagawa;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotCoinNumInc()
    {
        gotCoinNum++;
        goal_imagawa = goal.transform.GetChild(gotCoinNum).gameObject;
        goal_imagawa.SetActive(true);
    }

    public int GetCoinNum()
    {
        return gotCoinNum;
    }
}
