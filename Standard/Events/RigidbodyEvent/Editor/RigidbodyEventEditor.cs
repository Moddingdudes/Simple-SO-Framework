using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(RigidbodyEvent), editorForChildClasses: true)]
    public class RigidbodyEventEditor : Editor
    {
        Rigidbody rigidbody;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            rigidbody = EditorGUILayout.ObjectField("rigidbody", rigidbody, typeof(Rigidbody), true) as Rigidbody;

            RigidbodyEvent e = target as RigidbodyEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(rigidbody);
        }
    }
}