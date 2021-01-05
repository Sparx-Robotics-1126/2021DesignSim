using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
   //  JointMotor[] wheels; //0-1 left  2-3 right
    //  [SerializeField] HingeJoint[] joints; //0-1 left  2-3 right
    //[SerializeField] Rigidbody[] rbs;
    [SerializeField] WheelCollider[] wheels;
    [SerializeField] float force = 20;

    //Vector3 forceVector = Vector3.one;
    private void Start() {
        //print(joints.Length);
       /* wheels = new JointMotor[joints.Length];
        for(int i = 0; i < joints.Length; i++) {
            wheels[i] = joints[i].motor;
            //print(wheels[i]);
        }*/
        
    }

    void Update() {
        EditorHotkeys();
        RobotControls();


    }

    void EditorHotkeys() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            UnityEditor.EditorApplication.isPlaying = false;
        } else if(Input.GetKeyDown(KeyCode.Y)) {
            UnityEditor.EditorApplication.isPaused = false;
        }
    }
    
    void RobotControls() {

        if(Input.GetKey(KeyCode.Q)) {
            WheelForce(true, force);
        } else if(Input.GetKey(KeyCode.A)) {
            WheelForce(true, -force);

        }
        else
        {
            WheelForce(true, 0);
        }

        if (Input.GetKey(KeyCode.E)) {
            WheelForce(false, force);
        } else if (Input.GetKey(KeyCode.D)){
            WheelForce(false, -force);
        }
        else
        {
            WheelForce(false, 0);
        }
    }

    void WheelForce(bool left, float amount) {
        if(left) {
             // print(wheels[1] + " force");
              wheels[0].motorTorque = amount * Time.deltaTime;
              wheels[1].motorTorque = amount * Time.deltaTime;
            //rbs[0].AddForce(rbs[0].transform.right * amount * Time.deltaTime);
        } else {
           //  print(wheels[3] + " force");
             wheels[2].motorTorque = amount * Time.deltaTime;
             wheels[3].motorTorque = amount * Time.deltaTime;
            //rbs[1].AddForce(rbs[1].transform.right * amount * Time.deltaTime);
        }
    }

    void DebugLines() {
      //  Debug.DrawRay(rbs[0].transform.position,tr);
        //Debug.DrawRay(rbs[1].transform.position,transform.f);
    }
}
