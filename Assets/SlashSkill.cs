using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SlashSkill : MonoBehaviour
{
    ParticleSystem _particleSystem;
    public float timeTriggerDamage;
    BoxCollider SlashCollider;
    public bool EndOfFrame;
    public int DamageSkill;
    public bool onSkillActive;
    AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        SlashCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Upgrade()
    {
        if(gameObject.activeInHierarchy)
        {
            DamageSkill += 2;
        }
        
    }
    private void FixedUpdate()
    {
        
       if(_particleSystem.time>=timeTriggerDamage)
       {
            if(!onSkillActive)
            {
                onSkillActive = true;
                SlashCollider.enabled = true;
                audioSource.PlayOneShot(clip);
            }
            
       }
       else
       {
            if(onSkillActive)
            {
                SlashCollider.enabled = false;
                onSkillActive = false;
                
            }
             
       }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            if(onSkillActive==true)
            {
                IEnity damage = other.GetComponent<IEnity>();
                damage.TakeDamage(DamageSkill);
                if(!EndOfFrame)
                {
                    StartCoroutine(RechargeSkill());
                }
            }
        }
    }
    IEnumerator RechargeSkill()
    {
        EndOfFrame = true;
        yield return new WaitForEndOfFrame();
        SlashCollider.enabled = false;

    }

}
