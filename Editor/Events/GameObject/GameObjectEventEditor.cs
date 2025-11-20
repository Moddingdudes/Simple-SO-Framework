using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(GameObjectEvent), editorForChildClasses: true)]
    public class GameObjectEventEditor : Editor
    {
        GameObject gameObject;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            gameObject = EditorGUILayout.ObjectField("gameObject", gameObject, typeof(GameObject), true) as GameObject;

            GameObjectEvent e = target as GameObjectEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(gameObject);
        }
    }
}