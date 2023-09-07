using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class Idler : MonoBehaviour
{
    [Header("Public Set Values")]
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public Animator Anim;

    public LayerMask whatIsGround, whatIsPlayer;

    

    public static bool PlayerLightOn;
    bool x2 = true;//times 2
    bool d2;//divide2

    //Animation
    private string attack = "Attack";
    private string idle = "Idle";
    private string walk = "Walk";

    //Audio
    public AudioSource Steps;


    // Attacking

    public float timebetweenAttacks = 2f;
    bool alreadyAttacked = false;

    //states
    public float sightRange = 10f;
    public float attackRange = 5f;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        player = GameObject.Find("Fps Controller").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Locate and set important Values

        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //check for sight and attack range
        //Sight Range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        //Attack Range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Set AI state
        //Sends down to functions
        if (!playerInSightRange && !playerInAttackRange) Idle();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        if (PlayerLightOn && d2)
        {
            //Ajust enemy sight range depending on player flashlight
            sightRange = sightRange * 2;
            x2 = true;
            d2 = false;

        }

        if (!PlayerLightOn && x2)
        {
            sightRange = sightRange / 2;
            d2 = true;
            x2 = false;

        }


    }//Update

    private void Idle()
    {
        agent.SetDestination(transform.position);
        Anim.Play(idle);
    }

    

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Anim.Play(walk);
        Steps.Play();
    }

    private void AttackPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.transform.tag == "Player")
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
                    GameObject Cam = GameObject.Find("Main Camera");
                    PlayerLook playerlook = Cam.GetComponent<PlayerLook>();
                    StartCoroutine(playerlook.Shake(.2f, 0.5f));//timing later
                                                                //attack audio
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