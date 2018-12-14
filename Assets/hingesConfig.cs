using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hingesConfig : MonoBehaviour {

    public int speed;
    public int force;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        UpdateHingeMotor();
	}

    void UpdateHingeMotor () {
        HingeJoint[] hinges = GetComponents<HingeJoint>();
        for (int i = 0; i < hinges.Length; i++)
        {
            JointMotor motor = hinges[i].motor;
            motor.force = force;
            motor.targetVelocity = speed;
            hinges[i].motor = motor;
        }
    }
}
