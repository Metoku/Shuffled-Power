using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interact_GO : MonoBehaviour, IInteractable
{
    [SerializeField] private string promt;
    public string InteractionPrompt => promt;

   
    public bool Interact(Interaction interactor)
    {
        Debug.Log("Interact");
        return true;
    }
}
