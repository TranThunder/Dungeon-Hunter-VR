using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class VRModelRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;
    public Transform headConstraint;
    public Vector3 headBodyOffest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = headConstraint.position + headBodyOffest;
        //rotation ccua head constraint la eulerangle nen sai euler
        transform.rotation = Quaternion.Euler(transform.rotation.x,headConstraint.eulerAngles.y,transform.rotation.z);
        Debug.Log(headConstraint.eulerAngles);
       
       
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
       
}
[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;
    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}



