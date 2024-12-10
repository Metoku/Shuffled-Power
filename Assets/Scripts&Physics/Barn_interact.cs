using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn_interact : MonoBehaviour
{
    [SerializeField] public GameObject barnInteractUI;
    [SerializeField] public GameObject barnBoxUI;

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            barnInteractUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            barnInteractUI.SetActive(false);
        }
    }
    IEnumerator btnCoroutine()
    {
        yield return new WaitForSeconds((float)0.1);
        barnBoxUI.SetActive(true);
        yield return new WaitForSeconds((float)1.5);
        barnBoxUI.SetActive(false);
    }

    public void barnInteractBTN()
    {
        Debug.Log("btn_pressed");
        StartCoroutine(btnCoroutine());
    }
}
