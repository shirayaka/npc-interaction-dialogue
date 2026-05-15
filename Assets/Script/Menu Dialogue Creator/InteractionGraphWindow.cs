using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionGraphWindow : EditorWindow
{
    private InteractionGraphView graphView;

    [MenuItem("Tools/Interaction Graph")]
    public static void Open()
    {
        InteractionGraphWindow window = GetWindow<InteractionGraphWindow>();
        window.titleContent = new GUIContent("Interaction Graph");
    }

    private void OnEnable()
    {
        graphView = new InteractionGraphView();
        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);
    }

    private void OnDisable()
    {
        rootVisualElement.Remove(graphView);
    }
}