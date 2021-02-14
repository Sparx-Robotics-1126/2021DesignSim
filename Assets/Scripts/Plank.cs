using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour {
    public bool placed = false;
    public bool pickedUp = false;
    private static int namingNum = 1;

    private void Start() {
        transform.name = "Plank " + namingNum;
        namingNum++;
    }
}
