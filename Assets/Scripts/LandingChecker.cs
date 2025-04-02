using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingChecker : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController playerController;
    private BestBeforeDateGauge bbDateGauge;

    private Vector3 firstPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
        playerController = transform.parent.GetComponent<PlayerController>();
        bbDateGauge = GameObject.Find("BestBeforeDateGauge").GetComponent<BestBeforeDateGauge>();

        firstPos = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.gameObject.transform.rotation = Quaternion.identity;
        rb.position = firstPos;
        bbDateGauge.DecreaseGauge(0.1f);
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
            Respawn();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
