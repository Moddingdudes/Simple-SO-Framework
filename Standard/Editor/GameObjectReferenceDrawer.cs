#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CyberneticStudios.SOFramework
{
    [CustomPropertyDrawer(typeof(GameObjectReference))]
    public class GameObjectReferenceDrawer : ReferenceDrawer<GameObjectReference>
    {

    }
}