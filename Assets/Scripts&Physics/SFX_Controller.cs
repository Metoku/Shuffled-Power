using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SFX_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioMixer SFX;

    public void SetVolume(float sliderValue)
    {
        SFX.SetFloat("BGM_Vol", Mathf.Log10(sliderValue) * 20);
    }
}
