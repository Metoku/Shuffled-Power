using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public LoadController loadController;

    public void SaveGame()
    {
        
        SavingSystem.i.Save("saveSlot1");
    }

    public void LoadGame()
    {
        //loadController.LoadLevel(1);
        SavingSystem.i.Load("saveSlot1");
    }
}
