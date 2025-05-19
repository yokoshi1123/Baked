using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float movableScreenHeight = 0.7f;
    //private bool MouseButtonDown = false;
    private Vector3 touchPos = Vector3.zero;

    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;

    private Vector3 flipDir = Vector3.zero;

    private float cameraDepth = 0.45f;

    //[SerializeField] private float mag = 10f;

    private float torqueForce = 720f;

    [SerializeField] private int flipCount = 0;

    
    private bool buttonDown = false;//マウスが押されているか確認用

    private Vector3 mainCameraRot;

    [SerializeField] private bool canMove = true;

    //private List<Touch> touches;
    private Touch touch;

    private float magnitude;

    private TextMeshProUGUI debugMsg;

    // Start is called before the first frame update
    void Start()
    {
        rb = /*transform.GetChild(0).*/GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.05f, 0);
        touch.phase = TouchPhase.Canceled;

        debugMsg = GameObject.Find("DebugMsg").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Application.isEditor && flipCount < 2)
            {
                touchPos = Input.mousePosition;
                if (Input.GetMouseButtonDown(0) && touchPos.y < Screen.height * movableScreenHeight)
                {
                    //Debug.Log("From " + Input.mousePosition);
                    startPos = Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0) * Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, cameraDepth)) - transform.position;
                    Time.timeScale = 0.2f;
                    buttonDown = true;
                }

                if (buttonDown && (Input.GetMouseButtonUp(0) || touchPos.y >= Screen.height * movableScreenHeight))
                {
                    //Debug.Log("To " + Input.mousePosition);
                    buttonDown = false;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    //rb.angularVelocity = Vector3.zero;
                    endPos = Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0) * Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, cameraDepth)) - transform.position;
                    //Debug.Log("End: " + Input.mousePosition);
                    //Debug.Log("From " + startPos + " to " + endPos);

                    flipDir = (endPos - startPos) * 5;
                    //Debug.Log("1:" + flipDir);
                    //flipDir = Quaternion.Euler(20f, 0, 0) * flipDir;
                    //flipDir = Quaternion.Inverse(transform.rotation) * flipDir;
                    flipDir.z = flipDir.y;
                    flipDir.y = 0;
                    flipDir = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * flipDir;
                    //Debug.Log(Camera.main.transform.rotation.eulerAngles.y);
                    Debug.Log("flipDir: " + flipDir + ", magnitude: " + flipDir.magnitude);
                    magnitude = 1f / (1 + Mathf.Exp(-0.8f * (flipDir.magnitude - 5)));
                    Time.timeScale = 1f;
                    //rb.isKinematic = false;
                    rb.AddForce(flipDir * magnitude, ForceMode.Impulse);
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

            }
            else if (flipCount < 2)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).position.y < Screen.height * movableScreenHeight || Input.GetTouch(i).fingerId == touch.fingerId)
                    {
                        touch = Input.GetTouch(i);
                        touchPos = touch.position;
                        debugMsg.text = i.ToString() + " : " + touch.phase.ToString();
                        break;
                    }
                }

                if (touch.phase == TouchPhase.Began)
                {
                    startPos = Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0) * Camera.main.ScreenToWorldPoint(new(touchPos.x, touchPos.y, cameraDepth)) - transform.position;
                    Time.timeScale = 0.2f;
                    buttonDown = true;
                }
                else if (buttonDown && touch.phase == TouchPhase.Ended)
                {
                    buttonDown = false;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    endPos = Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0) * Camera.main.ScreenToWorldPoint(new(touchPos.x, touchPos.y, cameraDepth)) - transform.position;
                    flipDir = (endPos - startPos) * 5;
                    flipDir.z = flipDir.y;
                    flipDir.y = 0;
                    flipDir = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * flipDir;
                    Debug.Log("flipDir: " + flipDir + ", magnitude: " + flipDir.magnitude);
                    magnitude = 1f / (1 + Mathf.Exp(-0.8f * (flipDir.magnitude - 5)));
                    Time.timeScale = 1f;
                    rb.AddForce(flipDir * magnitude, ForceMode.Impulse);
                    rb.AddForce(flipDir, ForceMode.Impulse);
                    rb.AddForce(Vector3.up * Mathf.Min(Mathf.Sqrt(flipDir.magnitude) * 4f, 16f), ForceMode.Impulse);

                    if (flipDir.magnitude > 0.01f)
                    {
                        // X軸（ピッチ）回転のトルクを加える
                        rb.AddTorque(new Vector3(flipDir.z, 0, -flipDir.x) * torqueForce);
                    }
                    flipCount++;
                }

                ////if (touch.phase != TouchPhase.Ended)// touches.Count > 0)
                ////{
                ////Touch touch = touches[0];

                //bool isRemain = false;
                //for (int i = 0; i < Input.touchCount; i++)
                //{
                //    if (Input.GetTouch(i).fingerId == touch.fingerId)
                //    {
                //        touch = Input.GetTouch(i);
                //        debugMsg.text = touch.phase.ToString();
                //        isRemain = true;
                //        break;
                //    }
                //}
                //if (!isRemain)
                //{
                //    touch.phase = TouchPhase.Ended;
                //    debugMsg.text = touch.phase.ToString();
                //}

                ////try
                ////{
                ////    touch = Input.GetTouch(touch.fingerId);
                ////    debugMsg.text = touch.phase.ToString();
                ////}
                ////catch
                ////{
                ////    touch.phase = TouchPhase.Canceled;
                ////}
                //touchPos = touch.position;
                //if (touch.phase == TouchPhase.Began)
                //{
                //    startPos = Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0) * Camera.main.ScreenToWorldPoint(new(touchPos.x, touchPos.y, cameraDepth)) - transform.position;
                //    Time.timeScale = 0.2f;
                //    buttonDown = true;
                //}
                //if (buttonDown && touch.phase == TouchPhase.Ended)
                //{
                //    buttonDown = false;
                //    rb.velocity = Vector3.zero;
                //    rb.angularVelocity = Vector3.zero;
                //    endPos = Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0) * Camera.main.ScreenToWorldPoint(new(touchPos.x, touchPos.y, cameraDepth)) - transform.position;
                //    flipDir = (endPos - startPos) * 5;
                //    flipDir.z = flipDir.y;
                //    flipDir.y = 0;
                //    flipDir = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * flipDir;
                //    magnitude = 1f / (1 + Mathf.Exp(-0.8f * (flipDir.magnitude - 5)));
                //    Time.timeScale = 1f;
                //    //rb.isKinematic = false;
                //    rb.AddForce(flipDir * magnitude, ForceMode.Impulse);
                //    rb.AddForce(Vector3.up * Mathf.Min(Mathf.Sqrt(flipDir.magnitude) * 4f, 16f), ForceMode.Impulse);

                //    if (flipDir.magnitude > 0.01f)
                //    {
                //        // X軸（ピッチ）回転のトルクを加える
                //        rb.AddTorque(new Vector3(flipDir.z, 0, -flipDir.x) * torqueForce);
                //    }
                //    flipCount++;
                //touches.Remove(touch);
                //touch = null;
                //}
                //}
            }
        }
        //else
        //{
        //    Debug.Log("Unavailable");
        //}

        //transform.position = rb.position;
    }

    public void SetFlipCount(int value)
    {
        flipCount = value;
    }

    public float GetmovableScreenHeight()
    {
        return movableScreenHeight;
    }
    public bool GetCanMove()
    {
        return canMove;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void SwitchCanMove()
    {
        canMove = !canMove;
    }

    //public Touch GetTouch()
    //{
    //    return touch;
    //}

    //public void SetTouch(Touch value)
    //{
    //    touch = value;
    //}

    public int GetFingerId()
    {
        return touch.fingerId;
    }

    //public void AddTouches(Touch touch)
    //{
    //    touches.Add(touch);
    //}

    //public void RemoveTouches(Touch touch)
    //{
    //    touches.Remove(touch);
    //}
}
