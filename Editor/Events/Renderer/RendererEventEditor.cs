using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(RendererEvent), editorForChildClasses: true)]
    public class RendererEventEditor : Editor
    {
        Renderer renderer;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            renderer = EditorGUILayout.ObjectField("renderer", renderer, typeof(Renderer), true) as Renderer;

            RendererEvent e = target as RendererEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(renderer);
        }
    }
}