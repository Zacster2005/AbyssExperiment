using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class BigZombie : MonoBehaviour
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
    private string attack = "Attack";
    private string idle = "Idle";
    private string walk = "Walk";
    private string Stand = "Stand";

    //Audio
    public AudioSource Steps;


    // Attacking

    public float timebetweenAttacks = 2f;
    bool alreadyAttacked = false;

    //states
    public float sightRange = 5f;
    public float attackRange = 2f;
    public bool playerInSightRange, playerInAttackRange, playerInDectectionRange;
    public float DectectionRange = 10f;

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
        playerInDectectionRange = Physics.CheckSphere(transform.position, DectectionRange, whatIsPlayer);


        //Set AI state
        if (!playerInSightRange && !playerInAttackRange) Idle();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
        if (playerInDectectionRange) Rise();

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

    public void Rise()
    {
        agent.SetDestination(transform.position);
        Anim.Play(Stand);
    }


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
            StartCoroutine(playerlook.Shake(.2f, .5f));//work on timing
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timebetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, DectectionRange);
    }

}//class