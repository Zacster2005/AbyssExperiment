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
    public AudioSource Walk;
    public int Downlength;
    private Animator animator;
    public LightShake lightShake;


    Vector3 velocity;
    bool isGrounded;

    

    

    void Start ()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    
    
    
    
    void Update()
    {
        RaycastHit hit;
        
        Vector3 dwn = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, dwn, out hit, Downlength))
        {
            isGrounded= true;
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
            }

            velocity.y += Gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
            


        if (velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            StartCoroutine(lightShake.Shake(.5f, 1f));
        }

      

    }//update
   
    


}//class
