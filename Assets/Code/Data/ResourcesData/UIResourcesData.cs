using UnityEngine;

namespace Code.Data.ResourcesData
{
    [CreateAssetMenu(fileName = "UIResourcesData", menuName = "Data/UI")]
    public class UIResourcesData : ScriptableObject
    {
        [field: SerializeField] public string LevelSelectableUIControlPrefabName { get; private set; }
    }
}