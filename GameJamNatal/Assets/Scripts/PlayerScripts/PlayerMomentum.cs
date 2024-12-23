using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMomentum : MonoBehaviour
{
    public PlayerData Data;

    #region Componentes
    public Rigidbody2D rb { get; private set; }
    //public PlayerAnimator AnimHandler { get; private set; }

    public Animator anim;
    #endregion

    public bool IsFacingRight { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsSliding { get; private set; }
    public float LastOnGroundTime { get; private set; }
    public float LastOnWallTime { get; private set; }
    public float LastOnWallRightTime { get; private set; }
    public float LastOnWallLeftTime { get; private set; }
    public bool isDead = false;


    //Jump
    private bool isJumpCut;
    private bool isJumpFalling;
    public bool isGrounded = false;

    private Vector2 moveInput;

    public float LastPressedJumpTime { get; private set; }

    [Header("Checks")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.49f, 0.03f);

    [Header("Layers & Tags")]
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        SetGravityScale(Data.gravityScale);
        IsFacingRight = true;
    }

    private void Update()
    {
        LastOnGroundTime -= Time.deltaTime;
        LastPressedJumpTime -= Time.deltaTime;

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput.x != 0)
            CheckDirectionToFace(moveInput.x > 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpInput();

            isGrounded = false;
            anim.SetBool("isJumping", !isGrounded);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpUpInput();
        }

        if (!IsJumping)
        {
            if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer))
            {
                //if (LastOnGroundTime < -0.1f)
                //{
                //    AnimHandler.justLanded = true;
                //}

                LastOnGroundTime = Data.coyoteTime;
            }
        }

        #region JUMP CHECKS
        if (IsJumping && rb.velocity.y < 0)
        {
            IsJumping = false;

            isJumpFalling = true;
        }

        if (LastOnGroundTime > 0 && !IsJumping)
        {
            isJumpCut = false;

            isJumpFalling = false;
        }

        //Jump
        if (CanJump() && LastPressedJumpTime > 0)
        {
            IsJumping = true;
            isJumpCut = false;
            isJumpFalling = false;
            Jump();
            //AudioManager.instance.PlaySFX("jump");

            //AnimHandler.startedJumping = true;
        }
        #endregion

        if (CanSlide() && ((LastOnWallLeftTime > 0 && moveInput.x < 0) || (LastOnWallRightTime > 0 && moveInput.x > 0)))
        {
            IsSliding = true;
        }
        else
        {
            IsSliding = false;
        }

        if (IsSliding)
        {
            SetGravityScale(10);
        }
        else if (rb.velocity.y < 0 && moveInput.y < 0)
        {
            SetGravityScale(Data.gravityScale * Data.fastFallGravityMult);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -Data.maxFastFallSpeed));
        }
        else if (isJumpCut)
        {
            SetGravityScale(Data.gravityScale * Data.jumpCutGravityMult);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -Data.maxFallSpeed));
        }
        else if ((IsJumping || isJumpFalling) && Mathf.Abs(rb.velocity.y) < Data.jumpHangTimeThresold)
        {
            SetGravityScale(Data.gravityScale * Data.jumpHangGravityMult);
        }
        else if (rb.velocity.y < 0)
        {
            SetGravityScale(Data.gravityScale * Data.fallGravityMult);
            rb.velocity = new Vector2(rb.velocity.x, Math.Max(rb.velocity.y, -Data.maxFallSpeed));
        }
        else
        {
            SetGravityScale(Data.gravityScale);
        }
    }

    private void FixedUpdate()
    {
        Run(1);

        if (IsSliding)
            Slide();

        anim.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
    }

    public void OnJumpUpInput()
    {
        if (CanJumpCut())
            isJumpCut = true;
    }

    public void OnJumpInput()
    {
        LastPressedJumpTime = Data.jumpInputBufferTime;
    }

    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
            Turn();
    }

    public void SetGravityScale(float scale)
    {
        rb.gravityScale = scale;
    }

    private void Sleep(float duration)
    {
        StartCoroutine(nameof(PerformSleep), duration);
    }

    private IEnumerator PerformSleep(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1;
    }

    private void Run(float lerpAmount)
    {
        float targetSpeed = moveInput.x * Data.runMaxSpeed;
        targetSpeed = Mathf.Lerp(rb.velocity.x, targetSpeed, lerpAmount);

        float accelRate;

        if (LastOnGroundTime > 0)
        {
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        }
        else
        {
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount * Data.accelInAir : Data.runDeccelAmount;
        }

        if ((IsJumping || isJumpFalling) && Mathf.Abs(rb.velocity.y) < Data.jumpHangTimeThresold)
        {
            accelRate *= Data.jumpHangAccelerationMult;
            targetSpeed *= Data.jumpHangMaxSpeedMult;
        }

        if (Data.doConserveMomentum && Mathf.Abs(rb.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(rb.velocity.x)
            == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
        {
            accelRate = 0;
        }

        float speedDif = targetSpeed - rb.velocity.x;

        float movement = speedDif * accelRate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    private void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }

    private void Jump()
    {
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;

        float force = Data.jumpForce;
        if(rb.velocity.y < 0)
            force -= rb.velocity.y;

        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void Slide()
    {
        if (rb.velocity.y > 0)
            rb.AddForce(-rb.velocity.y * Vector2.up, ForceMode2D.Force);

        float speedDif = Data.slideSpeed - rb.velocity.y;
        float movement = speedDif * Data.slideAccel;

        movement = Mathf.Clamp(movement, -Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime), Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime));

        rb.AddForce(movement * Vector2.up);
    }

    private bool CanJump()
    {
        return LastOnGroundTime > 0 && !IsJumping;
    }

    private bool CanJumpCut()
    {
        return IsJumping && rb.velocity.y > 0;
    }

    public bool CanSlide()
    {
        if(LastOnWallTime > 0 && !IsJumping && LastOnGroundTime <=0 )
            return true;
        else
            return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
}
