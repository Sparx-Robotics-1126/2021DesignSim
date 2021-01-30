using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChainParent : MonoBehaviour {
    public ChainLink firstLink;
    public ChainLink LastLink;
    public int length;

    public List<ChainLink> chains;

    public void SetUp() {
        chains = transform.GetComponentsInChildren<ChainLink>().ToList();
        firstLink = chains[0];
        LastLink = chains[chains.Count - 1];
        length = chains.Count;
    }
}
