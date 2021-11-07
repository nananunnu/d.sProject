using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMasterAttack : MonoBehaviour
{
    public float damage = 1;
    //public bool isAttack = false;

    Animator anim;
    BoxCollider2D coli;
    CharacterMove cm;

    void Start()
    {
        anim = GetComponent<Animator>();
        coli = transform.GetChild(0).GetComponent<BoxCollider2D>();
        cm = GetComponent<CharacterMove>();

    }

    void Update()
    {
        Attack();
        //Anim();
        SetColli();
    }

    void Attack()
    {
        if (gameObject.CompareTag("PLAYER1"))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetTrigger("Attack");
                Debug.Log("Sw공격이 실행됩니다");
            }
            else
            {
                //isAttack = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                anim.SetTrigger("Attack");
                //isAttack = true;
                //Debug.Log(isAttack);
            }
            else
            {
                //isAttack = false;
            }
        }
    }

    void Anim()
    {
        //anim.SetBool("isAttack", isAttack);
    }

    void SetColli()
    {

        if (cm.Flip())
        {
            Debug.Log("swordMaster는 왼쪽을 보고있습니다");

            coli.offset = new Vector2(-0.13f, -0.07f);
            coli.size = new Vector2(0.2f, 0.33f);
        }
        if(!cm.Flip())
        {
            Debug.Log("swordMaster는 오른쪽을 보고있습니다");
            coli.offset = new Vector2(0.12f, -0.07f);
            coli.size = new Vector2(0.2f, 0.33f);
        }

    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //isAttack = false;
            col.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
        }

        if (col.gameObject.CompareTag("GROUND") || col.gameObject.CompareTag("Tile"))
        {
            Debug.Log("Tile or Ground와 부딪혔습니다");
            //isAttack = false;
        }
    }
}
