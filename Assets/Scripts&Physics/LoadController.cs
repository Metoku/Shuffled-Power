using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;

    void Start()
    {
        
        ProgressController.progressInstance.Progression1();
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadSceneAsynchronously(index));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex) ;
        
        while(!operation.isDone)
        {
            loadingSlider.value = operation.progress;
            yield return null;
        }
    }

}



