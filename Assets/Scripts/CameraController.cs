using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Imagawayaki;
    private Vector3 ImagawaPos;
    private PlayerController playerController;
    private Vector3 touchPos = Vector3.zero;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        //Imagawayaki = GameObject.Find("Dice");
        Imagawayaki = GameObject.Find("Imagawayaki");
        ImagawaPos = Imagawayaki.transform.position;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        touchPos = Input.mousePosition;

        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += Imagawayaki.transform.position - ImagawaPos;
        ImagawaPos = Imagawayaki.transform.position;

        canMove = playerController.GetCanMove();

        // �}�E�X�̉E�N���b�N�������Ă����
        if (Input.GetMouseButton(0) && touchPos.y >= Screen.height * playerController.GetmoveableScreenHeight() && canMove)
        {
            // �}�E�X�̈ړ���
            float mouseInputX = Input.GetAxis("Mouse X");
            // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
            transform.RotateAround(ImagawaPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);

        }
    }
}
