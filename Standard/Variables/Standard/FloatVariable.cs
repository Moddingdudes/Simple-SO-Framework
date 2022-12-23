using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CreateAssetMenu(menuName = AssetMenu.Variables + "Float Variable")]
    public class FloatVariable : Variable<float>
    {
        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }
    }
}