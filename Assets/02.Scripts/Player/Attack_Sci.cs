using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sci : MonoBehaviour
{
    public float damage = 1;
    public float currentTime = 1;
    public float coolTime = 1f;

    Animator anim;
<<<<<<< HEAD
    BoxCollider2D coli;
    SpriteRenderer sr;

    public Transform pos;
    public Vector2 boxSize;
=======
    GameObject gun;
    CharacterMove cm;
>>>>>>> main

    [Header("충돌관련")]
    public Transform pos;
    public Vector2 boxSize;

    [Header("쿨타임")]
    public float curTime;
    public float coolTime;

    void Start()
    {
        anim = GetComponent<Animator>();
<<<<<<< HEAD
        coli = transform.GetChild(0).GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
=======
        gun = transform.GetChild(0).gameObject;
        cm = GetComponent<CharacterMove>();

        curTime = 0f;
        coolTime = 0.5f;
>>>>>>> main
    }

    void Update()
    {
        Attack();
        SetColli();
    }

    void Attack()
    {
<<<<<<< HEAD
        if(currentTime <= 0)
        {  
            if (gameObject.CompareTag("PLAYER1"))
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    currentTime = coolTime;

                    anim.SetTrigger("Attack");

                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                    foreach (Collider2D collider in collider2Ds)
                    {
                        if (collider.tag == "Enemy")
                        {
                            collider.GetComponent<EnemyHP>().TakeDamage(1);
                        }
                    }
                }
            }
            else if (gameObject.CompareTag("PLAYER2"))
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {

                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                    foreach (Collider2D collider in collider2Ds)
                    {
                        if (collider.tag == "Enemy")
                        {
                            collider.GetComponent<EnemyHP>().TakeDamage(1);
                        }
                    }

                    anim.SetTrigger("Attack");
                }
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }


    void SetColli()
    {

        if (sr.flipX) //왼쪽
        {
            coli.offset = new Vector2(-0.26f, -0.008f);
            coli.size = new Vector2(0.28f, 0.17f);

            //pos.position = new Vector3(-0.3f, 0, 0);
        }
        else if (!sr.flipX) //오른쪽
        {
            coli.offset = new Vector2(0.3f, -0.008f);
            coli.size = new Vector2(0.28f, 0.17f);

            //pos.position = new Vector3(0.2f, -0.03f, 0);
=======
        if(curTime <= 0)
        {
            if (gameObject.tag == "PLAYER1")
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("플레이어1의 공격 (sc)");
                }
            }
            else if (gameObject.tag == "PLAYER2")
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("플레이어1의 공격 (sc)");
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
        if(cm.Flip()) //왼
        {
            Debug.Log("Scientist는 왼쪽을 보고있습니다");
            pos.localPosition = new Vector3(-0.15f, 0, 0);
        }
        else if(!cm.Flip()) //오른
        {
            Debug.Log("Scientist는 오른쪽을 보고있습니다");
            pos.localPosition = new Vector3(0.15f, 0, 0);
>>>>>>> main
        }

    }

    private void OnDrawGizmos()
<<<<<<< HEAD
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //if(col.gameObject.CompareTag("Enemy"))
        //{
        //    col.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
        //    OnDamaged(col.gameObject.transform.position);
        //}
        
=======
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
>>>>>>> main
    }
}
