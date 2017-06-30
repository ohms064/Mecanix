using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BuildLightmapScene {
	
	static string GetScenePathOrThrow (Object obj)
	{
		string path = AssetDatabase.GetAssetPath(obj);
		if (!path.EndsWith(".unity"))
			throw new System.Exception("You must select a set of scenes to multi bake them");
		return path;
	}
	
	
	[MenuItem ("Build/Bake Multiple levels")]
	static void BuildTest ()
	{
		var paths = new List<string> ();
		paths.Add (GetScenePathOrThrow (Selection.activeObject));
		foreach(var obj in Selection.objects)
		{
			string path = GetScenePathOrThrow (obj);
			if (path != paths[0])
				paths.Add (path);
		}
		
		Lightmapping.BakeMultipleScenes (paths.ToArray());


	}
}