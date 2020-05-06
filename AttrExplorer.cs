using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

// If you toggle the toggle_me it will print a bunch of attributes in the UnityEngine and UnityEditor assembly.
// You may find something new an interesting, including stuff that isn't documented.

[ExecuteInEditMode]
public class FindAttr : MonoBehaviour
{
	public bool toggle_me = false;

    void OnValidate()
    {
    	System.Reflection.Assembly[] assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
    	foreach (var assembly in assemblies) {
    		// Only show attributes for UnityEngine and UnityEditor.
    		if (assembly.FullName.StartsWith("UnityEngine") ||
    			assembly.FullName.StartsWith("UnityEditor")) {
    			Type[] types = assembly.GetTypes();
				for (var i = 0; i < types.Length; i++) {
					// Check if it is an attribute.
					if (types[i].IsSubclassOf(typeof(Attribute)))
						print(types[i]);
				}
    		}
    	}
    }
}
