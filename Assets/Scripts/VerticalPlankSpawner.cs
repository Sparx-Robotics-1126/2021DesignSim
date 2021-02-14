using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlankSpawner : MonoBehaviour {
    Animator animator;
    [SerializeField] AnimationClip push;
    [SerializeField] Plank plankPrefab;
    [SerializeField] Transform spawnPoint;

    bool spawn = true;

    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other) {
        //if(other.GetComponent<RobotController>() && !animator.GetCurrentAnimatorClipInfo(0)[0].clip.Equals(push)) {
        print(animator.GetCurrentAnimatorClipInfoCount(0));
        if(other.GetComponent<RobotController>() && (animator.GetCurrentAnimatorClipInfoCount(0) == 0) && spawn) {
            Plank p = SpawnPlank();
            Rigidbody rb = p.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
          //  spawn = false;
           animator.SetTrigger("push plank");
            
        }
    }

    Plank SpawnPlank() {
        print("spawn plank");
        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0, 0, 90);
        return Instantiate(plankPrefab, spawnPoint.position, rot);
    }
}
