using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DoorDescriptor))]
public class DoorDescriptorEditor : SceneEditor {
    

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        DoorDescriptor script = target as DoorDescriptor;

        script.leftScene = EditorGUILayout.Popup( "Scene Left To Load", script.leftScene, scenes );
        script.rightScene = EditorGUILayout.Popup( "Scene Right To Load", script.rightScene, scenes );

        GUILayout.Space( 5 );

        if ( GUILayout.Button( "Reload Scenes" ) ) {
            string sceneToLoad1, sceneToLoad2;
            if ( script.leftScene >= scenes.Length ) {
                script.leftScene = 0;
                Debug.LogError( string.Format( "Error en el Componente LoadSceneSetter del objeto {1}", script.label ) );
            }

            if ( script.rightScene >= scenes.Length ) {
                script.rightScene = 0;
                Debug.LogError( string.Format( "Error en el Componente LoadSceneSetter del objeto {1}", script.label ) );
            }
            sceneToLoad1 = scenes[script.leftScene];
            sceneToLoad2 = scenes[script.rightScene];

            LoadScenes();
            script.leftScene = Find( sceneToLoad1 );
            script.leftScene = Find( sceneToLoad2 );
        }

    }

}
