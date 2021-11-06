using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator anim;
    
    public float speed = 6;

    bool isRun = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Devive();
        //Anim();
    }

    void P1Move()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX == 1 || moveX == -1 || moveY == 1 || moveY == -1)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        Vector2 getVel = new Vector2(moveX, moveY) * speed;
        rb.velocity = getVel;
    }

    void P2Move()
    {
        float moveY = 0;
        float moveX = 0;

        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1;
        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1;
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1;

        if (moveX == 1 || moveX == -1 || moveY == 1 || moveY == -1)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        Vector2 getVel = new Vector2(moveX, moveY) * speed;
        rb.velocity = getVel;

    }

    void Devive()
    {
        if (gameObject.CompareTag("PLAYER1"))
        {
            P1Move();
        }
        if (gameObject.CompareTag("PLAYER2"))
        {
            P2Move();
        }
    }

    void Anim()
    {
        anim.SetBool("L_Run", isRun);
    }

}
