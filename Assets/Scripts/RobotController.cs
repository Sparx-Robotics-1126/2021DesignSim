using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
 
    [SerializeField] WheelCollider[] wheels;
    [SerializeField] float rotation = 45;
    [SerializeField] float force = 20;
    [SerializeField] Jointer jointee;
    Jointer j;
    Cone c;


    void Update() {
        EditorHotkeys();
        RobotControls();
        Invoke("setKinematic", .01f);

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

        Vector3 pos = jointee.transform.position;
         if (Input.GetKey(KeyCode.R)) {
            if (pos.y <= 2) {
                pos.y += .01f;
                print(pos);
                jointee.transform.position = pos;
            }
        } else if (Input.GetKey(KeyCode.F)) {
            if (pos.y >= 0.1) {
                pos.y -= .01f;
                print(pos);
                jointee.transform.position = pos;
            }
        } else if (Input.GetKey(KeyCode.T)) {
            j = GetComponentInChildren<Jointer>();
            c = j.cone;
            c.GetComponent<Rigidbody>().isKinematic = false;
            c.GetComponent<Rigidbody>().useGravity = true;
            transform.GetComponentInChildren<Cone>().transform.SetParent(null);
            j.cone = null;
            c.transform.parent = null;
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
        transform.eulerAngles += newRot;
    }

   
    void setKinematic() {
        j = GetComponentInChildren<Jointer>();
        c = j.cone;
        if (c != null) {
            if (c.GetComponent<Rigidbody>().velocity == Vector3.zero) {
                c.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
