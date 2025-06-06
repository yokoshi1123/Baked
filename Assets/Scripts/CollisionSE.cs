using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]


public class CollisionSE : MonoBehaviour
{
    [Header("���n")][SerializeField] private AudioClip landSE;
    [Header("�R�C��")][SerializeField] private AudioClip getCoinSE;
    [Header("�`�F�b�N�|�C���g")][SerializeField] private AudioClip checkPointSE;
    private SoundVolumeManager soundVolumeManager;
    private float seVolume;

    // Start is called before the first frame update
    void Start()
    {
        soundVolumeManager = GameObject.Find("SoundVolumeManager").GetComponent<SoundVolumeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        seVolume = (float)(soundVolumeManager.GetSEVolume()) / 100.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("���nSE");

        if (other.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().PlayOneShot(getCoinSE, seVolume);
        }
        else if (other.CompareTag("Respawn"))
        {
            GetComponent<AudioSource>().PlayOneShot(checkPointSE, seVolume);
        }
        else if (!other.CompareTag("Abyss"))
        {
            GetComponent<AudioSource>().PlayOneShot(landSE, seVolume);
        }
    }
}
