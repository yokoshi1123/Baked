using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    public bool DontDestroyEnabled = true;

    //private AudioSource audioSource;
    //[SerializeField] private SoundVolumeManager soundVolumeManager;

    // Use this for initialization
    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Scene��J�ڂ��Ă��I�u�W�F�N�g�������Ȃ��悤�ɂ���
            DontDestroyOnLoad(this);
        }

        //try
        //{
        //    soundVolumeManager = GameObject.Find("SoundVolumeManager").GetComponent<SoundVolumeManager>();
        //    audioSource = GetComponent<AudioSource>();
        //}
        //catch
        //{ }
    }

    //void Update()
    //{
    //    if (soundVolumeManager != null)
    //    {
    //        audioSource.volume = soundVolumeManager.GetBGMVolume() * 0.01f;
    //    }
    //}
}
