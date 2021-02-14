using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSpawner : MonoBehaviour {
    [SerializeField] Plank plankPrefab;
    [SerializeField] float waitTime;
    
    bool hasPlank = false;
    bool instantiatePlank = false;
    float time = 0;
   
    void FixedUpdate() {
        if (instantiatePlank && time <= 0) {
            //print("instatiate");
            instantiatePlank = false;
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 90, 0); 
            Instantiate(plankPrefab, transform.position,rot);
            time += 0.05f;//to avoid setting instatiatePlank true because of execution order
        }

        if (!hasPlank && time <= 0) {
        //    print("start instantiate");
            hasPlank = true;
            time = waitTime;
            instantiatePlank = true;
        }

        if(time > 0) {
            time -= Time.deltaTime;
        }


        hasPlank = false;
    }

    private void OnTriggerStay(Collider other) {
        hasPlank = true;
    }
}
