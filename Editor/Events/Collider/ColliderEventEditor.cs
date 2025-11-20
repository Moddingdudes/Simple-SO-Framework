using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(ColliderEvent), editorForChildClasses: true)]
    public class ColliderEventEditor : Editor
    {
        Collider collider;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            collider = EditorGUILayout.ObjectField("collider", collider, typeof(Collider), true) as Collider;

            ColliderEvent e = target as ColliderEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(collider);
        }
    }
}