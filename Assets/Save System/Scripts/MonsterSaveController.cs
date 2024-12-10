using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSaveController : MonoBehaviour, ISavable
{

    [SerializeField] private GameObject monster;
    public bool monsterLost;

    private void Start()
    {
        if (monsterLost)
        {

            monster.SetActive(false);
        }
        else
        {
            monster.SetActive(true);
        }
    }
    public object CaptureState()
    {
        return monsterLost;

     
    }

    public void RestoreState(object state)
    {
        monsterLost = (bool)state;
        if (monsterLost)
        {
            monster.gameObject.SetActive(false);
        }
    }

   public void battleResult()
    {
        monsterLost = true;
        if (monsterLost)
        {

            monster.SetActive(false);
        }
        else
        {
            monster.SetActive(true);
        }

    }
}
