using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingDrum : MonoBehaviour{
    [SerializeField] float spinSpeed;
    [SerializeField] new HingeJoint hingeJoint;

    public bool spinMotor;
    JointMotor spinningMotor;
    JointMotor stopMotor;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        spinningMotor.targetVelocity = spinSpeed;
        spinningMotor.force = 500;
     }

     void FixedUpdate() {
        if (spinMotor) {
            hingeJoint.motor = spinningMotor;
            hingeJoint.useLimits = false;
        } else {
            hingeJoint.motor = stopMotor;
            rb.angularVelocity = Vector3.zero;
            
            hingeJoint.useLimits = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        Transform parent = other.transform.parent;
        print("on trigger enter");
        if (parent && !parent.GetComponent<FixedJoint>() && parent.GetComponent<ChainLink>()) {
            FixedJoint joint = parent.gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = GetComponent<Rigidbody>();
        }
    }
}
