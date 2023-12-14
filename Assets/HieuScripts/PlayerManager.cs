using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    MoveInput moveInput;
    Rigidbody rb;
   
    public enum Playerstate
    {
        Moving,
        Idle,
        Dead
    }
    public Playerstate state;
    void Start()
    {
        //state = Playerstate.Idle;
        //rb=GetComponent<Rigidbody>();
        moveInput = new MoveInput();
        moveInput.Enable(); //enable input action class de chay ,  ko enable ko chay dc
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveMent() //di chuyen nguoi choi
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = moveInput.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
        Debug.Log(moveDirection);
        if(moveDirection.magnitude>0.1f)
        {
            rb.velocity = new Vector3(moveDirection.x,rb.velocity.y,moveDirection.y);
        }
        
    }
}
