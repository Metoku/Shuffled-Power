using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteract : MonoBehaviour
{
    [SerializeField] public GameObject interactUI;
    [SerializeField] public GameObject boxUI;

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            interactUI.SetActive(false);
        }
    }
    IEnumerator btnCoroutine()
    {
        yield return new WaitForSeconds((float)0.1);
        boxUI.SetActive(true);
        yield return new WaitForSeconds((float)1.5);
        boxUI.SetActive(false);
    }

    public void objInteractBTN()
    {
        Debug.Log("btn_pressed");
        StartCoroutine(btnCoroutine());
    }
}
