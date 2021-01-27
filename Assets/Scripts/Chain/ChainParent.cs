using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainParent : MonoBehaviour {
    public ChainLink firstLink;
    public ChainLink LastLink;

     public int length;
    public void SetUp() {
        ChainLink[] chains = transform.GetComponentsInChildren<ChainLink>();
        firstLink = chains[0];
        LastLink = chains[chains.Length - 1];
        int length = chains.Length;
    }
}
