using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    public int Damage;
    public PlayerVR player;
    // Start is called before the first frame update

    void Start()
    {
        player = FindObjectOfType<PlayerVR>();
        Damage = player.PlayerDamage;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            IEnity damage = other.gameObject.GetComponent<IEnity>();
            if (damage != null)
            {
                damage.TakeDamage(Damage);
            }
            StartCoroutine(Desytroy());
        }
    }
    IEnumerator Desytroy()
    {
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
}
