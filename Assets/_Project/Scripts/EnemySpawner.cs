using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] EnemyEnity;
    public int AmountEnemy;
    public int MaxEnemy;
    [SerializeField] float TimeBetweenTwoSpawn;
    [SerializeField] WaveController waveController;
    void Start()
    {
        
        waveController=FindObjectOfType<WaveController>();
        waveController.maxEnemy += MaxEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(TimeBetweenTwoSpawn);
        if (AmountEnemy < MaxEnemy)
        {
            Instantiate(EnemyEnity[waveController.WaveCount], transform.position, Quaternion.identity);
            AmountEnemy++;
            StartCoroutine(Spawn());
        }

    }
   
    public void BeginSpawn()
    {
        StartCoroutine(Spawn());
    }
}
