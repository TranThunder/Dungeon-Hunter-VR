using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int numberOfEnemy;
    [SerializeField] private float xMin, xMax;
    [SerializeField] private float zMin, zMax;
    [SerializeField] private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        Debug.Log("spawnEnemy");
        while (enemyCount < numberOfEnemy)
        {
            var xPos = Random.Range(xMin, xMax);
            var zPos = Random.Range(zMin, zMax);
            GameObject enemy = ObjectPool.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = new Vector3(xPos, 0, zPos);
                Debug.Log("spawn");
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(2);
            enemyCount++;

        }
    }
}
