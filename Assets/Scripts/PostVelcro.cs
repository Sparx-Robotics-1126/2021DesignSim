using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostVelcro : MonoBehaviour {
    private bool attatched = false;
    private void OnTriggerEnter(Collider other) {
        if (!attatched) {
              print("on trigger enter");
            PlankVelcro plankVelcro;
            if (other.TryGetComponent<PlankVelcro>(out plankVelcro)) 
                {
                attatched = true;
                Plank p = plankVelcro.transform.parent.GetComponent<Plank>();
                print(p);
                p.transform.parent = null;
                p.transform.name = "testing 111111111111111111111111";
                p.pickedUp = false;
                p.placed = true;
                print("is kinimatic off");
                p.GetComponent<Rigidbody>().isKinematic = false;
                print(p.transform.parent);
            } 
        }
    }
}

