using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ShuffleEquation : MonoBehaviour
{
   
   
  // public List<Transform> equationSpawns = new List<Transform>();
    [SerializeField] private RectTransform[] equationPrefabs;
    [SerializeField] private RectTransform[] spawnLocations;
    [SerializeField] private List<int> retrieveList = new List<int>();

    private int randomNumber;
   
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations.Shuffle(5);
        retrieveList = new List<int>(new int[spawnLocations.Length]);

        for(int i = 0; i< spawnLocations.Length; i++)
        {
            randomNumber = UnityEngine.Random.Range(1, (equationPrefabs.Length) + 1);
                while(retrieveList.Contains(randomNumber))
                {
                randomNumber = UnityEngine.Random.Range(1, (equationPrefabs.Length) + 1);
                }
            retrieveList[i] = randomNumber;
            equationPrefabs[(retrieveList[i] - 1)].anchorMin = spawnLocations[(retrieveList[i] - 1)].anchorMin;
            equationPrefabs[(retrieveList[i] - 1)].anchorMax = spawnLocations[(retrieveList[i] - 1)].anchorMax;
            equationPrefabs[(retrieveList[i] - 1)].localPosition = spawnLocations[(retrieveList[i] - 1)].localPosition;
            equationPrefabs[(retrieveList[i] - 1)].anchoredPosition = spawnLocations[(retrieveList[i] - 1)].anchoredPosition;
      
      



        }

        
    }

   
    }


