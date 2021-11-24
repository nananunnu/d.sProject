using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sci : MonoBehaviour
{
    public float damage = 1;

    Animator anim;
    GameObject gun;
    CharacterMove cm;

    [Header("�浹����")]
    public Transform pos;
    public Vector2 boxSize;

    [Header("��Ÿ��")]
    public float curTime;
    public float coolTime;

    void Start()
    {
        anim = GetComponent<Animator>();
        gun = transform.GetChild(0).gameObject;
        cm = GetComponent<CharacterMove>();

        curTime = 0f;
        coolTime = 0.5f;
    }

    void Update()
    {
        Attack();
        SetColli();
    }

    void Attack()
    {
        if(curTime <= 0)
        {
            if (gameObject.tag == "PLAYER1")
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("�÷��̾�1�� ���� (sc)");
                }
            }
            else if (gameObject.tag == "PLAYER2")
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("�÷��̾�1�� ���� (sc)");
                }
            }

            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);

            foreach(var col in collider2Ds)
            {
                if(col.tag == "Enemy")
                {
                    col.GetComponent<EnemyHP>().TakeDamage(damage);
                }
            }

            curTime = coolTime;
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    void SetColli()
    {
        if(cm.Flip()) //��
        {
            Debug.Log("Scientist�� ������ �����ֽ��ϴ�");
            pos.localPosition = new Vector3(-0.15f, 0, 0);
        }
        else if(!cm.Flip()) //����
        {
            Debug.Log("Scientist�� �������� �����ֽ��ϴ�");
            pos.localPosition = new Vector3(0.15f, 0, 0);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
