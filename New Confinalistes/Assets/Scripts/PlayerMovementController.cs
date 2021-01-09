using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    Rigidbody2D rb;
    float speedH;
    float speedV;
    public float speedX;
    public float speedY;
    bool facingRight;
    bool facingUp;
    Animator anim;
    public VectorValue startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = false;
        facingUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if  (facingUp)
        {
            Debug.Log("FacingUp = True");
        }

        MovePlayer(speedH);
        MovePlayer(speedV);
        Flip();

        if (Input.GetKeyDown(KeyCode.A))
        {
            speedH = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            speedH = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            speedH = speedX;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            speedH = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            speedV = speedY;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            speedV = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speedV = -speedY;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speedV = 0;
        }
    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = (new Vector3(speedH, speedV, 0));
        if (speedH != 0.0f)
        {
            anim.SetInteger("State", 3);
        }
        else
        if (speedV < 0)
        {
            anim.SetInteger("State", 1);
        }
        else
        if (speedV > 0)
        {
            anim.SetInteger("State", 2);
        }
        else
        if (speedV == 0 && !facingUp)
        {
            anim.SetInteger("State", 0);
        }
        else
        if (speedV == 0 && facingUp)
        {
            anim.SetInteger("State", 4);
        }

    }
    void Flip()
    {
        if (speedH > 0 && facingRight || speedH < 0 && !facingRight)
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            facingRight = !facingRight;
        }
    
        if (speedV < 0 && facingUp || speedV > 0 && facingUp)
        {
            facingUp = !facingUp;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            transform.position = startingPosition.initialValue;
        }
    }
}

