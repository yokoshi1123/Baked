using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinsController coinsController;

    // Start is called before the first frame update
    void Start()
    {
        coinsController = transform.parent.gameObject.GetComponent<CoinsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            coinsController.GotCoinNumInc();
            this.gameObject.SetActive(false);
        }
    }
}
