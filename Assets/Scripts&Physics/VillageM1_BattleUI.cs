using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageM1_BattleUI : MonoBehaviour
{
    [SerializeField] public GameObject attackUi;
    [SerializeField] public GameObject attackPrompt;
    [SerializeField] public GameObject m1UI;
    [SerializeField] public GameObject m2UI;
    [SerializeField] public GameObject m3UI;
    [SerializeField] public GameObject m4UI;
    [SerializeField] public GameObject m5UI;
    [SerializeField] public GameObject m6UI;
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
        // dataPersistenceManager.SaveGame();
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(2);
        
    }
    public void attackM2()
    {
        //SceneManager.LoadScene("village_test_M2");
       // dataPersistenceManager.SaveGame();
       DataPersistenceManager.instance.SaveGame();
       loadController.LoadLevel(3);
        
    }
    public void attackM3()
    {
        //SceneManager.LoadScene("village_test_M3");
        //dataPersistenceManager.SaveGame();
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(4);
    }
    public void attackM4()
    {
        //SceneManager.LoadScene("village_test_M3");
        //dataPersistenceManager.SaveGame();
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(5);
    }
    public void attackM5()
    {
        //SceneManager.LoadScene("village_test_M3");
        //dataPersistenceManager.SaveGame();
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(6);
    }
    public void attackMB()
    {
        //SceneManager.LoadScene("village_test_MB");
        //dataPersistenceManager.SaveGame();
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(7);
    }
    public void attackMBB()
    {
        //SceneManager.LoadScene("village_test_MBB");
        //dataPersistenceManager.SaveGame();
        DataPersistenceManager.instance.SaveGame();
        loadController.LoadLevel(8);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /*IEnumerator btnCoroutineM1()
    {
        yield return new WaitForSeconds((float)0.1);
        m1UI.SetActive(true);
        yield return new WaitForSeconds((float)1.5);
        m1UI.SetActive(false);
    }

    public void barnInteractBTN()
    {
        Debug.Log("btn_pressed");
        StartCoroutine(btnCoroutineM1());
    }

    IEnumerator btnCoroutineM2()
    {
        yield return new WaitForSeconds((float)0.1);
        m2UI.SetActive(true);
        yield return new WaitForSeconds((float)1.5);
        m2UI.SetActive(false);
        yield return new WaitForSeconds(1);

    }

    public void barnInteractBTNM2()
    {
        Debug.Log("btn_pressed");
        StartCoroutine(btnCoroutineM2());
    }*/
}
