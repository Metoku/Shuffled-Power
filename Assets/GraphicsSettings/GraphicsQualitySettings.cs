using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;


public class GraphicsQualitySettings : MonoBehaviour
{
   
    public TMP_Dropdown dropdown;
    private int veryLowMemory = 1500;
    private int LowMemory = 2500;
    private int mediumMemory = 3500;
    private int highMemory = 4500;
    private int veryHighMemory = 6500;
    private int ultraMemory = 8500;

    void Start()
    {
        Debug.Log("RAM: " +SystemInfo.graphicsMemorySize);
        
        
        if (SystemInfo.graphicsMemorySize <= veryLowMemory & SystemInfo.graphicsMemorySize < ultraMemory)
        {
            QualitySettings.SetQualityLevel(0); // very low graphics
            Debug.Log("Very Low");
        }
        
        else if (SystemInfo.graphicsMemorySize <= LowMemory & SystemInfo.graphicsMemorySize > veryLowMemory)
        {
            QualitySettings.SetQualityLevel(1);
            Debug.Log("Low");
        }
        
        else if (SystemInfo.graphicsMemorySize <= mediumMemory & SystemInfo.graphicsMemorySize > LowMemory)
        {
            QualitySettings.SetQualityLevel(2);
            Debug.Log("Medium");
        }
        
        else if (SystemInfo.graphicsMemorySize <= highMemory & SystemInfo.graphicsMemorySize > mediumMemory)
        {
            QualitySettings.SetQualityLevel(3);
            Debug.Log("High");
        }
        
        else if (SystemInfo.graphicsMemorySize <= veryHighMemory & SystemInfo.graphicsMemorySize > highMemory)
        {
            QualitySettings.SetQualityLevel(4);
            Debug.Log("Very High");
        }
        
        else if (SystemInfo.graphicsMemorySize <= ultraMemory & SystemInfo.graphicsMemorySize > veryHighMemory)
        {
            QualitySettings.SetQualityLevel(5);
            Debug.Log("Ultra");
        }
        
        Debug.Log(SystemInfo.graphicsMemorySize);
        Debug.Log(SystemInfo.operatingSystem);
        dropdown.value = QualitySettings.GetQualityLevel();
        
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }



}
