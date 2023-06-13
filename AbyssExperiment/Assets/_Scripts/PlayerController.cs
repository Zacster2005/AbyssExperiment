using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public GameObject CamHolder;
    public float Speed, Sensitivity, MaxForce, jumpforce, SprintSpeed, crouchSpeed;
    private Vector2 move, look;
    private float lookRotation;
    public bool Grounded =true;
    private bool IsSprinting, isCrouching;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        IsSprinting = context.ReadValueAsButton();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        isCrouching = context.ReadValueAsButton();
    }

    private void FixedUpdate()
    {
        Move();
        SetGrounded();
    }

    void Jump()
    {
        Vector3 JumpForces = rb.velocity;

        if(Grounded)
        {
            JumpForces.y = jumpforce;
        }

        rb.velocity = JumpForces;
    }

    void Move()

    {
        //find velocity

        Vector3 currentVelocity = rb.velocity;
        Vector3 TargetVelocity = new Vector3(move.x, 0, move.y);
        TargetVelocity *= isCrouching ? crouchSpeed : (IsSprinting ? SprintSpeed : Speed);

        //Align with Player

        TargetVelocity = transform.TransformDirection(TargetVelocity);

        //calculate Force

        Vector3 VelocityChange = (TargetVelocity - currentVelocity);
        VelocityChange = new Vector3(VelocityChange.x, 0, VelocityChange.z);

        //limit force

        Vector3.ClampMagnitude(VelocityChange, MaxForce);

        rb.AddForce(VelocityChange, ForceMode.VelocityChange);
    }

    void Look()
    {
        //turn
        transform.Rotate(Vector3.up * look.x * Sensitivity);

        //look
        lookRotation += (-look.y * Sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        CamHolder.transform.eulerAngles = new Vector3(lookRotation, CamHolder.transform.eulerAngles.y, CamHolder.transform.eulerAngles.z);
    }

    public void LateUpdate()
    {
        Look();
    }

    private void Update()
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void SetGrounded()
    {
        Vector3 dwn = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, dwn, 2))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }


}//class
