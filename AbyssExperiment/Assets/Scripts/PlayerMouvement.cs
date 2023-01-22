using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController controller;
    public float Speed = 12f;
    public float Gravity = -20f;
    public float JumpHeigth = 1f;
    public AudioSource Land;

    private Animator animator;
    

    Vector3 velocity;
    bool isGrounded;

    bool isRunning;

    

    void Start ()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    
    
    
    
    void Update()
    {
        
        if(!isRunning && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = Speed * 2;
            isRunning = true;
        }

        if (isRunning && Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = Speed / 2;
            isRunning = false;
        }



        if (controller.isGrounded)
        {
            isGrounded = true;
        }
       

        if ( velocity.y < 0f && isGrounded)
            {
                velocity.y = -2f; 
            }


            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * Speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space)&& isGrounded)
            {
                velocity.y = Mathf.Sqrt(JumpHeigth * -2 * Gravity);
            isGrounded = false;
            StartCoroutine (Jumping());
            }

            velocity.y += Gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
       
        if (velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        IEnumerator Jumping()
        {
            yield return new WaitForSeconds(10f);
            isGrounded = true;
        }
            //Animations

        if(move != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }



        //Augmented Mouvement

    }//update
   
}//class
