using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(RectTransformEvent), editorForChildClasses: true)]
    public class RectTransformEventEditor : Editor
    {
        RectTransform rectTransform;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            rectTransform = EditorGUILayout.ObjectField("rectTransform", rectTransform, typeof(RectTransform), true) as RectTransform;

            RectTransformEvent e = target as RectTransformEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(rectTransform);
        }
    }
}