using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolveShuffledEquation : MonoBehaviour
{
    [SerializeField] private GameObject[] slot;
    [SerializeField] private  GameObject[] equation;
    private GameObject[] slots;
    private int[] playerEquation;
    string equation1;
    
    void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");
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
