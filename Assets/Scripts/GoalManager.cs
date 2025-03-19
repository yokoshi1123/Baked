using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject clearWindow;

    // Start is called before the first frame update
    //void Start()
    //{
    //    clearWindow = GameObject.Find("ClearWindow");
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clearWindow.SetActive(true);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<PlayerController>().SetFlipCount(2);
        }
    }
}
