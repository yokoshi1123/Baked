using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CameraController cameraController;

    [SerializeField] private float movableScreenHeight = 0.7f;

    //private TextMeshProUGUI debugMsg;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();

        //debugMsg = GameObject.Find("DebugMsg").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            //cameraController.SetCanMove(playerController.GetCanMove());
            //debugMsg.text = "Editor";
        }
        else
        {
            //for (int i = 0; i < Input.touchCount; i++)
            //{
                //Touch touch = Input.GetTouch(i);
            //debugMsg.text = touch.fingerId.ToString();
            //bool isTouch4Move = touch.position.y < Screen.height * movableScreenHeight;
            //if (touch.phase == TouchPhase.Began && isTouch4Move && playerController.GetTouch().phase == TouchPhase.Canceled)
            //{
            //    playerController.SetTouch(touch);
            //    //debugMsg.text = "Move";
            //    //playerController.AddTouches(touch);
            //}
            //else if (touch.phase == TouchPhase.Began && !isTouch4Move && cameraController.GetTouch().phase == TouchPhase.Canceled)
            //{
            //    //cameraController.SetTouch(touch);
            //    //debugMsg.text = "Camera";
            //    //cameraController.AddTouches(touch);
            //}
            //else if (touch.phase == TouchPhase.Ended && isTouch4Move)
            //{
            //    playerController.RemoveTouches(touch);
            //}
            //else if (touch.phase == TouchPhase.Ended && !isTouch4Move)
            //{
            //    cameraController.RemoveTouches(touch);
            //}

            //}
        }
    }
}
