using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberRobot : MonoBehaviour
{

    [SerializeField] Transform[] wheels;
    [SerializeField] float rotAmount = 20;

    void Update() {
        EditorHotkeys();
        RobotControls();


    }

    void EditorHotkeys() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UnityEditor.EditorApplication.isPlaying = false;
        } else if (Input.GetKeyDown(KeyCode.Y)) {
            UnityEditor.EditorApplication.isPaused = false;
        }
    }

    void RobotControls() {

        if (Input.GetKey(KeyCode.Q)) {
            WheelForce(true, rotAmount);
        } else if (Input.GetKey(KeyCode.A)) {
            WheelForce(true, -rotAmount);

        } 
        /*else {
            WheelForce(true, 0);
        }*/

        if (Input.GetKey(KeyCode.E)) {
            WheelForce(false, rotAmount);
        } else if (Input.GetKey(KeyCode.D)) {
            WheelForce(false, -rotAmount);
        } 
        /*else {
            WheelForce(false, 0);
        }*/
    }

    void WheelForce(bool left, float amount) {
        if (left) {
            Vector3 newRot = wheels[0].transform.rotation.eulerAngles;
            newRot.x += rotAmount * Time.deltaTime;
            wheels[0].eulerAngles = newRot;
            wheels[1].eulerAngles = newRot;
        } else {
            Vector3 newRot = wheels[2].transform.rotation.eulerAngles;
            newRot.x += rotAmount * Time.deltaTime;
            wheels[2].eulerAngles = newRot;
            wheels[3].eulerAngles = newRot;
        }
    }
}
