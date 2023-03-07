using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class Idler : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public Animator Anim;

    public LayerMask whatIsGround, whatIsPlayer;

    //Others var

    public static bool PlayerLightOn;
    public bool x2;//times 2
    public bool d2;//divide2

    //Animation
    private string Attack = "attack";
    private string Crouch = "stand";
    private string Walk = "walk";




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
        x2 = true;

        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Set AI state
        if (!playerInSightRange && !playerInAttackRange) Idle();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        if (PlayerLightOn && d2)
        {
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
        //Anim.Play(Idle);
    }

    

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        //play walk/run
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(playerPosition);

        if (!alreadyAttacked)
        {
            GameObject thePlayer = GameObject.Find("Player");
            PlayerStats playerScript = thePlayer.GetComponent<PlayerStats>();
            playerScript.Attacked();
            ////play attack
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timebetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }





}//class