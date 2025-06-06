using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class SliderStepWidth : MonoBehaviour
{
    [SerializeField]
    private float stepWidth = 0.1f;
    [SerializeField]
    private float defaultRatio = 1f;
    // Start is called before the first frame update

    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Round(slider.value / (stepWidth * defaultRatio)) * stepWidth * defaultRatio;
    }

    public float GetDefaultRatio()
    {
        return defaultRatio;
    }
}
