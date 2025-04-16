using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    private Transform playerTra;
    Vector3 offsetPos = new(0, 0.535f, 0);
    Quaternion offsetRot = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerTra = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offsetPos + playerTra.position;
        transform.rotation = offsetRot * Quaternion.identity;
    }
}
