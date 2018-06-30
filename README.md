# Unity-Built-In-Attributes
A list of built in Unity Attributes.

## Property Inspector
[Range](https://docs.unity3d.com/ScriptReference/RangeAttribute.html)
```c#
[Range(0, 100)] public float speed = 2f;
```

[Multiline](https://docs.unity3d.com/ScriptReference/MultilineAttribute.html)
```c#
[Multiline(4)] public string description = "";
```

[Space](https://docs.unity3d.com/ScriptReference/SpaceAttribute.html)
Add space between inspector elements.
```c#
public float item1 = 0f;
[Space(10)]
public float item2 = 0f;
```

## Other
[OnOpenAssetAttribute](https://docs.unity3d.com/ScriptReference/Callbacks.OnOpenAssetAttribute.html)
Called when double clicking an asset in the project browser.
```c#
[OnOpenAssetAttribute(1)]
{
    string name = EditorUtility.InstanceIDToObject(instanceID).name;
    Debug.Log("Open Asset step: 1 (" + name + ")");
    return false; // we did not handle the open
}
```
