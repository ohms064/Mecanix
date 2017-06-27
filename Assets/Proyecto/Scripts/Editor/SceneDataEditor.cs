using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneData))]
public class SceneDataEditor : SceneEditor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        SceneData script = target as SceneData;

        script.sceneId= EditorGUILayout.Popup( "Scene To Load", script.sceneId, scenes );

        GUILayout.Space( 5 );

        if ( GUILayout.Button( "Reload Scenes" ) ) {
            string sceneToLoad1;
            if ( script.sceneId >= scenes.Length ) {
                script.sceneId = 0;
                Debug.LogError( string.Format( "Error en el Componente LoadSceneSetter del objeto {1}", script.name ) );
            }

            sceneToLoad1 = scenes[script.sceneId];

            LoadScenes();

            int newScene = Find( sceneToLoad1 );

            if ( newScene != script.sceneId ) {
                Debug.LogWarningFormat( "El id de los datos {0} cambió", script.name );
            }


            script.sceneId = newScene;
        }
    }
}
