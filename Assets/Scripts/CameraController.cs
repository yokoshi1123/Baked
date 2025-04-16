using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private PlayerController playerController;
    private Vector3 touchPos = Vector3.zero;

    private bool canMove;

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
    }

    // Update is called once per frame
    void Update()
    {
        touchPos = Input.mousePosition;

        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += player.transform.position - playerPos;
        playerPos = player.transform.position;

        canMove = playerController.GetCanMove();

        // �}�E�X�̉E�N���b�N�������Ă����
        if (Input.GetMouseButton(0) && touchPos.y >= Screen.height * playerController.GetmoveableScreenHeight() && canMove)
        {
            // �}�E�X�̈ړ���
            float mouseInputX = Input.GetAxis("Mouse X");
            // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
            transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);

        }
    }
}
