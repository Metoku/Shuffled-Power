using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSwitcher : MonoBehaviour
{
    Cinemachine.CinemachineDollyCart cart;

    public Cinemachine.CinemachineSmoothPath startPath;
    public Cinemachine.CinemachineSmoothPath[] alternatePaths;

    private void Awake()
    {
        cart = GetComponent<Cinemachine.CinemachineDollyCart>();

        ResetCamera();
    }

    public void ResetCamera()
    {
        StopAllCoroutines();

        cart.m_Path = startPath;

        StartCoroutine(ChangeTrack());
    }

    IEnumerator ChangeTrack()
    {
        
        yield return new WaitForSeconds(Random.Range(5, 10));
        

        var path = alternatePaths[Random.Range(0, alternatePaths.Length)];
        cart.m_Path = path;
        cart.m_Position = 0;

        StartCoroutine(ChangeTrack());
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
