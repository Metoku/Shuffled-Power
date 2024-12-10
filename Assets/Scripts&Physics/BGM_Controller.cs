using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM_Controller : MonoBehaviour
{
    [SerializeField] private AudioMixer BGM;

    public void SetVolume(float sliderValue)
    {
        BGM.SetFloat("BGM_Vol",Mathf.Log10(sliderValue) * 20);
    }
}
