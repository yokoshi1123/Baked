using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;

    private Vector3 flipDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = /*transform.GetChild(0).*/GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(new (Input.mousePosition.x, Input.mousePosition.y, 0.45f));
                rb.AddForce(-1 * flipDir, ForceMode.Impulse);
                //rb.AddForce(-1*flipDir.magnitude * new Vector3(0, 1f, 0), ForceMode.Impulse);
                rb.velocity = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
            {
                //rb.AddForce(-1*flipDir, ForceMode.Impulse);
                ////rb.AddForce(-1*flipDir.magnitude * new Vector3(0, 1f, 0), ForceMode.Impulse);
                //rb.velocity = Vector3.zero;

                //rb.angularVelocity = Vector3.zero;
                endPos = Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, 0.45f));
                //Debug.Log("Swiped from " + startPos + "to " + endPos);

                flipDir = (endPos - startPos) * 10;
                //Debug.Log("1:" + flipDir);
                flipDir = Quaternion.Euler(-transform.rotation.x, -transform.rotation.y, -transform.rotation.z) * Quaternion.Euler(20f, 0, 0) * flipDir;
                //Debug.Log("2:" + flipDir);
                flipDir.y = 0;
                Debug.Log("3:" + flipDir + ", magnitude:" + flipDir.magnitude);

                rb.AddForce(flipDir, ForceMode.Impulse);
                rb.AddForce(flipDir.magnitude * new Vector3(0, 1f, 0), ForceMode.Impulse);
                //rb.AddTorque(flipDir * 3600, ForceMode.Impulse);
            }
        }

        //transform.position = rb.position;
    }
}
