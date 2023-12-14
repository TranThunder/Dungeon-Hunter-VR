using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.AI;

public class EnemySwarm : MonoBehaviour,IEnity
{
    // Start is called before the first frame update
    NavMeshAgent navMesh;
    public GameObject Player;
    public float StopDistance;
    public int hp;
    public int damage;
    public int TimeBeforeDestroyTheBody;
    Animator animator;
    BoxCollider boxCollider;
    public SkinnedMeshRenderer Skin;
    public Material FlashHitMaterial;
    public Material OriginMaterial;
    public float FlashHitTime;
    public GameObject DamagePopUp;
    WaveController waveController;
    bool ATK;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        OriginMaterial = Skin.material;
        waveController=FindObjectOfType<WaveController>();
        boxCollider=GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ATK)
        {
            if (((Player.transform.position - Player.GetComponent<CharacterController>().center) - transform.position).magnitude <= StopDistance && hp >= 0)
            {


                if (!navMesh.isStopped)
                {
                    ATK = true;
                    navMesh.SetDestination(transform.position);
                    navMesh.isStopped = true;
                    animator.SetBool("move", false);
                    animator.SetBool("attack", true);
                }
            }
            else
            {
                if (hp >= 0)
                {
                    navMesh.SetDestination(Player.transform.position-Player.GetComponent<CharacterController>().center);
                    navMesh.isStopped = false;
                    animator.SetBool("move", true);
                    animator.SetBool("attack", false);
                }

            }

        }

    }


    public void TakeDamage(int damage)
    {
        hp -= damage;
        var popup=Instantiate(DamagePopUp,transform.position,Quaternion.identity);
        popup.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        var temp=popup.GetComponentInChildren<TextMeshProUGUI>();
        temp.text = damage.ToString();
        FlashStart();
        StartCoroutine(FlashEnd());
        if (hp<=0)
        {
            boxCollider.enabled = false;
            animator.SetBool("die", true);
            waveController.CheckEnemy();
            StartCoroutine(DestroyEnemy());
        }
    }
    public void FlashStart()
    {
        Skin.material = FlashHitMaterial;
    }
    public void DealDamagePlayer()
    {
        Player.GetComponent<PlayerVR>().CurrentHP -= damage;
        ATK = false;
    }
    IEnumerator FlashEnd()
    {
        yield return new WaitForSeconds(FlashHitTime);
        Skin.material = OriginMaterial;

    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(TimeBeforeDestroyTheBody);
        Destroy(this.gameObject);   
    }
   

   
}
