using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
 
    [SerializeField] WheelCollider[] wheels;
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
        Vector3 pos = jointee.transform.position;
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
        } else if (Input.GetKey(KeyCode.D)) {
            WheelForce(false, -force);
        }

        else if (Input.GetKey(KeyCode.R))
        {
            if (pos.y <= 2) 
            {
                pos.y += .01f;
                print(pos);
                jointee.transform.position = pos;
            }
        }
        else if (Input.GetKey(KeyCode.F))
        {
            if (pos.y >= 0.1)
            {
                pos.y -= .01f;
                print(pos);
                jointee.transform.position = pos;
            }
        }
        else if (Input.GetKey(KeyCode.T))
        {
            
            j = GetComponentInChildren<Jointer>();
            c = j.cone;
            c.GetComponent<Rigidbody>().isKinematic = false;
            c.GetComponent<Rigidbody>().useGravity = true;
            transform.GetComponentInChildren<Cone>().transform.SetParent(null);
            //The problem going down in town is that it isnt changing is Kinematic to false so the cone isnt falling. The child is trying to be access by its grandparents not just parents
            j.cone = null;
            c.transform.parent = null;
            
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
//print("right force " + amount);

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
    void setKinematic()
    {
        j = GetComponentInChildren<Jointer>();
        c = j.cone;
        if (c != null)
        {
            if (c.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                c.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
