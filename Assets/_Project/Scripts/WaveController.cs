using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WaveController : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentEnemy;
    public int maxEnemy;
    public int WaveCount;
    public GameObject portalWhite;
    public GameObject[] WaveWall;
    public GameObject KnightNpc;
    public NPC Knight;
    public EnemySpawner[] enemySpawner;
    public GameObject UpgradeMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckEnemy()
    {
        currentEnemy += 1;
        if (currentEnemy >= maxEnemy)
        {
            portalWhite.GetComponent<ParticleSystem>().Stop();
            portalWhite.GetComponent<BoxCollider>().enabled = false;
            WaveCount++;
            UpgradeMenu.SetActive(true);
            foreach (GameObject wall in WaveWall)
            {
                if (wall == WaveWall[WaveCount-1])
                {
                    wall.SetActive(false);
                }
                else wall.SetActive(true);
            }
            
            if(WaveCount<=2)
            {

                KnightNpc.SetActive(true);
                Knight.dialougeText.text = "";
                Knight.index += 1;
                
            }
            else
            {
                KnightNpc.SetActive(false);
            }
            
            currentEnemy = 0;
            maxEnemy = 0;
            foreach(EnemySpawner en in enemySpawner)
            {
                en.MaxEnemy += 15;
                en.AmountEnemy = 0;
                maxEnemy += en.MaxEnemy;
            }
        }
        
    }
}
