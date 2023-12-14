using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellDog : MonoBehaviour,IEnity
{
    // Start is called before the first frame update
    public int hp;
    Animator animator;
    BoxCollider boxCollider;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            animator.SetInteger("hp", hp);
            Destroy(boxCollider);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        animator.SetInteger("hp", hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
