using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class DemonDogController : MonoBehaviour, IEnemyBehaviour
{
    [SerializeField] float patrolSpeed;
    [SerializeField] float chaseSpeed;
    [SerializeField] float wait;


    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    SphereCollider biteZone;

    [Space(20)]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask playerLayer;

    //Patrol
    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float range;

    //Chase
    [SerializeField] float sightRange;
    bool playerInSight;

    //Attack
    [SerializeField] float attackRange;
    bool playerInAttackRange;
    public bool onAttack;

    //Get hit
    [SerializeField] float hp = 100;
    float dameAmount;

    public enum DemonDogState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        GotHit,
        Dead
    }
    public DemonDogState currentState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        biteZone = GetComponentInChildren<SphereCollider>();
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        currentState = DemonDogState.Idle;
    }

    private void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        switch (currentState)
        {
            case DemonDogState.Idle:
                Idle();
                break;

            case DemonDogState.Patrol:
                Patrol();
                break;

            case DemonDogState.Chase:
                Chase();
                break;

            case DemonDogState.Attack:
                Attack();
                break;

            case DemonDogState.GotHit:
                GotHit();
                break;

            case DemonDogState.Dead:
                Dead();
                break;
        }

        //if (!playerInSight && !playerInAttackRange && !onAttack) currentState = DemonDogState.Patrol;
        //if (playerInSight && !playerInAttackRange && !onAttack) currentState = DemonDogState.Chase;
        //if (playerInSight && playerInAttackRange) currentState = DemonDogState.Attack;
    }

    private void OnTriggerEnter(Collider other)
    { 
        var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Debug.Log("Hit!");
        }
    }

    //Enemy Behaviours
    #region Idle
    IEnumerator SwitchToPatrol(float n)
    {
        wait = n;
        yield return new WaitForSeconds(n);
        currentState = DemonDogState.Patrol;
    }
    public void Idle()
    {
        animator.Play("SniffsGround");
        StartCoroutine(SwitchToPatrol(wait));
    }
    #endregion
    #region Patrol
    public void Patrol()
    {
        agent.speed = patrolSpeed;
        animator.SetFloat("Speed", 0.5f);
        //random walk
        if (!walkPointSet)
        {
            SearchForDestination();
        }
        if (walkPointSet)
        {
            agent.SetDestination(destPoint);
        }
        if (Vector3.Distance(agent.transform.position, destPoint) < 3)
        {
            walkPointSet = false;
        }
    }
    public void SearchForDestination()
    {
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
    #endregion
    #region Chase
    public void Chase()
    {
        agent.speed = chaseSpeed;
        animator.SetFloat("Speed", 1);
        agent.SetDestination(player.transform.position);
    }
    #endregion
    #region Attack
    public void Attack()
    {


        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void EnableAttack()
    {
        onAttack = true;
        biteZone.enabled = true;
    }

    public void DisableAttack()
    {
        biteZone.enabled = false;
        onAttack = false;
    }
    #endregion
    #region GotHit
    public void GotHit()
    {
        
        hp -= dameAmount;
        if(hp <= 0)
        {
            Dead();
        }
        else
        {

        }
    }
    #endregion
    #region Dead
    public void Dead()
    {
        
    }
    #endregion
}
