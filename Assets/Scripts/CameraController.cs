using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Imagawayaki;
    private Vector3 ImagawaPos;

    // Start is called before the first frame update
    void Start()
    {
        //Imagawayaki = GameObject.Find("Dice");
        Imagawayaki = GameObject.Find("Imagawayaki");
        ImagawaPos = Imagawayaki.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += Imagawayaki.transform.position - ImagawaPos;
        ImagawaPos = Imagawayaki.transform.position;

        // �}�E�X�̉E�N���b�N�������Ă����
        if (Input.GetMouseButton(1))
        {
            // �}�E�X�̈ړ���
            float mouseInputX = Input.GetAxis("Mouse X");
            // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
            transform.RotateAround(ImagawaPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);

        }
    }
}
