using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
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
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += Imagawayaki.transform.position - ImagawaPos;
        ImagawaPos = Imagawayaki.transform.position;

    }
}
