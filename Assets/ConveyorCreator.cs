using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorCreator : MonoBehaviour {

    public float rolls = 4;
    public int force = 50;
    public int targetVelocity = 250;

    private GameObject conveyorBelt;
    
    // Use this for initialization
    void Start () {
        conveyorBelt = new GameObject("Conveyor Belt");
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(rolls / 2f, 0.5f, 0.5f);
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.isKinematic = true;

        cube.transform.SetParent(conveyorBelt.transform);

        for (int i = 0; i < rolls; ++i) {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            Quaternion quat = cylinder.transform.rotation;
            quat.eulerAngles = new Vector3(90, 0, 0);
            cylinder.transform.localScale = new Vector3(0.5f, 3, 0.5f);
            cylinder.transform.rotation = quat;
            float x = -(rolls - 1) / 4f + i * 0.5f;
            cylinder.transform.position = new Vector3(x, 0,3.25f);
            Rigidbody cylRb = cylinder.AddComponent<Rigidbody>();

            HingeJoint hinge = cube.AddComponent<HingeJoint>();
            hinge.autoConfigureConnectedAnchor = true;
            hinge.useMotor = true;
            hinge.connectedBody = cylRb;
            hinge.axis = new Vector3(0, 0, 1);
            hinge.anchor = new Vector3(x/(rolls / 2f), 0, 0.5f);
            JointMotor motor = hinge.motor;
            motor.force = force;
            motor.targetVelocity = targetVelocity;
            hinge.motor = motor;


            cylinder.transform.SetParent(conveyorBelt.transform);
        }


        conveyorBelt.transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateHingeMotor();
    }

    void UpdateHingeMotor()
    {
        HingeJoint[] hinges = conveyorBelt.GetComponents<HingeJoint>();
        for (int i = 0; i < hinges.Length; i++)
        {
            JointMotor motor = hinges[i].motor;
            motor.force = force;
            motor.targetVelocity = targetVelocity;
            hinges[i].motor = motor;
        }
    }
}
