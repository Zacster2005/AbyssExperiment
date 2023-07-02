using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public Animator Anim;

    public LayerMask whatIsGround, whatIsPlayer;

    //Others var

    public static bool PlayerLightOn;
    public bool x2;//times 2
    public bool d2;//divide2

    //Audio
    public AudioSource Steps;



    //Animations
    private string walk = "Walk";
    private string attack = "Attack";
    private string Stand = "Crouch";
    private string run = "Run";


    //patroling
    public Vector3 walkPoint;
   public bool walkpointset;
    public float walkPointRange;

    // Attacking

    public float timebetweenAttacks;
    bool alreadyAttacked = false;

    //states
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start ()
    {
        player = GameObject.Find("Fps Controller").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        x2= true;       

        Anim = GetComponent<Animator> ();
    }
    
    private void Update ()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Set AI state
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        if(PlayerLightOn && d2)
        {
            sightRange = sightRange * 2;
            x2 = true;
            d2= false;
            
        }

        if (!PlayerLightOn && x2)
        {
            sightRange = sightRange / 2;
            d2= true;
            x2= false;
            
        }


    }//Update

    private void Patroling()
    {
        if (Vector3.Distance(transform.position, walkPoint) < 1f)
        {
            Debug.Log("Magnitude");
            walkpointset = false;
        }

        if (walkpointset == false)
        {
            SearchWalkPoint();
        }

        if (walkpointset)
        {
            agent.SetDestination(walkPoint);
            Anim.Play(walk);
            Steps.Play();
        }
   
       
    }

    private void SearchWalkPoint()
    {
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);
        float RandomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y,  transform.position.z + RandomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))     
            walkpointset = true;
        
            
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Anim.Play(run);
        //Steps.Play();
    }

    private void AttackPlayer()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if(hit.transform.tag == "Player")
            {
                agent.SetDestination(transform.position);

                Vector3 playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

                transform.LookAt(playerPosition);

                if (!alreadyAttacked)
                {
                    GameObject thePlayer = GameObject.Find("Player");
                    PlayerStats playerScript = thePlayer.GetComponent<PlayerStats>();
                    playerScript.Attacked();
                    Anim.Play(attack);
                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timebetweenAttacks);
                }
            }

            else
            {
                ChasePlayer();
            }
        
        
        }

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

 
  


}//class
