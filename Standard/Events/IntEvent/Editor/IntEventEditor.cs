using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(IntEvent), editorForChildClasses: true)]
    public class IntEventEditor : Editor
    {
        int value;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            value = EditorGUILayout.IntField(value);

            IntEvent e = target as IntEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(value);
        }
    }
}