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

    public float speed = 6;

    bool isRun = false;
    bool isFlip = false;
    bool isShoot = false;
    public Player player;

    public SpriteRenderer L_sr;
    public SpriteRenderer T_sr;

    public GameObject bul_Prefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Devide();
        Animator();
        //Shoot();
    }

    void P1Move()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveY == 1 || moveY == -1 || moveX == 1 || moveX == -1) isRun = true;
        else isRun = false;

        Vector2 getVel = new Vector2(moveX, moveY) * speed;
        rb.velocity = getVel;

        Flip(moveX);
    }

    //void Shoot()
    //{
    //    if(Input.GetKeyDown(KeyCode.Z))
    //    {
    //        Instantiate(bul_Prefab, transform.GetChild(2));
    //        isShoot = true;
    //    }
    //}

    void P2Move()
    {
        float moveX = 0;
        float moveY = 0;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1;
        }

        if (moveY == 1 || moveY == -1 || moveX == 1 || moveX == -1) isRun = true;
        else
        {
            isRun = false;
            isFlip = false;
        }

        Vector2 getVel = new Vector2(moveX, moveY) * speed;
        rb.velocity = getVel;

        Flip(moveX);
    }

    void Devide()
    {
        if(player == Player.Player1)
        {
            L_sr = GameObject.FindWithTag("PLAYER1").transform.GetChild(1).GetComponent<SpriteRenderer>();
            T_sr = GameObject.FindWithTag("PLAYER1").transform.GetChild(0).GetComponent<SpriteRenderer>();

            P1Move();

        }
        else if(player == Player.Player2)
        {
            L_sr = GameObject.FindWithTag("PLAYER2").transform.GetChild(1).GetComponent<SpriteRenderer>();
            T_sr = GameObject.FindWithTag("PLAYER2").transform.GetChild(0).GetComponent<SpriteRenderer>();

            P2Move();
        }
    }

    void Animator()
    {
        anim_L.SetBool("L_Run", isRun);
        anim_T.SetBool("T_Run", isRun);
        //anim_T.SetBool("T_Shoot", isShoot);
        //anim_L.SetBool("L_Shoot", isShoot);
    }

    void Flip(float moveX)
    {
        if(isFlip)
        {
            return;
        }

        if (moveX == -1 && isRun)
        {
            L_sr.flipX = !L_sr.flipX;
            
        }
        else
        {
            L_sr.flipX = L_sr.flipX;
        }
        isFlip = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
