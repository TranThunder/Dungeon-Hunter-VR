using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform Player;
    public float yoffSet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position-characterController.center+new Vector3(0,yoffSet,0);
        
    }
}
