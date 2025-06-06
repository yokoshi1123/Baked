using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWindow : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenWindow()
    {
        animator.SetTrigger("openWindow");
    }

    public void CloseWindow()
    {
        animator.SetTrigger("closeWindow");
    }

    public void Help()
    {
        Debug.Log("ButtonDown");
    }
}