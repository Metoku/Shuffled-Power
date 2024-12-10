
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ProgressController : MonoBehaviour, IDataPersistence
{
    public static ProgressController progressInstance;
    public bool B1Win;
    public bool B2Win;
    public bool B3Win;
    public bool B4Win;
    public bool B5Win;
    public bool B6Win;
    public bool B7Win;
    public bool B8Win;
    public bool B9Win;
    public bool B10Win;
    public bool B11Win;
    public bool B12Win;
    public bool B13Win;
    public bool B14Win;
    public bool B15Win;
    public bool B16Win;
    public bool B17Win;
    public bool B18Win;
    private GameObject player;
    private GameObject map1Barrier;
    private GameObject map1move;
    private GameObject map2Barrier;
    private GameObject map2move;
    private GameObject M1;
    private GameObject M2;
    private GameObject M3;
    private GameObject M4;
    private GameObject M5;
    private GameObject M6;
    private GameObject M7;
    private GameObject M8;
    private GameObject M9;
    private GameObject M10;
    private GameObject M11;
    private GameObject M12;
    private GameObject M13;
    private GameObject M14;
    private GameObject M15;
    private GameObject M16;
    private GameObject M17;
    private GameObject M18;
    private Vector3 playerPositionS2 = new Vector3(-39.38325f, 0f, 320.7908f);
    private Vector3 playerPositionS3 = new Vector3(0.2999077f,0f, -29.75246f);
    int sceneNumber;

    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
    
    
    
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    public void Progression1()
    {
        player = GameObject.Find("/Player/FemaleCharacter");
        
        
        
        
        
         sceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (sceneNumber == 1)
        {
            M1 = FindInActiveObjectByName("+M1");
            Debug.Log(M1);
            M2 =  FindInActiveObjectByName("+M2");
            Debug.Log(M2);
            Debug.Log(M3);
            M3 =  FindInActiveObjectByName("+MB");
            M4 =  FindInActiveObjectByName("-M1");
            M5 =  FindInActiveObjectByName("-M2");
            M6 =  FindInActiveObjectByName("-MB");
            M7 =  FindInActiveObjectByName("MBB");
            map1Barrier = GameObject.Find("DK_Barrier (locked)");
            map1move = FindInActiveObjectByName("move_to_DK");
            
            
            if (B1Win == true)
            {
                M1.gameObject.SetActive(false);
                Debug.Log("disable +M1");
            }
        
            if (B2Win == true)
            {
                M2.gameObject.SetActive(false);
                
            }
        
            if (B1Win && B2Win == true)
            {
                M3.gameObject.SetActive(true);
            }
        
            if (B1Win && B2Win && B3Win == true)
            {
                M3.gameObject.SetActive(false);
                M4.gameObject.SetActive(true);
                M5.gameObject.SetActive(true);
            }
        
            if (B4Win == true)
            {
                
                M4.gameObject.SetActive(false);
            }
        
            if (B5Win == true)
            {
                M5.gameObject.SetActive(false);
            }
            if (B4Win && B5Win == true)
            {
                M6.gameObject.SetActive(true);
            }
            
        
            if (B6Win == true)
            {
                M6.gameObject.SetActive(false);
            }
            
            if (B4Win && B5Win && B6Win == true)
            {
                M7.gameObject.SetActive(true);
            }
        
            if (B7Win == true)
            {
                M7.gameObject.SetActive(false);
                map1move.SetActive(true);
                map1Barrier.SetActive(false);
            }
        }
        else if (sceneNumber == 9)
        {
            map2Barrier = GameObject.Find("Barrier_to_DD (locked)");
            map2move = FindInActiveObjectByName("move_to_DD");
            M8 = FindInActiveObjectByName("*M1");
            Debug.Log(M1);
            M9 =  FindInActiveObjectByName("*M2");
            Debug.Log(M2);
            Debug.Log(M3);
            M10 =  FindInActiveObjectByName("*MB");
            M11 =  FindInActiveObjectByName("/M1");
            M12 =  FindInActiveObjectByName("/M2");
            M13 =  FindInActiveObjectByName("/MB");
            M14 =  FindInActiveObjectByName("MBB");

            
            
            
            if (B8Win == true)
            {
                M8.gameObject.SetActive(false);
                Debug.Log("disable +M1");
            }
        
            if (B9Win == true)
            {
                M9.gameObject.SetActive(false);
                
            }
        
            if (B8Win && B9Win == true)
            {
                M10.gameObject.SetActive(true);
            }
        
            if (B8Win && B9Win && B10Win == true)
            {
                M10.gameObject.SetActive(false);
                M11.gameObject.SetActive(true);
                M12.gameObject.SetActive(true);
            }
        
            if (B11Win == true)
            {
                
                M11.gameObject.SetActive(false);
            }
        
            if (B12Win == true)
            {
                M12.gameObject.SetActive(false);
            }
            if (B11Win && B12Win == true)
            {
                M13.gameObject.SetActive(true);
            }
            
        
            if (B13Win == true)
            {
                M13.gameObject.SetActive(false);
            }
            
            if (B13Win == true)
            {
                M14.gameObject.SetActive(true);
            }
        
            if (B14Win == true)
            {
                M14.gameObject.SetActive(false);
                map2Barrier.SetActive(false);
                map2move.SetActive(true);
            }
        }
        else if (sceneNumber == 24)
        {
            M15 = FindInActiveObjectByName("M15");
            Debug.Log(M15);
            M16=  FindInActiveObjectByName("M16");
            
            M17 =  FindInActiveObjectByName("MB17");
            M18 =  FindInActiveObjectByName("MBB18");
            
            
            Debug.Log(M16);
            Debug.Log(M17);
            if (B15Win == true)
            {
                M15.gameObject.SetActive(false);
                M16.gameObject.SetActive(true);
                Debug.Log("disable M15");
            }
        
            if (B16Win == true)
            {
                M16.gameObject.SetActive(false);
                M17.gameObject.SetActive(true);
                Debug.Log("disable M16");
                
            }
            
            if (B17Win == true)
            {
                M17.gameObject.SetActive(false);
                M18.gameObject.SetActive(true);
                Debug.Log("disable M17");
                
            }
            if (B18Win == true)
            {
                M18.gameObject.SetActive(false);
                Debug.Log("game done");
                
            }
            
        }
        
        
        if (sceneNumber == 9)
        {
            
            if (B8Win == false)
            {
                Debug.Log("testing");
                player.transform.position =new Vector3(-39.38325f, 0f, 320.7908f);
            }
        }
        if (sceneNumber == 24)
        {
            if (B15Win == false)
            {
                Debug.Log("testing");
                player.transform.position = new Vector3(0.2999077f,0f, -29.75246f);
            }
        }
    }
    void Awake()
        {
            if (progressInstance != null)
            {
                Debug.LogError("Found more than one ProgressController in the scene. Destroying the newest one.");
                Destroy(this.gameObject);
                return;
            }
            progressInstance = this;
            DontDestroyOnLoad(this.gameObject);

        }
    
    public void LoadData(GameData data)
    {
        

        this.B1Win = data.B1Win;
        this.B2Win = data.B2Win;
        this.B3Win = data.B3Win;
        this.B4Win = data.B4Win;
        this.B5Win = data.B5Win;
        this.B6Win = data.B6Win;
        this.B7Win = data.B7Win;
        this.B8Win = data.B8Win;
        this.B9Win = data.B9Win;
        this.B10Win = data.B10Win;
        this.B11Win = data.B11Win;
        this.B12Win = data.B12Win;
        this.B13Win = data.B13Win;
        this.B14Win = data.B14Win;
        this.B15Win = data.B15Win;
        this.B16Win = data.B16Win;
        this.B17Win = data.B17Win;
        this.B18Win = data.B18Win;
    }

    public void SaveData(GameData data)
    {
        data.B1Win = this.B1Win;
        data.B2Win = this.B2Win;
        data.B3Win = this.B3Win;
        data.B4Win = this.B4Win;
        data.B5Win = this.B5Win ;
        data.B6Win = this.B6Win;
        data.B7Win = this.B7Win;
        data.B8Win = this.B8Win;
        data.B9Win = this.B9Win;
        data.B10Win = this.B10Win;
        data.B11Win = this.B11Win;
        data.B12Win = this.B12Win;
        data.B13Win = this.B13Win;
        data.B14Win = this.B14Win;
        data.B15Win = this.B15Win;
        data.B16Win = this.B16Win;
        data.B17Win = this.B17Win;
        data.B18Win = this.B18Win;
    }
    
}
