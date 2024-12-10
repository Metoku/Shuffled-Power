using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro_to_game : MonoBehaviour
{
    public LoadController loadController;
    //[SerializeField] public GameObject btnui;
    // Start is called before the first frame update

    private float startWait = 25f;

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

    public void btnSkip()
    {
        loadController.LoadLevel(1);
    }
}
