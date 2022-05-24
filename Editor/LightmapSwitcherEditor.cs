using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;



[CustomEditor(typeof(LightmapSwitcher))]
public class LightmapSwitcherEditor : Editor
{

    public ProbeData dataToFill;
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        dataToFill = EditorGUILayout.ObjectField("", dataToFill, typeof(ProbeData), true) as ProbeData;
        if (GUILayout.Button("Save current Probes to asset")) 
        { 
            if(dataToFill == null)
            {
                Debug.LogWarning("Error: ProbeData asset not asigned");
            }
            else
            {
                dataToFill.SerializeLightProbes(LightmapSettings.lightProbes.bakedProbes);
                EditorUtility.SetDirty(dataToFill);
            }
         }
}
}
