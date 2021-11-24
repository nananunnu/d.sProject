using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    SwordMaster, Scientist, None
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public Character p1Character;
    public Character p2Character;

    public bool isSelectP1 = false;
    public bool isSelectP2 = false;

    public bool isPlayer1 = false;
    public bool isPlayer2 = false;

    public bool isAttack = false;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
