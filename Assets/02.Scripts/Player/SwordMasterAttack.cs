using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMasterAttack : MonoBehaviour
{
    public float damage = 1;

    Animator anim;
    CharacterMove cm;

    [Header("쿨타임")]
    public float curTime;
    public float coolTime;

    [Header("충돌검사")]
    public Transform pos;
    public Vector2 boxSize;

    void Start()
    {
        anim = GetComponent<Animator>();
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
                    Debug.Log("플레이어1의 공격 (sw)");
                }
            }
            else if (gameObject.tag == "PLAYER2")
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("플레이어2의 공격 (sw)");
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
            curTime -= Time.deltaTime;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    void SetColli()
    {

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
        }

    }
}
