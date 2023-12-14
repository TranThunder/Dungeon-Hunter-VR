using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject Boss;
    public Transform SpawnBossLocation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Wall.SetActive(true);
            Instantiate(Boss, SpawnBossLocation.position,Quaternion.identity);
            Destroy(GetComponent<TriggerBoss>());
           
        }
    }
}
