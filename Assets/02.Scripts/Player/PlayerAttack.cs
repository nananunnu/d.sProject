using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    public float damage;

    bool isAttack = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
    }

    void Attack1()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            isAttack = true;
            Debug.Log("공격이 실행됩니다");
        }
    }

    void Attack2()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }
    }

    void Devive()
    {

        if(gameObject.transform.parent.CompareTag("PLAYER1"))
        {
            Attack1();
        }
        if (gameObject.transform.parent.CompareTag("PLAYER2"))
        {
            Attack2();
        }
    }

    void Anim()
    {
        anim.SetBool("isAttack", isAttack);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
            Debug.Log("적이 공격되었습니다");
            isAttack = false;
        }

        if (col.gameObject.CompareTag("GROUND"))
        {
            isAttack = false;
        }
    }
}
