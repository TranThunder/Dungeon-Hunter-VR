using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TestDoll : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController controller;
    public GameObject cameraa;
    public float speed;
    float mouseX,mouseY;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        controller.Move(new Vector3(x,0,z)*Time.deltaTime);
         mouseX += Input.GetAxisRaw("Mouse X");
         mouseY += Input.GetAxisRaw("Mouse Y");
        cameraa.transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
    }
}
