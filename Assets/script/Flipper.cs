using System;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private HingeJoint2D myHingeJoint;
    private void Start()
    {
        myHingeJoint = GetComponent<HingeJoint2D>();
        if(myHingeJoint == null)
        {
            Debug.Log("myHingeJoint is null");
        }
    }
    void Update()
    {
        myHingeJoint.useMotor = Input.GetKeyDown(KeyCode.K);
    }
}