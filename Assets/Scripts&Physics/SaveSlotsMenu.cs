using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    public LoadController loadController;
    [Header("Menu Navigation")]
    [SerializeField] private M_Menu menu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;


    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private void Awake()
    {

        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void onSaveSlotClicked(SaveSlot saveSlot)
    {
        //disable buttons
        DisableMenuButtons();

        //update the selected profile id
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        if(!isLoadingGame)
        {
            DataPersistenceManager.instance.NewGame();
            loadController.LoadLevel(18);
        }
        else
        {
            loadController.LoadLevel(DataPersistenceManager.instance.GetSavedSceneNumber());
            DataPersistenceManager.instance.LoadGame();
        }

        // save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        //SceneManager.LoadSceneAsync();
        //load scene
        //loadController.LoadLevel(16); DataPersistenceManager.instance.GetSavedSceneName()
        
        
    }

     public void OnBackClicked()
    {
        //menu.ActivateMenu();
        this.DeactivateMenu();
    }    

   

    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        // load profiles that exist
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();


        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {

                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
            }
        }
        



    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }

}
