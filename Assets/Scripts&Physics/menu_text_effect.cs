using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menu_text_effect : MonoBehaviour
{
    public float minTime = 0.05f;
    public float maxTime = 1.0f;

    private float timer;
    public TextMeshProUGUI textFlicker;

    private void Start()
    {
        textFlicker = GetComponent<TextMeshProUGUI>();
        timer = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            textFlicker.enabled = !textFlicker.enabled;
            timer = Random.Range(minTime, maxTime);
        }
    }
}
