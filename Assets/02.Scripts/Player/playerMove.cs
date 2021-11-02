using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    Player1, Player2
}

public class playerMove : MonoBehaviour
{
    Rigidbody2D rb;
    
    public Animator anim_L;
    public Animator anim_T;

    public Player player;

    public float speed = 6;

    bool isRun = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Devive();
        Anim();
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

        if(Input.GetKey(KeyCode.RightArrow)) moveX = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1;
        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1;
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1;

        if (moveX == 1 || moveX == -1 || moveY == 1 || moveY == -1)
        {
            isRun = true;
            Debug.Log("isRun은 true입니다");
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
        if(player == Player.Player1)
        {
            P1Move();
        }
        if(player == Player.Player2)
        {
            P2Move();
        }
    }

    void Anim()
    {
        anim_L.SetBool("L_Run", isRun);
        anim_T.SetBool("T_Run", isRun);
    }
}
