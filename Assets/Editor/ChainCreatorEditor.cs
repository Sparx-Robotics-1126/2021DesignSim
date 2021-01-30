using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChainCreator))]
public class ChainCreatorEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        ChainCreator creator = (ChainCreator)target;
        if(GUILayout.Button("Create Chain")) {
            creator.CreateChain();
        }
    }
}
