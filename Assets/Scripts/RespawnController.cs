using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class RespawnController : MonoBehaviour
{

    private Rigidbody rb;
    private PlayerController playerController;
    private BestBeforeDateGauge bbDateGauge;

    private int respawnIndx;
    private Vector3　respawnPos;

    private GameObject checkPoints;

    private bool isAbyss = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
        playerController = transform.parent.GetComponent<PlayerController>();
        bbDateGauge = GameObject.Find("BestBeforeDateGauge").GetComponent<BestBeforeDateGauge>();

        respawnIndx = 0;
        respawnPos = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Abyss")) // 落ちたらリセット
        {
            Respawn();
            //Debug.Log("Fell");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.CompareTag("Respawn"))
        {
            string checkpointName = other.gameObject.name;
            string pattern = @"\d+";
            int checkpointIndx = 0;
            Match match = Regex.Match(checkpointName, pattern);

            if (match.Success)
            {
                checkpointIndx = int.Parse(match.Value);
            }

            if (checkpointIndx > respawnIndx)
            {
                respawnIndx = checkpointIndx;
                respawnPos = other.transform.position;
                respawnPos.y += 0.5f;
            }
        }
    }

    private void Respawn()
    {
        isAbyss = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.gameObject.transform.rotation = Quaternion.identity;
        rb.position = respawnPos;
        bbDateGauge.DecreaseGauge(0.1f);
        isAbyss = false;
    }
}
