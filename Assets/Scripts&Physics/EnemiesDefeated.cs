using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDefeated : MonoBehaviour, IDataPersistence
{
    public int defeatedEnemiesCount = 0;

    public void LoadData(GameData data)
    {
        this.defeatedEnemiesCount = data.defeatedEnemiesCount;
    }

    public void SaveData(GameData data)
    {
        data.defeatedEnemiesCount = this.defeatedEnemiesCount;
    }

   
}
