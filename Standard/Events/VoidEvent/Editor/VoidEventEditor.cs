using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(VoidEvent), editorForChildClasses: true)]
    public class VoidEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            VoidEvent e = target as VoidEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent();
        }
    }
}