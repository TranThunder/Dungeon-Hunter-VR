using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MetalonBoss : MonoBehaviour,IEnity
{
    // Start is called before the first frame update
    public GameObject[] MetalonMinion;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public int hp;
    public int maxHP;
    public float TimeBetweenSpawn;
    public int currenEnemy;
    public int maxEnemy;
    public int damageToCastSkil1;
    public int maxDamageToCastSkill1;
    Animator animator;
    public int bac;
    public GameObject DamagePopUp;
    BoxCollider boxCollider;
    NavMeshAgent navMeshAgent;
    public bool Defend;
    public GameObject Player;
    public float StopDistance;
    public int damage;
    public GameObject Endportal;
    bool ATK;
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Spawn1 = GameObject.Find("BossSpawn1");
        Spawn2 = GameObject.Find("BossSpawn2");
        Endportal = GameObject.Find("Portalgreen");
        hp = maxHP;
        
    }


    // Update is called once per frame
    void Update()
    {
        if(!Defend&&!ATK)
        {
            if (((Player.transform.position - Player.GetComponent<CharacterController>().center) - transform.position).magnitude <= StopDistance && hp >= 0)
            {


                if (!navMeshAgent.isStopped)
                {
                    navMeshAgent.SetDestination(transform.position);
                    navMeshAgent.isStopped = true;
                    ATK = true;
                    animator.SetInteger("Blend", 3);

                }
            }
            else
            {
                if (hp >= 0)
                {
                    navMeshAgent.SetDestination((Player.transform.position - Player.GetComponent<CharacterController>().center));
                    navMeshAgent.isStopped = false;
                    animator.SetInteger("Blend", 1);

                }
            }
        }
        
    }
    public void Skill1()
    {
        StartCoroutine(SpawnMinion());
        damageToCastSkil1 = 0;
        animator.SetInteger("Blend", 5);
       
    }
  
    IEnumerator SpawnMinion()
    {
        Instantiate(MetalonMinion[Random.Range(0, 1)],Spawn1.gameObject.transform.position,Quaternion.identity);
        Instantiate(MetalonMinion[Random.Range(0, 1)],Spawn2.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(TimeBetweenSpawn);
        currenEnemy++;
        if(currenEnemy < maxEnemy)
        {
            StartCoroutine(SpawnMinion());
        }
        else
        {
            Defend= false;
        }
    }
    public void TakeDamage(int damage)
    {
        if(!Defend)
        {
            hp -= damage;
            damageToCastSkil1 += damage;
            var popup = Instantiate(DamagePopUp, transform.position, Quaternion.identity);
            popup.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            var temp = popup.GetComponentInChildren<TextMeshProUGUI>();
            temp.text = damage.ToString();
            if (hp >= maxHP / 5)
            {
                if (damageToCastSkil1 >= maxDamageToCastSkill1)
                {
                    Defend = true;
                    animator.SetInteger("Blend", 2);
                }
            }
            if (hp <= 0)
            {
                animator.SetInteger("Blend", 4);
                boxCollider.enabled=false;
                Endportal.GetComponent<BoxCollider>().isTrigger=true;
                Destroy(GetComponent<MetalonBoss>());

            }
        }
        
    }
    public void DealDamagePlayer()
    {
        Player.GetComponent<PlayerVR>().CurrentHP -= damage;
        ATK = false;
    }

}
