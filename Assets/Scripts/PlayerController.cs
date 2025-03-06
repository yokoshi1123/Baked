using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveableScreenHeight = 0.6f;
    private bool MouseButtonDown = false;
    private Vector3 touchPos = Vector3.zero;

    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;

    private Vector3 flipDir = Vector3.zero;

    private float cameraDepth = 0.45f;

    [SerializeField] private float mag = 10f;

    private float torqueForce = 720f;

    [SerializeField] private int flipCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = /*transform.GetChild(0).*/GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && flipCount < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, cameraDepth)) - transform.position;
                Time.timeScale = 0.2f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;
                endPos = Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, cameraDepth)) - transform.position;
                //Debug.Log("End: " + Input.mousePosition);
                Debug.Log("From " + startPos + " to " + endPos);

                flipDir = (endPos - startPos) * 5;
                //Debug.Log("1:" + flipDir);
                //flipDir = Quaternion.Euler(20f, 0, 0) * flipDir;
                //flipDir = Quaternion.Inverse(transform.rotation) * flipDir;
                flipDir.z = flipDir.y;
                flipDir.y = 0;
                Debug.Log("flipDir: " + flipDir + ", magnitude: " + flipDir.magnitude);

                Time.timeScale = 1f;
                //rb.isKinematic = false;
                rb.AddForce(flipDir, ForceMode.Impulse);
                rb.AddForce(Vector3.up * Mathf.Min(Mathf.Sqrt(flipDir.magnitude) * 4f, 16f), ForceMode.Impulse);

                if (flipDir.magnitude > 0.01f)
                {
                    // 前方ベクトルに対する移動方向の角度を計算
                    //float angle = Vector3.SignedAngle(Vector3.up, transform.position + flipDir, new Vector3(flipDir.z, 0, -flipDir.x));
                    //Debug.Log("angle : " + angle);

                    // X軸（ピッチ）回転のトルクを加える
                    rb.AddTorque(new Vector3(flipDir.z, 0, -flipDir.x) * torqueForce);
                }
                flipCount++;
            }
            


            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    //rb.AddForce(Vector3.forward * mag, ForceMode.Impulse);
            //    rb.AddForce(transform.forward * mag, ForceMode.Impulse);
            //}


            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    //rb.AddForce(Vector3.left * mag, ForceMode.Impulse);
            //    rb.AddForce(-transform.right * mag, ForceMode.Impulse);
            //}


            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    //rb.AddForce(Vector3.back * mag, ForceMode.Impulse);
            //    rb.AddForce(-transform.forward * mag, ForceMode.Impulse);
            //}


            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    //rb.AddForce(Vector3.right * mag, ForceMode.Impulse);
            //    rb.AddForce(transform.right * mag, ForceMode.Impulse);
            //}


            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    rb.AddForce(Vector3.up * mag, ForceMode.Impulse);
            //}


            //if (Input.GetKeyDown(KeyCode.Z))
            //{
            //    rb.AddForce(Vector3.down * mag, ForceMode.Impulse);
            //}
        }

        //transform.position = rb.position;
    }

    public void SetFlipCount(int value)
    {
        flipCount = value;
    }

    public float GetmoveableScreenHeight()
    {
        return moveableScreenHeight;
    }
}
