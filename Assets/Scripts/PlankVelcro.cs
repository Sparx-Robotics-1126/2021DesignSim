using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankVelcro : MonoBehaviour {
    public bool placed= false;

    public void ClearParent() {
        Transform p = transform.parent;
        print(p);
        p.parent = null;
    }
    private void Start() {
        print(GetComponentInParent<Rigidbody>());
    }
    /*  [SerializeField] Plank plank;

      [SerializeField] float breakForce;*/
    /*  private void OnTriggerEnter(Collider other) {
          if (other.GetComponent<PostVelcro>()) {
              print("added velcro");
              PostVelcro p = other.GetComponent<PostVelcro>();
              FixedJoint joint = plank.gameObject.AddComponent<FixedJoint>();
              joint.breakForce = breakForce;
              joint.connectedBody = other.GetComponentInParent<Rigidbody>();
              joint.connectedAnchor = transform.localPosition;
          }
      }*/


}
