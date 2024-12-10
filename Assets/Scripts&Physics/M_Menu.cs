using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class M_Menu : MonoBehaviour
{
    public LoadController loadController;

    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameBtn;
    [SerializeField] private Button continueGameBtn;
    [SerializeField] private Button loadGameBtn;

    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameBtn.interactable = false;
            loadGameBtn.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        /*DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        loadController.LoadLevel(7);*/
        saveSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();
    }

    public void OnLoadGameClicked()
    {
        /*DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        loadController.LoadLevel(7);*/
        saveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
    }
    public void OnPracticeClicked()
    {
        loadController.LoadLevel(17);
    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(DataPersistenceManager.instance.GetSavedSceneNumber());
    }
    private void DisableMenuButtons()
    {
        newGameBtn.interactable = false;
        continueGameBtn.interactable = false;
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Debug.Log("App_Quit");
        Application.Quit();
    }
}


