using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquationSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject[] slot;
    string equation1;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var c in slot)
        {
            if (c.name.Equals(other.gameObject.name))
            {
                //do something
                equation1 = c.GetComponent<TMPro.TextMeshProUGUI>().text;

            }
        }
        Debug.Log(equation1);
        Debug.Log("detection");


    }
}
