using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicator_off : MonoBehaviour
{

    private GameObject player;
    public GameObject indicator;
    //[SerializeField] public GameObject nPCBox;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist <= 15.05)
        {
            indicator.SetActive(false);
        }
        else
        {
            indicator.SetActive(true);
        }
    }
}
