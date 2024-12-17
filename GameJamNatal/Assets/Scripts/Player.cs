using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    Rigidbody2D rb;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    [SerializeField] public float speed = 2f; 
    float horizontalValue;

    [SerializeField] bool isGrounded = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue);
    }

    public void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    public void Move(float direction)
    {
        float xVal = direction * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
}
