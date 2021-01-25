using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCreator : MonoBehaviour {
    public GameObject firstLink;
    public GameObject LastLink;

    [SerializeField] int length;
    [SerializeField] GameObject chain;
    [SerializeField] Rigidbody moveBody;
    [SerializeField] FixedJoint attatchedBody;
    [SerializeField] float chainDistance = 0.12f;

    int i;

    private void Awake() {
        i = length - 1;
        GameObject obj =  Instantiate(chain, transform.position, transform.rotation, transform);
        obj.transform.name = "chain link + " + (length - i);
        obj.GetComponent<CharacterJoint>().connectedBody = moveBody;
        firstLink = obj;
        CreateLink(obj.transform);
    }
    private void CreateLink(Transform previous) {
        i--;
        Quaternion newRot = Quaternion.identity;
        newRot.eulerAngles = previous.eulerAngles + new Vector3(90, 0, 0);
        Vector3 newPos = previous.position + new Vector3(chainDistance, 0, 0);
        GameObject temp = Instantiate(previous.gameObject,newPos, newRot,previous);
        temp.transform.name = "chain link " + (length - i);
        temp.GetComponent<CharacterJoint>().connectedBody = previous.GetComponent<Rigidbody>();

        if (i > 0) {
            CreateLink(temp.transform);
        } else {
            LastLink = temp;
          //  attatchedBody.connectedBody = temp.GetComponent<Rigidbody>();
           // attatchedBody.transform.position = temp.transform.position + new Vector3(chainDistance * 2, 0, 0);
        }
    }
}
