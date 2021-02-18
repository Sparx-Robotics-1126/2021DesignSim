using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("kekw");
        if (other.transform.GetComponent<Jointer>())
        {
            other.transform.GetComponentInChildren<Jointer>().cone = this;
            transform.SetParent(other.transform);
            print("lolz");
        }
    }
    
}
