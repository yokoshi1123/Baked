using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinResultController : MonoBehaviour
{
    [SerializeField] private float upperFloat = 30f;


    private GameObject player;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        Vector3 myPosition = playerPosition;
        myPosition.y += upperFloat;
        transform.position = myPosition;
    }
}
