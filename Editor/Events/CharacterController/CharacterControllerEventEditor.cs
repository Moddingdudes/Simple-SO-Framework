using UnityEditor;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CustomEditor(typeof(CharacterControllerEvent), editorForChildClasses: true)]
    public class CharacterControllerEventEditor : Editor
    {
        CharacterController characterController;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            characterController = EditorGUILayout.ObjectField("characterController", characterController, typeof(CharacterController), true) as CharacterController;

            CharacterControllerEvent e = target as CharacterControllerEvent;
            if (GUILayout.Button("Raise Test Event"))
                e.RaiseEvent(characterController);
        }
    }
}