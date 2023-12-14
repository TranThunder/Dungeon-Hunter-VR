using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject dialougePanel;
    public Text dialougeText;
    [SerializeField] string[] dialouge;
    [SerializeField] GameObject ButtonStart;
    [SerializeField] EnemySpawner[] enemySpawners;
    [SerializeField] GameObject KnightNPC;
    public GameObject portalWhite;
    public int index;
    public float wordspeed;
    public bool PlayerIsClose;
    bool IsTyping;
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
            PlayerIsClose = true;
            IsTyping = true;
            dialougePanel.SetActive(true);
            StartCoroutine(Typing());
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsTyping = false;
            PlayerIsClose = false;
            dialougePanel.SetActive(false);
            dialougeText.text = "";
            ButtonStart.SetActive(false);
        }
    }
    public IEnumerator Typing()
    {
        foreach(char letter in dialouge[index].ToCharArray())
        {
            if(IsTyping)
            {
                dialougeText.text += letter;
                yield return new WaitForSeconds(wordspeed);
            }
            
        }
        if (IsTyping)
        {
            ButtonStart.SetActive(true);
        }
        
    }
    public void StartDungeon()
    {
        foreach(EnemySpawner enemySpawner in enemySpawners)
        {
            enemySpawner.BeginSpawn();
        }
        KnightNPC.SetActive(false);
        dialougePanel.SetActive(false);
        portalWhite.GetComponent<ParticleSystem>().Play();
        portalWhite.GetComponent<BoxCollider>().enabled = true;
    }
}
