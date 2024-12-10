using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform player;
    GameObject target;
    //[SerializeField] public GameObject nPCBox;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist <= 8.5)
        {
            transform.LookAt(player);
        }
    }

    
}
