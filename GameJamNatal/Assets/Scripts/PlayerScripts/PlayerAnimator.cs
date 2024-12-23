using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMomentum mov;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [Header("Movement Tilt")]
    [SerializeField] private float maxTilt;
    [SerializeField][Range(0, 1)] private float tiltSpeed;

    public bool startedJumping { private get;  set; }
    public bool justLanded { private get;  set; }

    public float currentVelY;

    private void Start()
    {
        mov = GetComponent<PlayerMomentum>();
        spriteRend = GetComponent<SpriteRenderer>();
        anim = spriteRend.GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        float tiltProgress;

        int mult = -1;

        if (mov.IsSliding)
        {
            tiltProgress = 0.25f;
        }
        else
        {
            tiltProgress = Mathf.InverseLerp(-mov.Data.runMaxSpeed, mov.Data.runMaxSpeed, mov.rb.velocity.x);
            mult = (mov.IsFacingRight) ? 1 : -1;
        }

        float newRot = ((tiltProgress * maxTilt * 2) - maxTilt);
        float rot = Mathf.LerpAngle(spriteRend.transform.localRotation.eulerAngles.z * mult, newRot, tiltSpeed);
        spriteRend.transform.localRotation = Quaternion.Euler(0, 0, rot * mult);

        CheckAnimationState();
    }

    private void CheckAnimationState()
    {
        if (startedJumping)
        {
            anim.SetTrigger("IsGrounded");
            startedJumping = false;
            return;
        }

        if (justLanded)
        {
            anim.SetTrigger("IsStopped");
            justLanded = false;
            return;
        }

        anim.SetFloat("Vel Y", mov.rb.velocity.y);
    }
}
