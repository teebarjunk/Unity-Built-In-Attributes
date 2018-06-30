# Unity-Built-In-Attributes
A list of built in Unity Attributes.
* [Property Inspector](#property-inspector)
* [Component Related](#component-related)
* [Serialization](#serialization)
* [Other](#other)
* [Undocumented](#undocumented)
* [Editor](#editor)

Note: Attributes can be placed in a single set of square brackets:
```c#
[HideInInspector][SerializeField] int score;
// can be
[HideInInspector, SerializeField] int score;
```

These aren't all the attributes available, and a few of them are system attributes, not Unity ones.

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

[ColorUsage](https://docs.unity3d.com/ScriptReference/ColorUsageAttribute.html): Allow alpha channel to be modified, and allow HDR mode.
```c#
[ColorUsage(true, true)] public Color color = Color.white;
```

[Space](https://docs.unity3d.com/ScriptReference/SpaceAttribute.html): Add space between inspector elements.
```c#
public float item1 = 0f;
[Space(10)]
public float item2 = 0f;
```

[Header](https://docs.unity3d.com/ScriptReference/HeaderAttribute.html): Shows a bold label in the inspector.
```c#
[Header("Stats")]
public int health = 100;
public float speed = 0f;
[Header("Items")]
public int ammo = 10;
```

[ToolTip](https://docs.unity3d.com/ScriptReference/TooltipAttribute.html): Text shown on mouse over.
```c#
[ToolTip("The games score.")] public int score = 0;
```

# Component Related
[DisallowMultipleComponent](https://docs.unity3d.com/ScriptReference/DisallowMultipleComponent.html): Prevent more than 1 of this component being on a GameObject.
```c#
[DisallowMultipleComponent]
public class MyScript : MonoBehaviour
{
}
```

[RequireComponent](https://docs.unity3d.com/ScriptReference/RequireComponent.html): Tell GameObject to add this component if it isn't already added.
```c#
[RequireComponent(typeof(RigidBody))]
[RequireComponent(typeof(Component1), typeof(Component2), typeof(Component3))]  // You can enter multiple components into attribute.
public class MyClass : MonoBehaviour
{
}
```

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

[SelectionBase](https://docs.unity3d.com/ScriptReference/SelectionBaseAttribute.html): Will select this GameObject when a sub object is selected in the editor.
```c#
[SelectionBase]
public class MyClass : MonoBehaviour
{
}
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

[Serializable](https://docs.unity3d.com/ScriptReference/Serializable.html): Make a class Serializable so it will be visible in the inspector.
```c#
[System.Serializable]
public class MyClass
{
    public int myInt = 10;
    public Color myColor = Color.white;
}
```

# Other
[RuntimeInitializeOnLoadMethod](https://docs.unity3d.com/ScriptReference/RuntimeInitializeOnLoadMethodAttribute.html): Calls a method once before or after the first scene has loaded. Good for initializing Singletons without having to place objects in the scene.
```c#
[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
static void OnLoad()
{
    Debug.Log("Create Singletons");
}
```

[CreateAssetMenu](https://docs.unity3d.com/ScriptReference/CreateAssetMenuAttribute.html): Add an option to Assets/Create for creating a ScriptableObject.
```c#
[CreateAssetMenu(menuName = "My ScriptableObject", order = 100)]
public class MyScriptableObject : ScriptableObject
{
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

# Editor
These should be used in scripts that are inside an Editor folder.

[MenuItem](https://docs.unity3d.com/ScriptReference/MenuItem.html): Adds a menu to the Editor toolbar.
```c#
[MenuItem("MyMenu/Do Something")]
static void DoSomething()
{
    Debug.Log("Doing Something...");
}
```

[InitializeOnLoadMethod](https://docs.unity3d.com/ScriptReference/InitializeOnLoadMethodAttribute.html): Called after scripts have been compiled.
```c#
[InitializeOnLoadMethod]
static void OnProjectLoadedInEditor()
{
    Debug.Log("Project loaded in Unity Editor");
}
```

[OnOpenAssetAttribute](https://docs.unity3d.com/ScriptReference/Callbacks.OnOpenAssetAttribute.html): Called when double clicking an asset in the project browser.
```c#
[OnOpenAssetAttribute(1)]
static bool step1(int instanceID, int line)
{
    string name = EditorUtility.InstanceIDToObject(instanceID).name;
    Debug.Log("Open Asset step: 1 (" + name + ")");
    return false; // we did not handle the open
}
```
