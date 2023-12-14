using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerVR : MonoBehaviour
{
    public InputActionProperty RightTriggerButton;
    public InputActionProperty LeftSecondaryButton;
    public GameObject UpMenu;
    public GameObject MagicBullet;
    public Transform Wand;
    public Transform MagicWandHeadPosition;
    public int PlayerDamage;
    public bool IsPlaying;
    public Image FullHealthHud;
    public Image MidHealthHUd;
    public float MaxHP;
    public float CurrentHP;
    public GameObject Menu;
    public GameObject StaffAura;
    public GameObject PauseMenu;
    public ParticleSystem trailStaff;
    int staffTrailmem;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CurrentHP = MaxHP;
        staffTrailmem = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (CurrentHP > 0)
        {
            FullHealthHud.fillAmount = CurrentHP / MaxHP;
            if (FullHealthHud.fillAmount <= 0.5f)
            {
                MidHealthHUd.fillAmount = FullHealthHud.fillAmount * 2;
            }
            else
            {
                MidHealthHUd.fillAmount = 1;
            }
            //
            if (RightTriggerButton.action.triggered)
            {
                if (IsPlaying)
                {
                    Instantiate(MagicBullet, MagicWandHeadPosition.position, Wand.rotation * Quaternion.Euler(-90, 0, 0));
                }

            }
            if(LeftSecondaryButton.action.triggered)
            {
                if(!PauseMenu.activeInHierarchy)
                {
                    PauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    PauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
                
            }
            
        }
        else
        {
            Time.timeScale = 0;
            Menu.SetActive(true);
            Destroy(GetComponent<PlayerVR>());
        }
        

    }
    
    public void UpgradeStrength()
    {
        PlayerDamage += 2;
        MaxHP += 20;
        CurrentHP = MaxHP;
        StaffAura.SetActive(true);
        if(staffTrailmem<15)
        {
            staffTrailmem += 5;
            var emis = trailStaff.emission;
            emis.rateOverTime = staffTrailmem;
            
        }
        
    }
}
