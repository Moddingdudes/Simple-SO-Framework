using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(Rigidbody2DEvent), editorForChildClasses: true)]
    public class Rigidbody2DEventEditor : Editor
    {
        Rigidbody2D rigidbody2D;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            rigidbody2D = EditorGUILayout.ObjectField("rigidbody2D", rigidbody2D, typeof(Rigidbody2D), true) as Rigidbody2D;

            Rigidbody2DEvent e = target as Rigidbody2DEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(rigidbody2D);
        }
    }
}