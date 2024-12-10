using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene2_to_DK : MonoBehaviour
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
        loadController.LoadLevel(9);
    }
    IEnumerator btn()
    {
        yield return new WaitForSeconds(2);
        //btnui.SetActive(true);
    }
}
