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
    private float angle;

    //private TextMeshProUGUI debugMsg;

    // Start is called before the first frame update

    private float DEFAULT_SCREEN_HEIGHT = 1778;

    private float MAX_MAGNITUDE = 6f;

    void Start()
    {
        rb = /*transform.GetChild(0).*/GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.05f, 0);
        touch.phase = TouchPhase.Canceled;

        //debugMsg = GameObject.Find("DebugMsg").GetComponent<TextMeshProUGUI>();
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
                    //startPos = /*Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0)*/ Quaternion.Inverse(Camera.main.transform.rotation) * Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, cameraDepth)) - transform.position;
                    startPos = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * new Vector3(Input.mousePosition.x / Screen.width, 0, Input.mousePosition.y / Screen.height); // - transform.position;
                    //Time.timeScale = 0.2f;
                    //rb.isKinematic = true;
                    buttonDown = true;
                }

                if (buttonDown && (Input.GetMouseButtonUp(0))) // || touchPos.y >= Screen.height * movableScreenHeight))
                {
                    //Debug.Log("To " + Input.mousePosition);
                    buttonDown = false;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    //rb.angularVelocity = Vector3.zero;
                    //endPos = /*Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0)*/ Quaternion.Inverse(Camera.main.transform.rotation) * Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, cameraDepth)) - transform.position;
                    endPos = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * new Vector3(Input.mousePosition.x / Screen.width, 0, Input.mousePosition.y / Screen.height);
                    //Debug.Log("End: " + Input.mousePosition);
                    //Debug.Log("From " + startPos + " to " + endPos);

                    flipDir = (endPos - startPos) * MAX_MAGNITUDE; // * (DEFAULT_SCREEN_HEIGHT/Screen.height);
                    //Debug.Log("1:" + flipDir);
                    //flipDir = Quaternion.Euler(20f, 0, 0) * flipDir;
                    //flipDir = Quaternion.Inverse(transform.rotation) * flipDir;
                    //flipDir.z = flipDir.y;
                    //flipDir.y = 0;
                    //flipDir = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * flipDir;
                    //magnitude = 1.2f * (0.2f * flipDir.magnitude + 5f / (1f + Mathf.Exp(-1.5f * (flipDir.magnitude - 3f)))) * Mathf.Sqrt(flipDir.magnitude);
                    magnitude = 0.1f + 0.6f / (1 + Mathf.Exp(-0.8f * (flipDir.magnitude - 5f)));
                    angle = Mathf.PI * Mathf.Min(32f, 5f * flipDir.magnitude + 12f) / 96f;
                    //Debug.Log("Camera" + Camera.main.transform.rotation.eulerAngles.y);
                    //Debug.Log(startPos + " to " + endPos + ", \nflipDir: " + flipDir + ", magnitude: " + magnitude + ", angle: " + (DEFAULT_SCREEN_HEIGHT / Screen.height));
                    //Time.timeScale = 1f;
                    //rb.isKinematic = true;
                    //rb.isKinematic = false;
                    //rb.AddForce(magnitude * Mathf.Cos(angle) * flipDir.normalized, ForceMode.Impulse);
                    //rb.AddForce(magnitude * Mathf.Sin(angle) * Vector3.up, ForceMode.Impulse);
                    rb.AddForce(flipDir * magnitude * (1 + Mathf.Sin(angle)), ForceMode.Impulse);
                    rb.AddForce(Vector3.up * Mathf.Min(Mathf.Sqrt(flipDir.magnitude) * 3f, 16f) * Mathf.Sin(angle), ForceMode.Impulse);

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
                        //debugMsg.text = i.ToString() + " : " + touch.phase.ToString();
                        break;
                    }
                }

                if (!buttonDown && touch.phase == TouchPhase.Began)
                {
                    //startPos = /*Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0)*/ Quaternion.Inverse(Camera.main.transform.rotation) * Camera.main.ScreenToWorldPoint(new(touchPos.x, touchPos.y, cameraDepth)) - transform.position;
                    startPos = /*Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * */new Vector3(touchPos.x / Screen.width, 0, touchPos.y / Screen.height); // - transform.position;
                    //Time.timeScale = 0.2f;
                    //rb.isKinematic = true;
                    buttonDown = true;
                }
                else if (buttonDown && touch.phase == TouchPhase.Ended)
                {
                    buttonDown = false;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    //endPos = /*Quaternion.Euler(0, -Camera.main.transform.rotation.eulerAngles.y, 0)*/ Quaternion.Inverse(Camera.main.transform.rotation) * Camera.main.ScreenToWorldPoint(new(touchPos.x, touchPos.y, cameraDepth)) - transform.position;
                    endPos = /*Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) **/ new Vector3(touchPos.x / Screen.width, 0, touchPos.y / Screen.height); // - transform.position;
                    flipDir = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * (endPos - startPos) * MAX_MAGNITUDE; // * (DEFAULT_SCREEN_HEIGHT / Screen.height);
                    //flipDir.z = flipDir.y;
                    //flipDir.y = 0;
                    //flipDir = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * flipDir;
                    //magnitude = 1.2f * (0.2f * flipDir.magnitude + 5f / (1f + Mathf.Exp(-1.5f * (flipDir.magnitude - 3f)))) * Mathf.Sqrt(flipDir.magnitude);
                    magnitude = 0.2f + 0.8f / (1 + Mathf.Exp(-0.8f * (flipDir.magnitude - 5f)));
                    angle = Mathf.PI * Mathf.Min(32f, 5f * flipDir.magnitude + 12f) / 96f;
                    //Debug.Log("Camera" + Camera.main.transform.rotation.eulerAngles.y);
                    //Debug.Log(startPos + " to " + endPos + ", \nflipDir: " + flipDir + ", magnitude: " + magnitude + ", angle: " + (DEFAULT_SCREEN_HEIGHT / Screen.height));
                    //Time.timeScale = 1f;
                    rb.isKinematic = false;
                    //rb.isKinematic = false;
                    //rb.AddForce(magnitude * Mathf.Cos(angle) * flipDir.normalized, ForceMode.Impulse);
                    //rb.AddForce(magnitude * Mathf.Sin(angle) * Vector3.up, ForceMode.Impulse);
                    //magnitude = 0.05f + 0.3f / (1 + Mathf.Exp(-0.8f * (flipDir.magnitude - 5f)));
                    //Time.timeScale = 1f;
                    rb.AddForce(flipDir * magnitude * (1 + Mathf.Cos(angle)), ForceMode.Impulse);
                    rb.AddForce(Vector3.up * Mathf.Min(Mathf.Sqrt(flipDir.magnitude) * 3f, 16f), ForceMode.Impulse);

                    if (flipDir.magnitude > 0.01f)
                    {
                        // X軸（ピッチ）回転のトルクを加える
                        rb.AddTorque(new Vector3(flipDir.z, 0, -flipDir.x) * torqueForce);
                    }
                    flipCount++;
                }
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

    public bool IsFinger4Camera(float posY, int id)
    {
        return (posY > Screen.height * movableScreenHeight && id != touch.fingerId);
    }
}
