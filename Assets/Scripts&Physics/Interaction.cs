using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;
    [SerializeField] private Interaction_PromptUI InteractionPromptUI;

    public void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            interacting = colliders[0].GetComponent<IInteractable>();
            if (!InteractionPromptUI.IsDisplayed) InteractionPromptUI.SetUp(interacting.InteractionPrompt);
        }
        else
        {
            if (interacting != null) interacting = null;
            if (InteractionPromptUI.IsDisplayed) InteractionPromptUI.Close();
        }
    }

    private IInteractable interacting;

    public void InteractBTN()
    {
        
        if (numFound > 0)
        {
            interacting = colliders[0].GetComponent<IInteractable>();

            if (interacting != null)
            {
                interacting.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
