using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsAOE : MonoBehaviour
{
    // Start is called before the first frame update
    public int Radius;
    public float TimeBetweenDealDamage;
    public int Damage;
    public GameObject Player;
    ParticleSystem particle;
    BoxCollider boxCollider;
    bool EndOfFrame;
    AudioSource audioSource;
    public AudioClip clip;
    public float yOffSet;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider>();
        StartCoroutine(ChangeLocation());
        StartCoroutine(CastSkill());
        audioSource = GetComponent<AudioSource>();
    } 

    // Update is called once per frame
    void Update()
    {
       
      
    }
    public void Urgade()
    {
        if (gameObject.activeInHierarchy)
        {
            Damage += 2;
        }
    }
    IEnumerator CastSkill()
    {

        yield return new WaitForSeconds(TimeBetweenDealDamage);
        if(particle.time<3.25f&&particle.time>0.4f)
        {
            StartCoroutine(Wait());
            if (particle.time < 2.5f) 
            {
                audioSource.PlayOneShot(clip);
            }
            
        }
       
        
        StartCoroutine(CastSkill());
    }
    IEnumerator Wait()
    {
        boxCollider.enabled = true;

       yield return new WaitForSeconds(0.25f);
        
        boxCollider.enabled = false;
    }
    IEnumerator ChangeLocation()
    {
        float xRandom=Random.Range(0, Radius);
        float zRandom=Random.Range(0, Radius);
        transform.position=new Vector3(xRandom+Player.transform.position.x, Player.transform.position.y+yOffSet, zRandom+ Player.transform.position.z)-Player.GetComponent<CharacterController>().center;
        yield return new WaitForSeconds(particle.main.duration);
        StartCoroutine(ChangeLocation());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IEnity damage = other.gameObject.GetComponent<IEnity>();
            if (damage != null)
            {
                damage.TakeDamage(Damage);
                Debug.Log("ok");
            }
        }
    }
}
