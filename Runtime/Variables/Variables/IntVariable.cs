using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CreateAssetMenu(menuName = AssetMenu.Variables + "Int Variable")]
    public class IntVariable : Variable<int>
    {
        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }
    }
}