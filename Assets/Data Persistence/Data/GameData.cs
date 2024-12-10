using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
    
{
    public long lastUpdated;
    public int defeatedEnemiesCount;
    public int currentSceneNumber;

    public Vector3 playerPosition;

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
    // public bool B8Win;
    // public bool B9Win;
    //default values
    public GameData()
    {
        this.B1Win = false;
        this.B2Win = false;
        this.B3Win = false;
        this.B4Win = false;
        this.B5Win = false;
        this.B6Win = false;
        this.B7Win = false;
        this.B8Win = false;
        this.B9Win = false;
        this.B10Win = false;
        this.B11Win = false;
        this.B12Win = false;
        this.B13Win = false;
        this.B14Win = false;
        this.B15Win = false;
        this.B16Win = false;
        this.B17Win = false;
        this.B18Win = false;
        
        this.defeatedEnemiesCount = 0;
        this.currentSceneNumber = 16;
        //playerPosition.Set(-45.2f / -45.2f, 0.42f / 0.42f,  -35.65f);
        //playerPosition.Set(0.159999996f, 0,  -34.4500008f);
        this.playerPosition =  new Vector3(0.2999992f, 0f, -37.26402f);

    }
    


    


}
