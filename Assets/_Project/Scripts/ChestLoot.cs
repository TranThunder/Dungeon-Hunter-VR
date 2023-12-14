using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLoot : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerVR player;
    public GameObject UpgradeMenu;
    void Start()
    {
        player= FindObjectOfType<PlayerVR>();
        UpgradeMenu = player.UpMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Bullet")
        {
            int percent = Random.Range(0, 100);
            if(percent > 0 &&percent<=25)
            {
                UpgradeMenu.SetActive(true);
            }
            if(percent > 25 && percent <= 80)
            {
                player.CurrentHP += 20;
                if(player.CurrentHP > player.MaxHP)
                {
                    player.CurrentHP = player.MaxHP;
                }
            }

            Destroy(gameObject);
        }
    }
}
