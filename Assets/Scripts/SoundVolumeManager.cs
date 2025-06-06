using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SoundVolumeManager : MonoBehaviour
{
    [SerializeField]
    private int bgmVolume;
    [SerializeField] 
    private int seVolume;

    private Slider BGMVolumeSlider;
    private Slider SEVolumeSlider;

    private TextMeshProUGUI BGMValue;
    private TextMeshProUGUI SEValue;

    private AudioSource bgmManager;

    // Start is called before the first frame update
    void Start()
    {
        bgmVolume = PlayerPrefs.GetInt("BGMVolumeSlider", 100);
        seVolume = PlayerPrefs.GetInt("SEVolumeSlider", 100);
        try 
        {
            bgmManager = GameObject.Find("BGMManager").GetComponent<AudioSource>();

            BGMVolumeSlider = GameObject.Find("BGMVolume").GetComponent<Slider>();
            SEVolumeSlider = GameObject.Find("SEVolume").GetComponent<Slider>();

            BGMVolumeSlider.value = bgmVolume * 0.01f;
            SEVolumeSlider.value = seVolume * 0.01f;

            BGMValue = BGMVolumeSlider.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
            SEValue = SEVolumeSlider.transform.GetChild(4).GetComponent<TextMeshProUGUI>();

            BGMValue.text = bgmVolume.ToString();
            SEValue.text = seVolume.ToString();
        }
        catch
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BGMVolumeSlider != null && SEVolumeSlider != null)
        {
            bgmVolume = PlayerPrefs.GetInt("BGMVolumeSlider", 100);
            seVolume = PlayerPrefs.GetInt("SEVolumeSlider", 100);

            BGMValue.text = bgmVolume.ToString();
            SEValue.text = seVolume.ToString();
        }
        if (bgmManager != null)
        {
            bgmManager.volume = bgmVolume * 0.01f;
        }
    }

    //public void SetBGMVolumeSlider()
    //{
    //    PlayerPrefs.SetInt("BGMVolumeSlider", (int)(BGMVolumeSlider.value * 100));
    //}
    //public void SetSEVolumeSlider()
    //{
    //    PlayerPrefs.SetInt("SEVolumeSlider", (int)(SEVolumeSlider.value * 100));
    //}

    public int GetBGMVolume()
    {
        return bgmVolume;
    }

    public int GetSEVolume()
    {
        return seVolume;
    }
    public void SetBGMVolumeSlider()
    {
        PlayerPrefs.SetInt("BGMVolumeSlider", (int)(BGMVolumeSlider.value * 100));
    }
    public void SetSEVolumeSlider()
    {
        PlayerPrefs.SetInt("SEVolumeSlider", (int)(SEVolumeSlider.value * 100));
    }
}
