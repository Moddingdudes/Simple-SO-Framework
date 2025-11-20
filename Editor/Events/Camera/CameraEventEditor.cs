using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(CameraEvent), editorForChildClasses: true)]
    public class CameraEventEditor : Editor
    {
        Camera camera;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            camera = EditorGUILayout.ObjectField("camera", camera, typeof(Camera), true) as Camera;

            CameraEvent e = target as CameraEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(camera);
        }
    }
}