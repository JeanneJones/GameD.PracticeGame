using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(PickUpAndHold))]
public class PickUpAndHoldInspector : Editor
{
    private string explanation = "The Player can pick up and drop objects by pressing a key.";
    private string warning = "The Pickup object must be tagged 'Pickup' and have a Rigidbody2D component";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        GUILayout.Space(10);
        DrawDefaultInspector(); // Use this to draw the default inspector fields
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(warning, MessageType.Warning);
    }
}
