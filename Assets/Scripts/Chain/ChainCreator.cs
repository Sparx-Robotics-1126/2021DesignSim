using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class ChainCreator : MonoBehaviour  {
    [SerializeField] int length;
    [SerializeField] ChainLink chain;
    [SerializeField] ChainParent chainParentPrefab;
    [SerializeField] string parentName;
    [SerializeField] Rigidbody moveBody;
    [SerializeField] float chainDistance = 0.12f;

    int i;
    Transform chainParent;
    int namingInt = 1;

    public void ResetName() {
        namingInt = 1;
       // ChainParent[] chains= FindObjectsOfType<ChainParent>();
       List<ChainParent> chains= FindObjectsOfType<ChainParent>().ToList();
        chains.Reverse();

        foreach(ChainParent chain in chains) {
            chain.name = parentName + "  " +  namingInt;
            namingInt++;
        }
        namingInt = 1;
    }
    public void CreateChain() {
        i = length - 1;

        chainParent = Instantiate(chainParentPrefab, transform.position, Quaternion.identity).transform;
        chainParent.name = parentName + "  " + namingInt;
        namingInt++;

        GameObject obj =  Instantiate(chain, transform.position, transform.rotation, chainParent).gameObject;
        obj.transform.name = "chain link " + (length - i);
        obj.GetComponent<CharacterJoint>().connectedBody = moveBody;
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
