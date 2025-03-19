using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingChecker : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(gameObject.name + " : Landed");
        if (other.CompareTag("Stage") && rb.velocity.y <= 0)
        {
            playerController.SetFlipCount(0);
        }

        if (other.CompareTag("Abyss")) // —Ž‚¿‚½‚çƒŠƒZƒbƒg
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
