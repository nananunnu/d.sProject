using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character;
    public SelectChar[] chars;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.CompareTag("PLAYER1"))
        {
            DataManager.instance.p1Character = character;
            DataManager.instance.isSelectP1 = true;

            Debug.Log("player1이 " + character + "를 선택했습니다");
        }

        if(col.CompareTag("PLAYER2"))
        {
            DataManager.instance.p2Character = character;
            DataManager.instance.isSelectP2 = true;

            Debug.Log("player2가 " + character + "를 선택했습니다");
        }
    }
}
