using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private PlayerController playerController;
    private Vector3 touchPos = Vector3.zero;

    [SerializeField] private bool canMove = true;

    [SerializeField] private float rotateSpeed = 10f;

    //private List<Touch> touches;
    [SerializeField] private float movableScreenHeight = 0.7f;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Dice");
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        playerController = player.GetComponent<PlayerController>();

        //�J�����̏����ʒu
        transform.position = playerPos + new Vector3(0, 0.537f, -0.771f);
        transform.localEulerAngles = player.transform.localEulerAngles + new Vector3(20,0,0);
        touch.phase = TouchPhase.Canceled;
    }

    // Update is called once per frame
    void Update()
    {
        canMove = playerController.GetCanMove();

        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += player.transform.position - playerPos;
        playerPos = player.transform.position;

        if (canMove)
        {
            // �}�E�X�̉E�N���b�N�������Ă����
            if (Application.isEditor)
            {
                touchPos = Input.mousePosition;
                if (Input.GetMouseButton(0) && (touchPos.y >= Screen.height * playerController.GetmovableScreenHeight()))
                {
                    // �}�E�X�̈ړ���
                    float mouseInputX = Input.GetAxis("Mouse X");
                    // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
                    transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);

                }
            }
            else
            {
                //try
                //{
                //    touch = Input.GetTouch(touch.fingerId);
                //}
                //catch
                //{
                //    touch.phase = TouchPhase.Canceled;
                //}
                //Touch touch = touches[0];
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).position.y > Screen.height * movableScreenHeight || Input.GetTouch(i).fingerId != playerController.GetFingerId())
                    {
                        touch = Input.GetTouch(i);
                        touchPos = touch.position;
                        break;
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
                    transform.RotateAround(playerPos, Vector3.up, touch.deltaPosition.x * Time.deltaTime * rotateSpeed);
                }
            }
        }       
        
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

    //public void AddTouches(Touch touch)
    //{
    //    touches.Add(touch);
    //}

    //public void RemoveTouches(Touch touch)
    //{
    //    touches.Remove(touch);
    //}

    public Touch GetTouch()
    {
        return touch;
    }

    public void SetTouch(Touch value)
    {
        touch = value;
    }
}
