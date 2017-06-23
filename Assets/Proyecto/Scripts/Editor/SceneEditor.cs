using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;

public class SceneEditor:Editor {
    protected string[] scenes;
    private void OnEnable() {
        LoadScenes();
    }

    protected void LoadScenes() {
        scenes = (from scene in EditorBuildSettings.scenes where scene.enabled select GetSceneName( scene )).ToArray();
        EditorUtility.SetDirty( target );
    }


    string GetSceneName( EditorBuildSettingsScene scene ) {
        string output;
        int index = scene.path.LastIndexOf( '/' );
        output = scene.path.Substring( index + 1 );
        int index2 = output.LastIndexOf( "." );
        output = output.Substring( 0, index2 );
        return output;
    }

    protected int Find( string str ) {
        for ( int i = 0; i < scenes.Length; i++ ) {
            if ( scenes[i].Equals( str ) ) {
                return i;
            }
        }
        return 0;
    }
}

