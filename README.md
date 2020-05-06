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

Added May 6, 2020:
    GradientUsage
    Min
    InspectorName
    Delayed
    ContextMenuItem
    ImageEffectTransformsToLDR
    ImageEffectAllowedInSceneView
    ImageEffectOpaque
    ImageEffectAfterScale
    ImageEffectUsesCommandBuffer
    AssemblyIsEditorAssembly
    ExcludeFromPreset
    ExcludeFromObjectFactory
    ExcludeFromCoverage
    SharedBetweenAnimatorsAttribute
    BeforeRenderOrderAttribute

Added July 3, 2018:
    DidReloadScripts
    PostProcessScene
    PostProcessBuild
    Preserve
    RejectDragAndDropMaterial
    CustomGridBrush
    IconName

# Property Inspector
[HideInInspector](https://docs.unity3d.com/ScriptReference/HideInInspector.html): Stops the property from showing up in the inspector.
```c#
[HideInInspector] public bool reset = false;
```

[Range](https://docs.unity3d.com/ScriptReference/RangeAttribute.html): Limit the range of a float or int.
```c#
[Range(0, 100)] public float speed = 2f;
```

[Min](https://docs.unity3d.com/ScriptReference/MinAttribute.html): Limit minimum value of float or int.
```c#
[Min(1.0f)] public float speed = 2.0;
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

[GradientUsage](https://docs.unity3d.com/ScriptReference/GradientUsageAttribute.html): Use on a gradient to configure the GradientField.
```c#
[GradientUsage(true)] public Color color = Color.white;
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

[InspectorName](https://docs.unity3d.com/ScriptReference/InspectorNameAttribute.html): Use on enum to change it's display name.
```c#
public enum ModelImporterIndexFormat
{
    Auto = 0,
    [InspectorName("16 bits")]
    UInt16 = 1,
    [InspectorName("32 bits")]
    UInt32 = 2,
}
```

[Delayed](https://docs.unity3d.com/ScriptReference/DelayedAttribute.html): Use on float, int, or string to delay property being changed until user presses enter or focus changes.
```c#
[Delayed] public string health = 100;
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
public void ResetScore()
{
    score = 100;
}
```

[ContextMenuItem](https://docs.unity3d.com/ScriptReference/ContextMenuItemAttribute.html): Calls a method for a field.
```c#
[ContextMenuItem("Reset Score", "ResetScore")]
var score = 10;

void ResetScore()
{
    score = 0;
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

# Image Effect
[ImageEffectTransformsToLDR](https://docs.unity3d.com/ScriptReference/ImageEffectTransformsToLDR.html): Use on image effect to cause destination buffer to be LDR buffer.

[ImageEffectAfterScale](https://docs.unity3d.com/ScriptReference/ImageEffectAfterScale.html): "Any Image Effect with this attribute will be rendered after Dynamic Resolution stage."

[ImageEffectAllowedInSceneView](https://docs.unity3d.com/ScriptReference/ImageEffectAllowedInSceneView.html): Allows image effect to work on scene view camera.
```c#
[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class BloomEffect : MonoBehaviour
{
}
```

[ImageEffectOpaque](https://docs.unity3d.com/ScriptReference/ImageEffectOpaque.html): "Any Image Effect with this attribute will be rendered after opaque geometry but before transparent geometry."
```c#
[ImageEffectOpaque]
void OnRenderImage(RenderTexture source, RenderTexture destination)
{
}
```

[ImageEffectUsesCommandBuffer](https://docs.unity3d.com/ScriptReference/ImageEffectUsesCommandBuffer.html): "Use this attribute when image effects are implemented using Command Buffers."
```c#
void OnRenderImage(RenderTexture source, RenderTexture destination)
{
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

[Preserve](https://docs.unity3d.com/ScriptReference/Scripting.PreserveAttribute.html): Preserves a members name when converting to bytecode. Useful if referencing members through reflection.
```c#
[Preserve]
static void Boink()
{
    Debug.Log("Boink");
}
```

[CustomGridBrush](https://docs.unity3d.com/ScriptReference/CustomGridBrushAttribute.html): "define the class as a grid brush and to make it available in the palette window."
```c#
[CustomGridBrush(true, true, true, "Default Brush")]
public class MyBrush : GridBrush
{
}
```

[BeforeRenderOrder](https://docs.unity3d.com/ScriptReference/BeforeRenderOrderAttribute.html): "Use this BeforeRenderOrderAttribute when you need to specify a custom callback order for Application.onBeforeRender."

[SharedBetweenAnimators](https://docs.unity3d.com/ScriptReference/SharedBetweenAnimatorsAttribute.html): "...an attribute that specify that this StateMachineBehaviour should be instantiate only once and shared among all Animator instance. This attribute reduce the memory footprint for each controller instance."
```c#
[SharedBetweenAnimatorsAttribute]
public class AttackBehavior : StateMachineBehaviour
{
}
```

[AssemblyIsEditorAssembly](https://docs.unity3d.com/ScriptReference/AssemblyIsEditorAssembly.html): Can use this rather than place the script in an "Editor" folder.
```c#
[assembly:AssemblyIsEditorAssembly]

public class MyEditorClass : MonoBehaviour
{
}
```

[ExcludeFromPreset](https://docs.unity3d.com/ScriptReference/ExcludeFromPresetAttribute.html): "Add this attribute to a class to prevent creating a Preset from the instances of the class."
```c#
[ExcludeFromPreset]
public class MyClass : MonoBehaviour
{
    public int score = 10; // Won't be used in Preset?
}
```

[ExcludeFromObjectFactory](https://docs.unity3d.com/ScriptReference/ExcludeFromObjectFactoryAttribute.html): "Add this attribute to a class to prevent the class and its inherited classes from being created with ObjectFactory methods."

[ExcludeFromCoverage](https://docs.unity3d.com/ScriptReference/TestTools.ExcludeFromCoverageAttribute.html): "Allows you to exclude an Assembly, Class, Constructor, Method or Struct from Coverage."

# Undocumented
DefaultExecutionOrder: Probably sets the Script Execution order.
```c#
[DefaultExecutionOrder(100)]
public class MyScript : MonoBehaviour
{
}
```

RejectDragAndDropMaterial: Probably prevents materials being applied through dragging and dropping in the editor.
```c#
[RejectDragAndDropMaterial]
public class MyRenderer : MonoBehaviour
{
}
```

UnityEditor.IconName: Probably allows you to set a scripts icon?


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

[DidReloadScripts](https://docs.unity3d.com/ScriptReference/Callbacks.DidReloadScripts.html): Called after scripts have reloaded. Can take an order parameter. Methods with lower orders are called earlier.
```c#
using UnityEditor.Callbacks;

[DidReloadScripts(100)]
static void OnScriptsReloaded()
{
    Debug.Log("Reloaded.");
}
#endif
```

[OnOpenAsset](https://docs.unity3d.com/ScriptReference/Callbacks.OnOpenAssetAttribute.html): Called when double clicking an asset in the project browser.
```c#
using UnityEditor.Callbacks;

[OnOpenAssetAttribute(1)]
static bool step1(int instanceID, int line)
{
    string name = EditorUtility.InstanceIDToObject(instanceID).name;
    Debug.Log("Open Asset step: 1 (" + name + ")");
    return false; // we did not handle the open
}
```

[PostProcessBuild](https://docs.unity3d.com/ScriptReference/Callbacks.PostProcessBuildAttribute.html): Called after game has been built.
```c#
using UnityEditor.Callbacks;

[PostProcessBuildAttribute(1)]
public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
{
}
```

[PostProcessScene](https://docs.unity3d.com/ScriptReference/Callbacks.PostProcessSceneAttribute.html): Called after scene has been built.
```c#
using UnityEditor.Callbacks;

[PostProcessSceneAttribute (2)]
public static void OnPostprocessScene()
{
}
```
