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
            // Sceneを遷移してもオブジェクトが消えないようにする
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
