using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ChainCreator : MonoBehaviour  {
    [SerializeField] int length;
    [SerializeField] ChainLink chain;
    [SerializeField] ChainParent chainParentPrefab;
    [SerializeField] Rigidbody moveBody;
    [SerializeField] float chainDistance = 0.12f;

    int i;
    Transform chainParent;
    int namingInt = 1;
    public void CreateChain() {
        i = length - 1;

        chainParent = Instantiate(chainParentPrefab, transform.position, Quaternion.identity).transform;
        chainParent.name = "Chain Parent " + namingInt;
        namingInt++;

        GameObject obj =  Instantiate(chain, transform.position, transform.rotation, chainParent).gameObject;
        obj.transform.name = "chain link " + (length - i);
        //Destroy(obj.GetComponent<CharacterJoint>());
       // if(moveBody != null) obj.GetComponent<CharacterJoint>().connectedBody = moveBody;

        CreateLink(obj.transform);

        chainParent.GetComponent<ChainParent>().SetUp();
    }
    private void CreateLink(Transform previous) {
        i--;

        Quaternion newRot = Quaternion.identity;
        newRot.eulerAngles = previous.eulerAngles + new Vector3(90, 0, 0);
        Vector3 newPos = previous.position + new Vector3(chainDistance, 0, 0);
        GameObject temp = Instantiate(previous.gameObject,newPos, newRot,chainParent);
        temp.transform.name = "chain link " + (length - i);
        temp.GetComponent<CharacterJoint>().connectedBody = previous.GetComponent<Rigidbody>();

        if (i > 0) {
            CreateLink(temp.transform);
        } 
    }
}
