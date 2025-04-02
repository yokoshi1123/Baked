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

        // targetの移動量分、自分（カメラ）も移動する
        transform.position += Imagawayaki.transform.position - ImagawaPos;
        ImagawaPos = Imagawayaki.transform.position;

        canMove = playerController.GetCanMove();

        // マウスの右クリックを押している間
        if (Input.GetMouseButton(0) && touchPos.y >= Screen.height * playerController.GetmoveableScreenHeight() && canMove)
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(ImagawaPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);

        }
    }
}
