using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sci : MonoBehaviour
{
    //scientist ������ ó�� 1�� ������ �ڿ��� ������ �ȵ�.
    //scientist�� ������ �� ������ ����� �������� ��������(collider offset ����)
    //�� ������ �ִϸ��̼� ����X


    public bool isAttack = false;
    public float damage = 1;

    Animator anim;
    GameObject gun;
    BoxCollider2D coli;
    CharacterMove cm;

    void Start()
    {
        anim = GetComponent<Animator>();
        gun = transform.GetChild(0).gameObject;
        coli = gun.GetComponent<BoxCollider2D>();
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
                //isAttack = true;
                anim.SetTrigger("Attack");
                Debug.Log("Sc������ ����˴ϴ�");

                StartCoroutine(Gun());
                gun.gameObject.SetActive(false);
            }
            else
            {
                //isAttack = false;
            }
        }
        else if(gameObject.CompareTag("PLAYER2"))
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                //isAttack = true;
                anim.SetTrigger("Attack");
                StartCoroutine(Gun());
                StopAllCoroutines();
                gun.gameObject.SetActive(false);
            }
            else
            {
                //isAttack = false;
            }
        }
    }

    IEnumerator Gun()
    {
        gun.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
    }

    void Anim()
    {
        //anim.SetBool("isAttack", isAttack);
    }

    void SetColli()
    {
        if(cm.Flip())
        {
            Debug.Log("Scientist�� ������ �����ֽ��ϴ�");
            coli.offset = new Vector2(-0.26f, -0.008f);
            coli.size = new Vector2(0.28f, 0.17f);
        }
        if(!cm.Flip())
        {
            Debug.Log("Scientist�� �������� �����ֽ��ϴ�");
            coli.offset = new Vector2(0.3f, -0.008f);
            coli.size = new Vector2(0.28f, 0.17f);

        }
        
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.CompareTag("Enemy"))
        //{
        //    isAttack = false;
        //    col.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
        //}

        //if (col.gameObject.CompareTag("GROUND") || col.gameObject.CompareTag("Tile"))
        //{
        //    Debug.Log("Tile or Ground�� �ε������ϴ�");
        //    isAttack = false;
        //}

    }
}
