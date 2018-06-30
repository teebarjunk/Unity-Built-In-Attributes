# Unity-Built-In-Attributes
A list of built in Unity Attributes.
* [Property Inspector](#property-inspector)
* [Serialization](#serialization)
* [Other](#other)
* [Undocumented](#undocumented)

# Property Inspector
[HideInInspector](https://docs.unity3d.com/ScriptReference/HideInInspector.html): Stops the property from showing up in the inspector.
```c#
[HideInInspector] public bool reset = false;
```

[Range](https://docs.unity3d.com/ScriptReference/RangeAttribute.html): Limit the range of a float or int.
```c#
[Range(0, 100)] public float speed = 2f;
```

[Multiline](https://docs.unity3d.com/ScriptReference/MultilineAttribute.html): Show more than one lines.
```c#
[Multiline(4)] public string description = "";
```

[TextArea](https://docs.unity3d.com/ScriptReference/TextAreaAttribute.html): Draw a flexible scrollable text area.
```c#
[TextArea] public string description = "";
```

[Space](https://docs.unity3d.com/ScriptReference/SpaceAttribute.html): Add space between inspector elements.
```c#
public float item1 = 0f;
[Space(10)]
public float item2 = 0f;
```

# Serialization
[SerializeField](https://docs.unity3d.com/ScriptReference/SerializeField.html): Force Unity to serialize a private field.
```c#
[SerializeField] private int score;
```

[NonSerialized](https://docs.unity3d.com/ScriptReference/NonSerializable.html): Prevent Unity from serializing a public field.
```c#
[NonSerialized] public int score;
```

[FormerlySerializedAs](https://docs.unity3d.com/ScriptReference/Serialization.FormerlySerializedAsAttribute.html): If you changed the name of a serialized property, you can set this to the old name, so save data will still work.
```c#
[FormerlySerializedAs("myValue")] private string m_MyValue;
```

# Other
[ExecuteInEditMode](https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html): Will call MonoBehaviour methods like Update and OnEnable while in EditMode.
```c#
[ExecuteInEditMode]
public class MyClass : MonoBehaviour
{
}
```

[ContextMenu](https://docs.unity3d.com/ScriptReference/ContextMenu.html): Add a context menu to a MonoBehaviour or ScriptableObject.
```c#
[ContextMenu("Reset Score")]
public void ResetHealth()
{
    health = 100;
}
```

[RuntimeInitializeOnLoadMethod](https://docs.unity3d.com/ScriptReference/RuntimeInitializeOnLoadMethodAttribute.html): Calls a method once before or after the first scene has loaded. Good for initializing Singletons without having to place objects in the scene.
```c#
[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
static void OnLoad()
{
    Debug.Log("Create Singletons");
}
```

[OnOpenAssetAttribute](https://docs.unity3d.com/ScriptReference/Callbacks.OnOpenAssetAttribute.html): Called when double clicking an asset in the project browser.
```c#
[OnOpenAssetAttribute(1)]
public static bool step1(int instanceID, int line)
{
    string name = EditorUtility.InstanceIDToObject(instanceID).name;
    Debug.Log("Open Asset step: 1 (" + name + ")");
    return false; // we did not handle the open
}
```

# Undocumented
DefaultExecutionOrder: Probably sets the Script Execution order.
```c#
[DefaultExecutionOrder(100)]
public class MyScript : MonoBehaviour
{
}
```
