using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(TransformEvent), editorForChildClasses: true)]
    public class TransformEventEditor : Editor
    {
        Transform transform;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            transform = EditorGUILayout.ObjectField("transform", transform, typeof(Transform), true) as Transform;

            TransformEvent e = target as TransformEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(transform);
        }
    }
}