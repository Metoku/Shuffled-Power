using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Interact : MonoBehaviour
{
    [SerializeField] public GameObject houseInteractUI;
    [SerializeField] public GameObject houseBoxUI;

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            houseInteractUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            houseInteractUI.SetActive(false);
        }
    }
    IEnumerator btnCoroutine()
    {
        yield return new WaitForSeconds((float)0.1);
        houseBoxUI.SetActive(true);
        yield return new WaitForSeconds((float)1.5);
        houseBoxUI.SetActive(false);
    }

    public void houseInteractBTN()
    {
        Debug.Log("btn_pressed");
        StartCoroutine(btnCoroutine());
    }
}
