using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player_Sc;
    public GameObject player_Sw;

    public Transform player2_Re;
    public Transform player1_Re;

    public Character character;

    void Start()
    {
        EnemyRespawn();
    }

    void EnemyRespawn()
    {
        //p1, p2인지
        //과학자인지 소드마스터인지.
        if(DataManager.instance.p1Character == Character.Scientist)
        {
            GameObject g = Instantiate(player_Sc, player1_Re);
            Set(g, "Player1", "PLAYER1");
        }
        if (DataManager.instance.p1Character == Character.SwordMaster)
        {
            GameObject g = Instantiate(player_Sw, player1_Re);
            Set(g, "Player1", "PLAYER1");
        }
        if(DataManager.instance.p2Character == Character.Scientist)
        {
            GameObject g = Instantiate(player_Sc, player2_Re);
            Set(g, "Player2", "PLAYER2");
        }
        if (DataManager.instance.p2Character == Character.SwordMaster)
        {
            GameObject g =Instantiate(player_Sw, player2_Re);
            Set(g, "Player2", "PLAYER2");
        }
    }

    void Set(GameObject g,  string name, string tag)
    {
        g.name = name;
        g.tag = tag;
    }

    //sc는 p1임.
}
