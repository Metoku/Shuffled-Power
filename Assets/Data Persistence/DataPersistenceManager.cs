using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("Debugging")]

    [SerializeField] private bool disableDataPersistence = false;
    [SerializeField] private bool initializeDataIfNull = false;
    [SerializeField] private bool overrideSelectedProfileId = false;
    [SerializeField] private string testSelectedProfileId = "test";

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileId = "";
    public static DataPersistenceManager instance { get; private set; }


    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        if(disableDataPersistence)
        {
            Debug.LogWarning("Data Persistence is disabled");
        }

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        this.selectedProfileId = dataHandler.GetMostRecentlyUpdatedProfileId();
        if(overrideSelectedProfileId)
        {
            this.selectedProfileId = testSelectedProfileId;
            Debug.LogWarning("Overrode selected profile id with test id: " + testSelectedProfileId);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        
    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Debug.Log("OnSceneLoaded Called");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }


    public void ChangeSelectedProfileId(string newProfileId)
    {
        this.selectedProfileId = newProfileId;
        //loadgame
        LoadGame();
    }



    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if (disableDataPersistence)
        {
            return;
        }
        
        this.gameData = dataHandler.Load(selectedProfileId);

        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        // if no data nothing happens
        if (this.gameData == null)
        {
            Debug.Log("No data was found. A new game needs to be started before data can be loaded.");
            return;
        }




        // push to all other scripts
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        

    }
    
    

    public void SaveGame()
    {
        
        // update the current scene in our data
        int scene = SceneManager.GetActiveScene().buildIndex;
        
        // DON'T save this for certain scenes, like our main menu scene
        if (scene == 1 || scene == 9 || scene == 24)
        {
            gameData.currentSceneNumber = scene;
        }
        
        // save that data to a file using the data handler
        dataHandler.Save(gameData, selectedProfileId);
        if (disableDataPersistence)
        {
            return;
        }

        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. A new game needs to be started before data can be loaded.");
            return;
        }
        // push to all other scripts
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        // save data to a file
        dataHandler.Save(gameData, selectedProfileId);

    }

    /*private void OnApplicationQuit()
    {
        SaveGame();
    }*/
    

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();
        
        return new List<IDataPersistence>(dataPersistenceObjects);
    }


    public bool HasGameData()
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
    
    
    public int GetSavedSceneNumber() 
    {
        // error out and return null if we don't have any game data yet
        if (gameData == null) 
        {
            Debug.LogError("Tried to get scene name but data was null.");
            return 16;
        }
        // otherwise, return that value from our data
        return gameData.currentSceneNumber;
    }


}
