using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggingEquation : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    bool inUse;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
       Debug.Log("OnDrag");
       rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       Debug.Log("OnEndDrag");
       canvasGroup.alpha = 1f;
       canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot"))
        {
        
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot"))
        {
            
        }
    }

   

}
