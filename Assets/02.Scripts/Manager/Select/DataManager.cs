using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    SwordMaster, Scientist
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
}
