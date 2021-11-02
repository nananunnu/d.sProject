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

        if (DataManager.instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ĳ���Ϳ� ������ ��.
    void OnSelect()
    {
        DataManager.instance.currentCharacter = character;

        sr.color = new Color(1, 0.5f, 1);
        Debug.Log(character + "�� �����߽��ϴ�");
    }

    void OnDeSelect()
    {
        sr.color = new Color(1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnSelect();

        for(int i= 0; i < chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }
}
