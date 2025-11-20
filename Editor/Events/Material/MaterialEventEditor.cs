using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(MaterialEvent), editorForChildClasses: true)]
    public class MaterialEventEditor : Editor
    {
        Material material;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            material = EditorGUILayout.ObjectField("material", material, typeof(Material), true) as Material;

            MaterialEvent e = target as MaterialEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(material);
        }
    }
}