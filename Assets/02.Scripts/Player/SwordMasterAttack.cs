using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMasterAttack : MonoBehaviour
{
    public float damage = 1;
<<<<<<< HEAD
    //public float speed = 40;
    
    public float currentTime = 1;
    public float coolTime = 0.3f;
    
    Animator anim;
    BoxCollider2D coli;
    SpriteRenderer sr;
    
    public Transform pos;
    public Vector2 boxSize;

=======

    Animator anim;
    CharacterMove cm;
>>>>>>> main

    [Header("쿨타임")]
    public float curTime;
    public float coolTime;

    [Header("충돌검사")]
    public Transform pos;
    public Vector2 boxSize;

    void Start()
    {
        anim = GetComponent<Animator>();
<<<<<<< HEAD
        coli = transform.GetChild(0).GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
=======
        cm = GetComponent<CharacterMove>();
>>>>>>> main

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
<<<<<<< HEAD
        if(currentTime <= 0)
        {
            if (gameObject.CompareTag("PLAYER1"))
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    currentTime = coolTime;

                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);

                    foreach (Collider2D collider in collider2Ds)
                    {
                        Debug.Log(collider.tag);

                        if (collider.tag == "Enemy")
                        {
                            collider.GetComponent<EnemyHP>().TakeDamage(1);
                        }
                    }

                    anim.SetTrigger("Attack");
                }
            }
            else if (gameObject.CompareTag("PLAYER2"))
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);

                    foreach (Collider2D collider in collider2Ds)
                    {
                        Debug.Log(collider.tag);

                        if (collider.tag == "Enemy")
                        {
                            collider.GetComponent<EnemyHP>().TakeDamage(1);
                        }
                    }
                    anim.SetTrigger("Attack");
=======

       if(curTime <= 0)
        {

            if (gameObject.tag == "PLAYER1")
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("플레이어1의 공격 (sw)");
                }
            }
            else if (gameObject.tag == "PLAYER2")
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("플레이어2의 공격 (sw)");
>>>>>>> main
                }
            }

            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0); //박스 만들기

            foreach (var col in collider2Ds)
            {
                if (col.tag == "Enemy")
                {
                    col.GetComponent<EnemyHP>().TakeDamage(damage);
                }
            }

            curTime = coolTime;
        }

        else
        {
<<<<<<< HEAD
            currentTime -= Time.deltaTime;
=======
            curTime -= Time.deltaTime;
>>>>>>> main
        }

<<<<<<< HEAD
        
=======

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
>>>>>>> main
    }

    void SetColli()
    {
<<<<<<< HEAD
        if (sr.flipX) //왼쪽
        {
            coli.offset = new Vector2(-0.13f, -0.07f);
            coli.size = new Vector2(0.2f, 0.33f);

            //pos.position = new Vector3(-0.3f, 0);
        }
        else if (!sr.flipX) //오른쪽
        {
            coli.offset = new Vector2(0.12f, -0.07f);
            coli.size = new Vector2(0.2f, 0.33f);

            //pos.position = new Vector3(0.2f, -0.02f, 0);
=======

        //현재 flip 상태가 안먹힘...

        if (cm.Flip()) //왼
        {
            Debug.Log("swordMaster는 왼쪽을 보고있습니다");
            pos.localPosition = new Vector3(-0.1f, 0, 0); 
            //인스펙터에서 보이는 자식오브젝트의 position은 부모오브젝트를 기준으로함.. 그래서 localPosition써야됨.
        }
        if(!cm.Flip()) //오른
        {
            Debug.Log("swordMaster는 오른쪽을 보고있습니다");
            pos.localPosition = new Vector3(0.1f, 0, 0);
>>>>>>> main
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
<<<<<<< HEAD


    private void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.CompareTag("Enemy"))
        //{
        //    col.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
        //    OnDamaged(col.gameObject.transform.position);
        //}
    }
=======
>>>>>>> main
}
