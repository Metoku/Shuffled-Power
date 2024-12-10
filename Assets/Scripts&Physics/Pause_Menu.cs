using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    [SerializeField] private  DataPersistenceManager dataPersistenceManager;
    // Start is called before the first frame update

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Menu");
        
    }

    public void SaveBtn()
    {
        DataPersistenceManager.instance.SaveGame();
        Debug.Log("saved");

    }

    public void OnLoadGameClicked()
    {
        
        saveSlotsMenu.ActivateMenu(true);
        
    }



}
