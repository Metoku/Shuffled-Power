using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_to_menu : MonoBehaviour
{
    public LoadController loadController;
    private float startWait = 180f;

    void Start()
    {
        //btnui.SetActive(false);
        Invoke("btnMenu", startWait);
    }
    public void btnMenu()
    {
        loadController.LoadLevel(0);
    }
    public void btnQuit()
    {
        Application.Quit();
    }
    
}
