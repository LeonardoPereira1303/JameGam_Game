using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    
    
    
    
    //Rigidbody2D rb;
    //[SerializeField] Transform groundCheckCollider;
    //[SerializeField] LayerMask groundLayer;

    //const float groundCheckRadius = 0.2f;
    //[SerializeField] public float speed = 2f;
    //[SerializeField] float jumpPower = 100f;
    //float horizontalValue;

    //[SerializeField] bool isGrounded;
    //bool jump;


    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    horizontalValue = Input.GetAxisRaw("Horizontal");

    //    //Adicionei o && isGrounded for true pra que ele pule só quando o player estiver no chão
    //    //Dessa forma, o áudio não toca se ele estiver no ar e também não pula, mesmo que não tenha nenhum efeito visual diferente
    //    if (Input.GetButtonDown("Jump") && isGrounded)
    //    {
    //        jump = true;
    //        AudioManager.instance.PlaySFX("jump");
    //    }
    //    else if (Input.GetButtonUp("Jump"))
    //        jump = false;
    //}

    //private void FixedUpdate()
    //{
    //    GroundCheck();
    //    Move(horizontalValue, jump);
    //}

    //public void GroundCheck()
    //{
    //    isGrounded = false;

    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
    //    if (colliders.Length > 0)
    //    {
    //        isGrounded = true;
    //    }
    //}

    //public void Move(float direction, bool jumpFlag)
    //{
    //    if (isGrounded && jumpFlag)
    //    {
    //        isGrounded = false;
    //        jumpFlag = false;
    //        rb.AddForce(new Vector2(0f, jumpPower));
    //    }

    //    float xVal = direction * speed * 100 * Time.fixedDeltaTime;
    //    Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
    //    rb.velocity = targetVelocity;
    //}
}
