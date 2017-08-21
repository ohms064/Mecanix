using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneLoaderScriptable))]
public class LoadSceneAsyncScriptableEditor : SceneEditor {

    public override void OnInspectorGUI() {
        SceneLoaderScriptable script = target as SceneLoaderScriptable;

        script.sceneId = EditorGUILayout.Popup( "Scene To Load", script.sceneId, scenes );
        script.sceneLoader = EditorGUILayout.Popup( "Loading Screen Scene", script.sceneLoader, scenes );
        script.sceneSelector = EditorGUILayout.Popup( "Scene Selector", script.sceneSelector, scenes );
        script.sceneMenu = EditorGUILayout.Popup( "Main Menu", script.sceneMenu, scenes );

        GUILayout.Space( 5 );
        try {

            if ( GUILayout.Button( "Reload Scenes" ) ) {
                string sceneId = scenes[script.sceneId];
                string sceneLoader = scenes[script.sceneLoader];
                string sceneSelector = scenes[script.sceneSelector];
                string sceneMenu = scenes[script.sceneMenu];
                LoadScenes();
                script.sceneId = Find( sceneId );
                script.sceneLoader = Find( sceneLoader );
                script.sceneSelector = Find( sceneSelector );
                script.sceneMenu = Find( sceneMenu );
            }
        }catch(System.IndexOutOfRangeException e ) {
            LoadScenes();
        }

    }

    
}
