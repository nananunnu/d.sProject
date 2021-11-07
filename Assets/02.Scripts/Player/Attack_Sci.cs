using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sci : MonoBehaviour
{
    //scientist 공격을 처음 1번 실행한 뒤에는 실행이 안됨.
    //scientist가 왼쪽을 볼 때에도 무기는 오른쪽을 향해잇음(collider offset 문제)
    //각 직업별 애니메이션 실행X


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
                Debug.Log("Sc공격이 실행됩니다");

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
            Debug.Log("Scientist는 왼쪽을 보고있습니다");
            coli.offset = new Vector2(-0.26f, -0.008f);
            coli.size = new Vector2(0.28f, 0.17f);
        }
        if(!cm.Flip())
        {
            Debug.Log("Scientist는 오른쪽을 보고있습니다");
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
        //    Debug.Log("Tile or Ground와 부딪혔습니다");
        //    isAttack = false;
        //}

    }
}
