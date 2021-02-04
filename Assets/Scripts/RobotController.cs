using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
 
    [SerializeField] WheelCollider[] wheels;
    [SerializeField] float rotation = 45;
    [SerializeField] float force = 20;

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

        if(Input.GetKey(KeyCode.W)) {
            WheelForce( force);
        } else if(Input.GetKey(KeyCode.S)) {
            WheelForce( -force);
        } else {
            WheelForce( 0);
        }

        Rotate();
    }

    void WheelForce(float amount) {
         foreach(WheelCollider wheel in wheels) {
             wheel.motorTorque = amount * Time.deltaTime;
        }
    }

    void Rotate() {
        Vector3 newRot = new Vector3(0, rotation, 0) * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        //if(newRot.y != 0)  newRot *= Input.GetAxisRaw("Vertical");//to make backing up and turning more intuitive
        
        transform.eulerAngles += newRot;
        print(Input.GetAxisRaw("Vertical"));
    }

    void DebugLines() {
      //  Debug.DrawRay(rbs[0].transform.position,tr);
        //Debug.DrawRay(rbs[1].transform.position,transform.f);
    }
}
