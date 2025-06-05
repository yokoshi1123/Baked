using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 startPos;

    [SerializeField] private bool vertical = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        Vector3 newPos = playerPos;

        if (!vertical) newPos.y = startPos.y;
        if (vertical) newPos.x = startPos.x;

        transform.position = newPos;
    }
}
