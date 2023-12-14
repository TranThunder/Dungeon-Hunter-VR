using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerportal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Portal portal;
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
            portal.OpenPortal();
        }
        Destroy(this.gameObject);
    }
}
