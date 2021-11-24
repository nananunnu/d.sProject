using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMasterAttack : MonoBehaviour
{
    public float damage = 1;

    Animator anim;
    CharacterMove cm;

    [Header("��Ÿ��")]
    public float curTime;
    public float coolTime;

    [Header("�浹�˻�")]
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
                    Debug.Log("�÷��̾�1�� ���� (sw)");
                }
            }
            else if (gameObject.tag == "PLAYER2")
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("�÷��̾�2�� ���� (sw)");
                }
            }

            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0); //�ڽ� �����

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

        //���� flip ���°� �ȸ���...

        if (cm.Flip()) //��
        {
            Debug.Log("swordMaster�� ������ �����ֽ��ϴ�");
            pos.localPosition = new Vector3(-0.1f, 0, 0); 
            //�ν����Ϳ��� ���̴� �ڽĿ�����Ʈ�� position�� �θ������Ʈ�� ����������.. �׷��� localPosition��ߵ�.
        }
        if(!cm.Flip()) //����
        {
            Debug.Log("swordMaster�� �������� �����ֽ��ϴ�");
            pos.localPosition = new Vector3(0.1f, 0, 0);
        }

    }
}
