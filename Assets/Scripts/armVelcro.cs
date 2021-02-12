using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armVelcro : MonoBehaviour {
    // Start is called before the first frame update
    bool pickedUp = false;
    private Plank p;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //        print("on trigger enter");
        if (p) pickedUp = p.pickedUp;
        if (!pickedUp && other.TryGetComponent<Plank>(out p) && !p.placed) {
            //          print("added velcro");
            pickedUp = true;
            p.pickedUp = true;
            p.transform.parent = transform;
            p.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

   
}
