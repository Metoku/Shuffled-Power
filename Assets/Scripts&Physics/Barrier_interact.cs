using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_interact : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject barrierinteractUI;
    

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            barrierinteractUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            barrierinteractUI.SetActive(false);
        }
    }
    IEnumerator btnCoroutine()
    {
        yield return new WaitForSeconds((float)0.1);
        barrierinteractUI.SetActive(true);
        yield return new WaitForSeconds((float)1.5);
        barrierinteractUI.SetActive(false);
    }

    public void objInteractBTN()
    {
        Debug.Log("btn_pressed");
        StartCoroutine(btnCoroutine());
    }
}
