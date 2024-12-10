using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene1_to_village : MonoBehaviour
{
    // Start is called before the first frame update
    public LoadController loadController;
    private float startWait = 9f;

    void Start()
    {
        //btnui.SetActive(false);
        Invoke("btnStart", startWait);
    }

    // Update is called once per frame

    public void btnStart()
    {
        loadController.LoadLevel(1);
    }
    IEnumerator btn()
    {
        yield return new WaitForSeconds(2);
        //btnui.SetActive(true);
    }
}
