using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMasterAttack : MonoBehaviour
{
    public float damage = 1;
    //public float speed = 40;
    
    public float currentTime = 1;
    public float coolTime = 0.3f;
    
    Animator anim;
    BoxCollider2D coli;
    SpriteRenderer sr;
    
    public Transform pos;
    public Vector2 boxSize;


    void Start()
    {
        anim = GetComponent<Animator>();
        coli = transform.GetChild(0).GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        Attack();
        SetColli();
    }

    void Attack()
    {
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
        if (sr.flipX) //¿ÞÂÊ
        {
            coli.offset = new Vector2(-0.13f, -0.07f);
            coli.size = new Vector2(0.2f, 0.33f);

            //pos.position = new Vector3(-0.3f, 0);
        }
        else if (!sr.flipX) //¿À¸¥ÂÊ
        {
            coli.offset = new Vector2(0.12f, -0.07f);
            coli.size = new Vector2(0.2f, 0.33f);

            //pos.position = new Vector3(0.2f, -0.02f, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.CompareTag("Enemy"))
        //{
        //    col.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
        //    OnDamaged(col.gameObject.transform.position);
        //}
    }
}
