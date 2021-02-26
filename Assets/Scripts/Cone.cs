using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {
   
    private void OnTriggerEnter(Collider other) {
        if (other.transform.GetComponent<Jointer>()) {
            other.transform.GetComponentInChildren<Jointer>().cone = this;
            transform.SetParent(other.transform);
        }
    }
 
}
