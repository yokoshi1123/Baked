using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingChecker : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Imagawayaki").GetComponent<Rigidbody>();
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Landed");
        if (rb.velocity.y <= -0.1f)
        {
            playerController.SetFlipCount(0);
        }
    }
}
