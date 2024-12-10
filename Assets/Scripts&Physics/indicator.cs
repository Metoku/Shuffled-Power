using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicator : MonoBehaviour
{
    public GameObject indicators;
    public GameObject target;

    Renderer rd;

    private void Start()
    {
        rd = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(rd.isVisible == false)
        {
            if(indicators.activeSelf == false)
            {
                indicators.SetActive(true);
            }
            Vector2 direction = target.transform.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);

            if(ray.collider != null)
            {
                indicators.transform.position = ray.point;
            }
        }
        else
        {
            if(indicators.activeSelf == true)
            {
                indicators.SetActive(false);
            }
        }
    }
}
