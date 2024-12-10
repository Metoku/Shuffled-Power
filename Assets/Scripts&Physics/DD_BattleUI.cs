using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_BattleUI : MonoBehaviour
{
    [SerializeField] public GameObject attackUi;
    [SerializeField] public GameObject attackPrompt;
    public LoadController loadController;
    public DataPersistenceManager dataPersistenceManager;
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            attackUi.SetActive(true);
            attackPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Pointer")
        {
            attackUi.SetActive(false);
            attackPrompt.SetActive(false);
        }
    }

    public void attackM1()
    {
        //SceneManager.LoadScene("village_test_M1");
        //SavingSystem.i.Save("saveSlot1");
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(19);

    }
    public void attackM2()
    {
        //SceneManager.LoadScene("village_test_M2");
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(20);

    }
    public void attackM3()
    {
        //SceneManager.LoadScene("village_test_M3");
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(21);
    }
    public void attackMB()
    {
        //SceneManager.LoadScene("village_test_MB");
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(22);
    }
    public void attackMBB()
    {
        //SceneManager.LoadScene("village_test_MBB");
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(23);
    }
}
